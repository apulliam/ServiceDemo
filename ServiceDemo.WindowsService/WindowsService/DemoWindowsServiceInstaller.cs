using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDemo.WindowsService.WindowsService
{
    [RunInstaller(true)]
    public partial class PosServiceInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public PosServiceInstaller()
        {
            InitializeComponent();
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();

            string serviceName = "PosService";

            if (!System.Diagnostics.EventLog.SourceExists(serviceName))
                System.Diagnostics.EventLog.CreateEventSource(serviceName, "Application");

            EventLog.WriteEntry(serviceName, "Registering " + serviceName);

            service.ServiceName = serviceName;
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
