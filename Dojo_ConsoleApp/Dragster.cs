using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
{
    //class Dragster : Car  //Can't do this because, I've maked Car with SEALED keyword...
    class Dragster : Vehicle
    {
        public override string startEngine()
        {
            return "ROOOOOAAARRRRRR";
        }
   
    }
}
