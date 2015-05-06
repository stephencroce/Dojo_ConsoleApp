using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryHack;

namespace ConsoleTestHackingAround.DependencyInjectionExample1
{
    public class Client
    {
        private IService _iservice;

        public Client()
        { }

        public Client(IService service)
        {
            _iservice = service;
        }

        public void Start()
        {
            Console.WriteLine("I am going to tell the service to serve:");
            _iservice.Serve();
            string barf = _iservice.puke();
            Console.WriteLine(barf);

            //Whether or not you can use AddTwoIntegers method depends on how you declare the variable stupidMath
            //IStupidMath stupidMath = new StupidMath();
            StupidMath stupidMath = new StupidMath();             
            
            Console.WriteLine(string.Format("the sum of two plus two is {0}",stupidMath.AddTwoIntegers(2,2).ToString()));
            Console.WriteLine(string.Format("the product of five times five {0}", stupidMath.MultiplyTwoStupidIntegers(5, 5).ToString()));


            IStupidMath stupidMathInstance = GetStupidMathClass();
            

            Console.WriteLine("this was multiplied using a returned interface:  "+stupidMathInstance.MultiplyTwoStupidIntegers(6, 6).ToString());

            //Q:  this was put here to test how if the parent libary was updated to add a Divide method, how do you get it to be available in the 
            //projects that depend on it?
            //A:  when not automated in any way, you have to manually copy and paste the newly compiled dll into the bin-debug folder.
            //    one way to automate it might be through a Post Build event, Project > Properties
            Console.WriteLine("this was divided using a returned interface:  " + stupidMathInstance.MultiplyTwoStupidIntegers(6, 6).ToString()); 
           
        }
        //Factory Pattern!!!
        public IStupidMath GetStupidMathClass()
        {            
            IStupidMath mystupidmath = new StupidMath();
            return mystupidmath;
        }
        //public StupidMath GetStupidMathClass(StupidMath myStupidMath2)
        //{

        //    return myStupidMath2;
        //}
    }
}
