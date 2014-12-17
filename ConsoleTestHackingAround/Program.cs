using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//libraries i added explicitly
using System.ServiceProcess;

using System.Timers;

using ConsoleTestHackingAround.DependencyInjectionExample1;
using ConsoleTestHackingAround.DependencyInjectionExample2;
using ConsoleTestHackingAround;

using Microsoft.Practices.Unity; 

namespace ConsoleTestHackingAround.StupidAss
{
    //http://tech.pro/tutorial/895/creating-a-simple-windows-service-in-csharp
    class Program : ServiceBase 
    {

        //explicit constructor required for Windows Services
        public Program()
        {
            this.ServiceName = "ConsoleTestHackingAroundService";
            
        }
        static void Method(out int i, out string s1, out string s2)
        {
            i = 44;
            s1 = "I've been returned";
            s2 = null;
        }
        static void Method2(out int i, string s1, string s2)
        {
            i = 44;
            s1 = "I've been returned";
            s2 = null;
        }
        static void Method3(int i, string s1, string s2)
        {
           // i = 44;
            //s1 = "I've been returned";
            //s2 = null;
            Console.Write("nothing happened");
        }

        //IComparable shit - turns out that the big benefit of implementing this C# interface is that it allows things to be sortable.  This doesn't work here
        //because I think the implementation is screweed up, but see http://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx
        public class Temperature : IComparable 
        {
            public int Fahrenheit { get; set; }

            // The temperature value 
            protected int temperatureF;

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Temperature otherTemperature = obj as Temperature;
                if (otherTemperature != null)
                    return this.temperatureF.CompareTo(otherTemperature.temperatureF);
                else
                    throw new ArgumentException("Object is not a Temperature");
            }
        }
        static void Main(string[] args)
        {
            
         


            //This is where we'll create an instance of our service and tell it to run.
            ServiceBase.Run(new Program());




            //IComparable shit - turns out that the big benefit of implementing this C# interface is that it allows things to be sortable.  This doesn't work here
            //because I think the implementation is screweed up, but see http://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx
             ArrayList temperatures = new ArrayList();
            //Initialize random number generator.
            Random rnd = new Random();

            // Generate 10 temperatures between 0 and 100 randomly. 
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int degrees = rnd.Next(0, 100);
                Temperature temp = new Temperature();
                temp.Fahrenheit = degrees;
                temperatures.Add(temp);   
            }
      // Sort ArrayList.
      temperatures.Sort();



      foreach (Temperature temp in temperatures)
         Console.WriteLine(temp.Fahrenheit);

      
            Console.ReadKey(); 


            //Dependecy Injection bullshit:
            //http://www.c-sharpcorner.com/UploadFile/dacca2/inversion-of-control-using-unity/
            ////ConsoleTestHackingAround.DependencyInjectionExample1.Client myClient = new DependencyInjectionExample1.Client();
            //ConsoleTestHackingAround.DependencyInjectionExample1.Client myClient = new DependencyInjectionExample1.Client(new DependencyInjectionExample1.Service()) ;
            //myClient.Start();

            //************************************************************************************************************************
            ////this will blow up, becuase the DisplaySalary() method of the Employee class actually depends on a Company, which has not been instantiated.
            //Employee emp = new Employee();
            //emp.DisplaySalary();

            //but this might:
            //Dependency injection by **Property injection**
            IUnityContainer unitycontainer = new UnityContainer();
            //unitycontainer.RegisterType<Company,Company>();
            unitycontainer.RegisterType<DependencyInjectionExample2.Company>();

            DependencyInjectionExample2.Employee emp2 = unitycontainer.Resolve<DependencyInjectionExample2.Employee>();
            emp2.DisplaySalary();

            unitycontainer.RegisterType<DependencyInjectionExample3.Company>();

            DependencyInjectionExample3.Employee emp3 = unitycontainer.Resolve<DependencyInjectionExample3.Employee>();
            emp3.DisplaySalary();          




            //************************************************************************************************************************

            Console.ReadKey(); 


            //----------------------------------------------------------------------------------------
            //Fun with Factory Pattern
            //A factory creates objects. 
            //You can isolate the logic for determining which type of employee class to create
            //Factory.EmployeeFactory factory = new Factory.EmployeeFactory();
            Factory.Position clerk = Factory.EmployeeFactory.Get(1);
            Console.WriteLine("you just newed up a " + clerk.Title + " using a factory pattern");
            //----------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------
            //File stream shit:
            //FileSystemWriter.FunWithFileStreams(); 
            //----------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------
            ////Out shit:    
            //FunWithOut.RunOUT();
            //Console.Read(); 
            //----------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------
            ////Boolean shit:
            //bool[] answers = new bool[3];
            //answers[0] = false;  //no
            //answers[1] = true;  //no
            //answers[2] = false;  //no
            //Console.WriteLine(String.Format("_isWindshieldRepair evaluates to {0}", BooleanFun.AnswerQuestions(answers)));
            //Console.Read(); 
            //----------------------------------------------------------------------------------------


            //----------------------------------------------------------------------------------------
            //Other crap:
            //http://stackoverflow.com/questions/952503/c-sharp-variable-initialization-question
            //int
            int i=0;
            Console.WriteLine("{0}",i);
            //----------------------------------------------------------------------------------------




            //----------------------------------------------------------------------------------------
            //Facade Patterm:
            //http://www.dofactory.com/net/facade-design-pattern
            //fun with facades....
            //Q:  What the heck is a facade supposed to do anyway?
            //A:  According to above: Provide a unified interface to a set of interfaces in a subsystem. 
            //    A Façade defines a higher-level interface that makes the subsystem easier to use.
            //A: from OReilley: Reorganize a system with many subsystems into identifiable layers with single entry points (Façade).  p8
            //   Simplifiy the interface to a complex subsystem      
            //   Facade is an example of a "Structural" type of pattern.  Remember in WhatIKnowAboutOO.txt, there are at least 3 different classes of design patterns.
            //   The aim of this pattern is to provide a simplified interface to a set of complex systems.
            //   The role of the Façade pattern is to provide different high-level views of subsystems whose details are hidden from users. 
            //   **In general, the operations that might be desirable from a user’s perspective could be made up of different selections of parts of the subsystems.**
            //   The term “subsystem” is used here deliberately; we are talking at a higher level than classes
            //   **Subsystem: A class offering detailed operations  - Façade: A class offering a few high-level operations as selections from the subsystems **

                       
            //Facade facade = new Facade();

            //facade.MethodA();
            //facade.MethodB();


            //I suppose it has something to do with better organization - you could get the same effect by not using a facade, but perhaps its not as code efficient.
            //Yes, this is the behavior a Facade is designed to avoid.  (p.94 - o'reilly).  the client’s code does not make reference to the classes of the names of the subsystems;
            //Rather, it only gets access to their operations via the Façade.
            SubSystemTwo subSystem2 = new SubSystemTwo();
            //subSystem2.MethodTwo(); 


            //----------------------------------------------------------------------------------------
            //--Fun with Timers and Windows Services
            // Wait for user
            Console.WriteLine("Writing something to file system:");


            if (args[0] == "steve")
            {
            // Create a timer with a ten second interval. 
            var aTimer = new System.Timers.Timer(2000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;

            }
            else 
            {
                FileSystemWriter.WriteSomething(string.Format("\n this will print one time and then not any more, and myArgs was {0}", args[0]));
            }
            //----------------------------------------------------------------------------------------

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            FileSystemWriter.WriteSomething(string.Format("hello from program.cs - Main[] at {0}", e.SignalTime));
        }
        protected override void OnStart(string[] args)
        {
            string[] myArgs = { "steveZOMBO" };
            //Main(args);
            base.OnStart(myArgs);

            //TODO: place your start code here
            FileSystemWriter.WriteSomething("started");
            Main(myArgs);
        }

        protected override void OnStop()
        {
            base.OnStop();

            //TODO: clean up any variables and stop any threads
            FileSystemWriter.WriteSomething("stopped"); 
        }


    }
}
