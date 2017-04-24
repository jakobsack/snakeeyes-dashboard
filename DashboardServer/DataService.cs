using DashboardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashboardServer
{
    public partial class DataService : ServiceBase
    {
        private List<ThreadData> _threads = new List<ThreadData>();

        public DataService()
        {
            InitializeComponent();
            Log.Initialize();
        }

        protected override void OnStart(string[] args)
        {
            Log.Flow("Starting worker thread");

            ManualResetEvent shutDownEvent = new ManualResetEvent(false);
            Thread t = new Thread(() => Worker.Run(shutDownEvent))
            {
                Name = "RunPowershellServiceThread",
                IsBackground = true
            };
            t.Start();
            _threads.Add(new ThreadData(t, shutDownEvent));

            Log.Flow("Worker thread started");
        }

        protected override void OnStop()
        {
            Log.Flow("Stopping worker thread");

            Log.Flow("Shutting down.");
            foreach (ThreadData threadData in _threads)
            {
                threadData._shutdownEvent.Set();
                if (!threadData._thread.Join(10000))
                {
                    // give the thread 10 seconds to stop
                    threadData._thread.Abort();
                }
            }

            Log.Flow("Worker thread stopped");
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        #region ThreadData

        private class ThreadData
        {
            public Thread _thread;
            public ManualResetEvent _shutdownEvent;

            public ThreadData(Thread thread, ManualResetEvent shutdownEvent)
            {
                _thread = thread;
                _shutdownEvent = shutdownEvent;
            }
        }

        #endregion
    }
}
