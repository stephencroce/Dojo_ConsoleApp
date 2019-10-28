using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//libraries i added explicitly
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess; 

namespace Dojo_ConsoleApp
{
    [RunInstaller(true)]
    public class MyWindowsServiceInstaller : Installer
    {
        
        public MyWindowsServiceInstaller()
        {
            //explicit constructor required for Windows Services
            //These two classes are responsible for installing the service. 
            //The ServiceProcessInstaller installs information common to all services.
            //The ServiceInstaller installs information for this specific service.
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.LocalSystem;


            serviceInstaller.DisplayName = "Dojo_ConsoleAppService";
            serviceInstaller.StartType = ServiceStartMode.Manual;

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "Dojo_ConsoleAppService";



            serviceInstaller.Description = "Dojo_ConsoleAppService";


    
            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);

        }

    }
}
