using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Microsoft.Practices.Unity; 

namespace Dojo_ConsoleApp.DependencyInjectionExample2
{
    public class Employee //: IEmployee
    {
        //private Company _Company;
        //private ICompany _Company;
        //[Dependency]
        [Microsoft.Practices.Unity.Dependency] //this has got to be here for the unity property dependency injection to work.
        public Company Company { get; set; }
        public void DisplaySalary()
        {
            Company.ShowSalary(); 
        }
    }
}
