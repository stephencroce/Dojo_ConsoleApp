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

using System.Configuration;

//using ConsoleTestHackingAround.CustomConfigSections;

using ConsoleTestHackingAround.CustomConfigSections;


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
        public static void Main(string[] args)
        {

            //This is where we'll create an instance of our service and tell it to run.
            ServiceBase.Run(new Program());

            if (args.Length != 0)
            {
                if (args[0] == "steveZOMBO")
                {
                   //Console.WriteLine("BEGIN  - Windows Service Timer Demo:");
                    FileSystemWriter.WriteSomething("BEGIN  - Windows Service Timer Demo:");
                    //--Fun with Timers and Windows Services
                    // Wait for user
                    //Console.WriteLine("Writing something to file system:");
                    // Create a timer with a ten second interval. 
                    var aTimer = new System.Timers.Timer(2000);

                    // Hook up the Elapsed event for the timer. 
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Enabled = true;

                   // Console.WriteLine("END  - Windows Service Timer Demo:");
                    FileSystemWriter.WriteSomething("END  - Windows Service Timer Demo:");

                }
                else
                {
                    FileSystemWriter.WriteSomething(string.Format("\n this will print one time and then not any more, and myArgs was {0}", args[0]));
                }
            }
            else
            {
                //----------------------------------------------------------------------------------------
                ScreenHelper.Welcome();
                ScreenHelper.ListOptions();

                while (true)
                {
                    //ScreenHelper.WritePrompt();
                    var userResponse = Console.ReadLine();
                    CommandManager.ParseCommand(userResponse);
                }


                //----------------------------------------------------------------------------------------
                //Variable Initialization crap:
                //http://stackoverflow.com/questions/952503/c-sharp-variable-initialization-question
                //int
                int i = 0;
                Console.WriteLine("{0}", i);
                //----------------------------------------------------------------------------------------




            }

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            FileSystemWriter.WriteSomething(string.Format("hello from program.cs - Main[] at {0}", e.SignalTime));
        }
        protected override void OnStart(string[] args)
        {
            //System.Threading.Thread.Sleep(10000);
            //Windows svc start code:
            System.Diagnostics.Debugger.Launch();  
 
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
