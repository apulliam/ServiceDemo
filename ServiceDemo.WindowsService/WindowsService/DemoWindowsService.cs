using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace ServiceDemo.WindowsService.WindowsService
{
    partial class DemoWindowsService : ServiceBase
    {
        IDisposable _webApp = null;

        public static void Main(string[] args)
        {
            DemoWindowsService posService = new DemoWindowsService();
            bool standAlone = false;
            if (args.Length > 0)
                standAlone = args[0].ToLower().Equals("standalone");

            if (!standAlone)
                ServiceBase.Run(posService);
            else
            {
                posService.OnStart(args);

                if (standAlone)
                {
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                }

                posService.OnStop();
            }
        }

        public DemoWindowsService()
        {
            ServiceName = "DemoWindowsService";
            if (!System.Diagnostics.EventLog.SourceExists(ServiceName))
                System.Diagnostics.EventLog.CreateEventSource(ServiceName, "Application");
        }

        protected override void OnStart(string[] args)
        {

            if (_webApp != null)
            {
                _webApp.Dispose();
            }


            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            if (string.IsNullOrEmpty(baseAddress))
                throw new ConfigurationErrorsException("ServiceAddress must be specified in AppSettings");


            // Start OWIN host 
            _webApp = WebApp.Start<Startup>(url: baseAddress);

        }

        protected override void OnStop()
        {
            _webApp.Dispose();
        }
    }
}


  

