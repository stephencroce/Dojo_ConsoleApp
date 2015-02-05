using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.Demo1.Delegates
{
    public class Doorbell
    {
        //here are telltale code patterns of delegation - I'm not sure I really GET them, but here they are.  There may be nothing to GET, and that's just how it is..., but I always hate that.
        public delegate void MyDelegate(); 
        public static event MyDelegate DoorBellRings;


        public void PressRinger()
        {
            Dog dog = new Dog();
            Person person = new Person();

            Console.WriteLine("ding dong"); 
            
            //here is another telltale code pattern of delegation:
            //Subscribe or “Point“ the methods to the delegate so that they “listen for” its         invokatio
            DoorBellRings += dog.bark; 
            DoorBellRings += person.respondToDoorBell; 

            //not sure about the semantics of this - I think maybe it means "FIRE THE EVENT"???
            DoorBellRings();

            
        } 
    }
}
