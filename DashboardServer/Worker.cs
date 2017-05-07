using DashboardLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace DashboardServer
{
    class Worker
    {
        // TODO: move these values to settings?
        private static string DataDirectory = null;
        private static string BackupDirectory = null;

        private static Dictionary<string, Probe> Probes = new Dictionary<string, Probe>();

        public static void Run(ManualResetEvent shutdownEvent)
        {
            Log.Flow("Worker thread says hello");
            DateTime lastCompression = DateTime.MinValue;

            DataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            BackupDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");

            Log.Flow(String.Format("Data will be saved in  {0}", DataDirectory));
            Log.Flow(String.Format("Backups will be saved in {0}", BackupDirectory));

            // Create our queues
            MsmqHelper.CreateQueue(MsmqHelper.InboxQueueName);
            MsmqHelper.CreateQueue(MsmqHelper.ResponseQueueName);
            MsmqHelper.CreateQueue(MsmqHelper.RequestQueueName);

            // Create folders we'll need
            Directory.CreateDirectory(DataDirectory);
            Directory.CreateDirectory(BackupDirectory);

            // Load old data
            foreach (string fileName in Directory.EnumerateFiles(DataDirectory, "*.xml"))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Probe));
                    Probe probe = (Probe)ser.Deserialize(reader);

                    Probes[probe.Id] = probe;
                }
            }

            // Load old backup data if required
            foreach (Probe probe in Probes.Values)
            {
                string probeBackupPath = Path.Combine(BackupDirectory, probe.Id);
                if (Directory.Exists(probeBackupPath))
                {
                    foreach (string backupFile in Directory.EnumerateFiles(probeBackupPath, "*.xml"))
                    {
                        HandleTraceEvent(File.ReadAllText(backupFile), false);
                    }
                }
            }

            while (!shutdownEvent.WaitOne(0))
            {
                // Get new messages and save them
                try
                {
                    string inMessage = MsmqHelper.Read(MsmqHelper.InboxQueueName);
                    if (inMessage != null)
                    {
                        HandleTraceEvent(inMessage);
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                // Handle requests from clients
                try
                {
                    string inMessage = MsmqHelper.Read(MsmqHelper.RequestQueueName);
                    if (inMessage != null)
                    {
                        HandleRequest(inMessage);
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                // Compress data
                try
                {
                    if ((DateTime.Now - lastCompression).TotalSeconds > 3600)
                    {
                        foreach (Probe probe in Probes.Values)
                        {
                            probe.CompressHistory();
                            File.WriteAllText(Path.Combine(DataDirectory, probe.Id + ".xml"), probe.ToXml());
                            if (Directory.Exists(Path.Combine(BackupDirectory, probe.Id)))
                            {
                                Directory.Delete(Path.Combine(BackupDirectory, probe.Id), true);
                            }
                        }

                        // Set compression time to now
                        lastCompression = DateTime.Now;
                        lastCompression = lastCompression.AddMilliseconds(-lastCompression.Second).AddSeconds(-lastCompression.Second).AddMinutes(-lastCompression.Minute);
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private static void HandleTraceEvent(string traceEventData, bool createBackup = true)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(traceEventData);

            Probe probe = Probe.FromTraceEvent(xml);
            if (Probes.ContainsKey(probe.Id))
            {
                Probes[probe.Id].LastState = probe.LastState;
                Probes[probe.Id].LastTimestamp = probe.LastTimestamp;
                Probes[probe.Id].LastValue = probe.LastValue;
                Probes[probe.Id].MaxValue = probe.MaxValue;
                Probes[probe.Id].MinValue = probe.MinValue;
            }
            else
            {
                Probes[probe.Id] = probe;
                File.WriteAllText(Path.Combine(DataDirectory, probe.Id + ".xml"), probe.ToXml());
            }

            HistoryItem item = HistoryItem.FromProbe(probe);

            if (item != null)
            {
                Probes[probe.Id].History.Add(item);
            }

            Directory.CreateDirectory(Path.Combine(BackupDirectory, probe.Id));
            File.WriteAllText(Path.Combine(BackupDirectory, probe.Id, probe.LastTimestamp.ToString("yyyy-MM-dd HH.mm.ss.fff'.xml'")), traceEventData);
        }

        private static void HandleRequest(string requestData)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Request));
            Request request = (Request)ser.Deserialize(new StringReader(requestData));

            Response response = new Response
            {
                Id = request.Id,
                Type = request.Type,
            };

            if (request.Type == Request.Types.Probes)
            {
                response.Probes = Probes.Values.Select(x => x.StripHistory()).ToList();
            }
            else if (request.Type == Request.Types.History)
            {
                response.Probes = new List<Probe> { Probes[request.ProbeId] };
            }
            else if (request.Type == Request.Types.Edit)
            {
                Probe probe = Probes[request.ProbeId];
                probe.CommonName = request.CommonName;
                probe.SizeType = request.SizeType;
                response.Probes = new List<Probe> { probe };
            }

            MsmqHelper.Write(MsmqHelper.ResponseQueueName, response.ToXml());
        }
    }
}
