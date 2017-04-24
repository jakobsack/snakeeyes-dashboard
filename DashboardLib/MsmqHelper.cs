using System;
using System.IO;
using System.Messaging;

namespace DashboardLib
{
    public class MsmqHelper
    {
        private static ActiveXMessageFormatter Formatter = new ActiveXMessageFormatter();
        private static TimeSpan Timeout = TimeSpan.FromMilliseconds(10);

        public static string ResponseQueueName = @".\Private$\SnakeEyesResponse";
        public static string InboxQueueName = @".\Private$\SnakeEyesInbox";
        public static string RequestQueueName = @".\Private$\SnakeEyesRequest";

        public static void CreateQueue(string queueName)
        {
            // Create the queue if it does not exist
            if (!MessageQueue.Exists(queueName))
            {
                Log.Flow("Creating queue: " + queueName);
                using (MessageQueue queueCreate = MessageQueue.Create(queueName, true))
                {
                    //Try to extract the label
                    try
                    {
                        int lastBackSlash = queueName.LastIndexOf('\\');
                        if (lastBackSlash != -1)
                            queueCreate.Label = queueName.Substring(lastBackSlash + 1);
                    }
                    catch (Exception exception)
                    {
                        Log.Error("Could not create queue: " + queueName);
                        throw new Exception("Could not create queue: " + exception.ToString());
                    }
                }
            }
        }

        public static string Read(string queueName)
        {
            string content = null;

            using (MessageQueue queue = new MessageQueue(queueName))
            {
                queue.Formatter = Formatter;

                Message requestMessage = null;
                try
                {
                    //queue.BeginPeek(timeout);
                    requestMessage = queue.Receive(Timeout, MessageQueueTransactionType.Single);
                }
                catch (Exception)
                {
                    return null;
                }

                try
                {
                    content = (string)requestMessage.Body;
                }
                catch (Exception exc1)
                {
                    try
                    {
                        requestMessage.Formatter = Formatter;
                        StreamReader reader = new StreamReader(requestMessage.BodyStream);
                        content = reader.ReadToEnd();
                    }
                    catch (Exception exc2)
                    {
                        Log.Error(exc1.ToString());
                        Log.Error(exc2.ToString());
                        return null;
                    }
                }
            }

            return content;
        }

        public static void Write(string queueName, string content)
        {
            using (MessageQueue queue = new MessageQueue(queueName))
            {
                Message message = new Message()
                {
                    Formatter = Formatter,
                    Label = "TpmServer",
                    Body = content
                };
                queue.Send(message, MessageQueueTransactionType.Single);// The last part is required for transactional queues, not testet for non-transactional.
            }
        }
    }
}
