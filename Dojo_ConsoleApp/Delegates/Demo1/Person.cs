using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.Demo1.Delegates
{
    class Person
    {
        public void respondToDoorBell(object sender, EventArgs e) 
        {             
            Console.WriteLine("who is it??"); 
        }
        public void ShoutString(string stringToShout)
        {
            Console.WriteLine(stringToShout.ToUpper());  
        }
        public void GetFirst5(string originalString)
        { 
            Console.WriteLine(originalString.Substring(0, 5)); 
        }
        

    }
}
