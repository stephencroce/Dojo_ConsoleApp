using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
{
    public sealed class Car : Vehicle  //SEALED CLASSES cannot be inherited from
    {        
        //public Car();
        public int NumOfPassengers { get; set; }

        public override string startEngine()
        {
            return "Vroom";
        }
    }
}
