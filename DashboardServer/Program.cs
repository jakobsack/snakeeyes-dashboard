using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DashboardServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static int Main(string[] args)
        {
            // install service
            if (args.Length > 0 && (args[0].ToLower() == "/install"))
            {
                System.Configuration.Install.TransactedInstaller ti = new System.Configuration.Install.TransactedInstaller();
                ti.Installers.Add(new DataServiceInstaller());
                ti.Context = new System.Configuration.Install.InstallContext("", null);
                ti.Context.Parameters["assemblypath"] = System.Reflection.Assembly.GetExecutingAssembly().Location;
                ti.Install(new System.Collections.Hashtable());
                return 0;
            }

            // uninstall service
            if (args.Length > 0 && (args[0].ToLower() == "/uninstall"))
            {
                System.Configuration.Install.TransactedInstaller ti = new System.Configuration.Install.TransactedInstaller();
                ti.Installers.Add(new DataServiceInstaller());
                ti.Context = new System.Configuration.Install.InstallContext("", null);
                ti.Context.Parameters["assemblypath"] = System.Reflection.Assembly.GetExecutingAssembly().Location;
                ti.Uninstall(null);
                return 0;
            }

            // run in a shell or as a service
            if (Environment.UserInteractive)
            {
                DataService service = new DataService();
                service.TestStartupAndStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new DataService()
                };
                ServiceBase.Run(ServicesToRun);
            }

            return 0;
        }
    }
}
