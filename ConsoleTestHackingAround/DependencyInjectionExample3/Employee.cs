using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.DependencyInjectionExample3
{
    public class Employee
    {
        //
        private Company _company;

        //Here, this is constructor injection:
        [Microsoft.Practices.Unity.InjectionConstructor] //this has got to be here for the unity **constructor** dependency injection to work.
        public Employee(Company company)
        {
            _company = company;
        }
        public void DisplaySalary()
        {
            _company.ShowSalary(); 
        }
    }
}
