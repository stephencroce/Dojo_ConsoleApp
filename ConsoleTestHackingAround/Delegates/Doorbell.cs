using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.Delegates
{
    public class Doorbell
    {
        //here are telltale code patterns of delegation - I'm not sure I really GET them, but here they are.  There may be nothing to GET, and that's just how it is..., but I always hate that.
        public delegate void MyDelegate(); 
        public static event MyDelegate DoorBellRings;


        public void PressRinger()
        {
            Console.WriteLine("ding dong"); 
            Dog dog = new Dog(); 
            Person person = new Person();
            //here is another telltale code pattern of delegation:
            DoorBellRings += dog.bark; DoorBellRings += person.respond; DoorBellRings();
        } 
    }
}
