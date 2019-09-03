using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.Factory
{
    public class Clerk : Position
    {
        public override string Title
        {
            get
            {
                return "clerk";
            }
        }
    }
}
