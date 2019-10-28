using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.DependencyInjectionExample1
{
    public class Service : IService 
    {

        public void Serve()
        {

            Console.WriteLine("The service class is now serving!");
        }
        public string puke()
        {
            return "blowing chunks...bleahhhhhhh";
        }
        public string mangle()
        {
            return "adflkasjhflkahfoqio3";
        }

    }
}
