using log4net;

namespace DashboardLib
{
    public class Log
    {
        static ILog flowLog = null;
        static ILog exceptionLog = null;

        public static void Initialize()
        {
            if (flowLog == null) flowLog = LogManager.GetLogger("FlowLog");
            if (exceptionLog == null) exceptionLog = LogManager.GetLogger("ExceptionLog");
        }

        public static void Flow(string message)
        {
            if (flowLog != null)
            {
                flowLog.Info(message);
            }
        }

        public static void Error(string message)
        {
            if (flowLog != null) flowLog.Error(message);
            if (exceptionLog != null) exceptionLog.Error(message);
        }

    }
}
