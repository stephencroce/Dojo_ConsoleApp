using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.Demo1.Delegates
{
    class Dog
    {
        public void bark(object sender, EventArgs e) { Console.WriteLine("woof woof"); } 
    }
}
