using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Microsoft.Practices.Unity;

using ConsoleTestHackingAround.Demo1.Delegates;
using ConsoleTestHackingAround.Delegates.Demo2;
using ConsoleTestHackingAround.Pointroll;

namespace ConsoleTestHackingAround
{
    public static class DemoManager
    {
        public static void RunCustomConfigSectionsDemo()
        {
            Console.WriteLine("Begin - Custom Configuration Sections Demo:");

            //Hey, here's an example of how to use custom configuration elements in a console application.  Isn't that fucking great?
            //See http://stackoverflow.com/questions/19095215/configurationmanager-getsection-gives-error-could-not-load-type-from-assembl
            //See http://msdn.microsoft.com/en-us/library/2tw134k3%28v=vs.140%29.aspx
            // Samples.AspNet.PageAppearanceSection config = (Samples.AspNet.PageAppearanceSection)System.Configuration.ConfigurationManager.GetSection("pageAppearanceGroup/pageAppearance");
            ConsoleTestHackingAround.CustomConfigSections.MyCustomConfigHandler config = (ConsoleTestHackingAround.CustomConfigSections.MyCustomConfigHandler)System.Configuration.ConfigurationManager.GetSection("pageAppearanceGroup/pageAppearance");

            Console.WriteLine("Settings in the PageAppears Section are as follows:");
            Console.WriteLine(string.Format("RemoteOnly:  {0}", config.RemoteOnly));
            Console.WriteLine(string.Format("Font name & size ::  name-{0}   size-{1}", config.Font.Name, config.Font.Size));
            Console.WriteLine(string.Format("Background and foreground color ::  bacground-{0}    foregrouund-{1}", config.Color.Background, config.Color.Foreground));
            Console.WriteLine(string.Format("Mama always said stupid is as stupid does, {0}", config.Stupid.idiot));


            //..and here's another example:  http://manyrootsofallevilrants.blogspot.com/2011/07/nested-custom-configuration-collections.html
            SSHTunnelWF.TunnelSection tunnels = ConfigurationManager.GetSection("TunnelSection") as SSHTunnelWF.TunnelSection;

            //nope:
            //foreach (var tunnel in tunnels)
            //{ }

            //MonkeyAroundNamespace.MongoDatastoresSection mongos = ConfigurationManager.GetSection("MongoDataStores") as MonkeyAroundNamespace.MongoDatastoresSection;
            //var test = mongos.ElementInformation.Properties.Keys.;

            //nope:
            //foreach (var mongo in mongos) 
            //{        
            //}

            //http://stackoverflow.com/questions/3935331/how-to-implement-a-configurationsection-with-a-configurationelementcollection
            MonkeyAroundNamespace2.ServiceConfigurationSection serviceConfigSection = ConfigurationManager.GetSection("ServicesSection") as MonkeyAroundNamespace2.ServiceConfigurationSection;
            MonkeyAroundNamespace2.ServiceConfig serviceConfig = serviceConfigSection.Services[0];

            Console.WriteLine("here are the elements");
            for (int w = 0; w < serviceConfigSection.Services.Count; w++)
            {
                Console.WriteLine("port:" + serviceConfigSection.Services[w].Port);
                Console.WriteLine("report type:" + serviceConfigSection.Services[w].ReportType);
            }


            //http://stackoverflow.com/questions/3935331/how-to-implement-a-configurationsection-with-a-configurationelementcollection
            MonkeyAroundNamespace3.MongoDatastoreConfigSection mongoDatastoreConfigSection = ConfigurationManager.GetSection("MongoDatastoreConfigSection") as MonkeyAroundNamespace3.MongoDatastoreConfigSection;
            // MonkeyAroundNamespace3.MongoDatastoreCongfigSection mongoDatastoreConfigSection = ConfigurationManager.GetSection("MongoDatastoreConfigSection") as MonkeyAroundNamespace3.MongoDatastoreCongfigSection;
            MonkeyAroundNamespace3.mongoDatastore mongoDataStore = mongoDatastoreConfigSection.MongoDatastores[0];


            Console.WriteLine("...and here are more elements");
            for (int y = 0; y < mongoDatastoreConfigSection.MongoDatastores.Count; y++)
            {
                //Console.WriteLine("port:" + mongoDatastoreConfigSection.MongoDatastores[y].Port);
                //Console.WriteLine("report type:" + mongoDatastoreConfigSection.MongoDatastores[y].ReportType);
                Console.WriteLine("AppSubsysId:" + mongoDatastoreConfigSection.MongoDatastores[y].AppSubsysId);
                Console.WriteLine("CollectionName:" + mongoDatastoreConfigSection.MongoDatastores[y].CollectionName);
                Console.WriteLine("DBLocation:" + mongoDatastoreConfigSection.MongoDatastores[y].DBLocation);
                Console.WriteLine("DBName:" + mongoDatastoreConfigSection.MongoDatastores[y].DBName);
            }

            

            Console.WriteLine("END - Custom Configuration Sections Demo:");
        }

        public static void RunIComparableDemo()
        {
            Console.WriteLine("BEGIN  - IComparable implementation Demo - allowing things to be sortable:");

            ArrayList temperatures = new ArrayList();
            //Initialize random number generator.
            Random rnd = new Random();

            // Generate 10 temperatures between 0 and 100 randomly. 
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int degrees = rnd.Next(0, 100);
                ConsoleTestHackingAround.IComparableDemo.Temperature temp = new ConsoleTestHackingAround.IComparableDemo.Temperature();
                temp.Fahrenheit = degrees;
                temperatures.Add(temp);
            }
            // Sort ArrayList - this is the whole point to IComparable.
            temperatures.Sort();

            foreach (ConsoleTestHackingAround.IComparableDemo.Temperature temp in temperatures)
            {
                Console.WriteLine(temp.Fahrenheit);
                //Console.WriteLine(temp.CompareTo(100);
            }

            Console.WriteLine("END  - IComparable implementation Demo - allowing things to be sortable:");
        }
        public static void RunDependencyInjectionWithUnityDemo()
        {

            Console.WriteLine("BEGIN  - Dependency Injection with Unity Demo:");
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
            
            unitycontainer.RegisterType<DependencyInjectionExample2.Company>();
            unitycontainer.RegisterType<DependencyInjectionExample3.Company>();


            DependencyInjectionExample2.Employee emp2 = unitycontainer.Resolve<DependencyInjectionExample2.Employee>();
            //var emp2 = new DependencyInjectionExample2.Employee();
            emp2.DisplaySalary();

            

            DependencyInjectionExample3.Employee emp3 = unitycontainer.Resolve<DependencyInjectionExample3.Employee>();
            emp3.DisplaySalary();

            //************************************************************************************************************************
            Console.WriteLine("END  - Dependency Injection with Unity Demo:");

        }
        public static void RunFactoryPatternDemo()
        {

            Console.WriteLine("BEGIN  - Factory Pattern Demo:");

            //----------------------------------------------------------------------------------------
            //Fun with Factory Pattern
            //A factory creates objects. 
            //You can isolate the logic for determining which type of employee class to create
            //Factory.EmployeeFactory factory = new Factory.EmployeeFactory();
            Factory.Position clerk = Factory.EmployeeFactory.Get(1);
            Console.WriteLine("you just newed up a " + clerk.Title + " using a factory pattern");
            Console.WriteLine("END  - Factory Pattern Demo:");

        }
        public static void RunFileStreamDemo()
        {
            Console.WriteLine("BEGIN  - FileStream shit:");
            //----------------------------------------------------------------------------------------

            //----------------------------------------------------------------------------------------
            //File stream shit:
            FileSystemWriter.FunWithFileStreams();
            //----------------------------------------------------------------------------------------
            Console.WriteLine("END  - FileStream shit:");
        }
        public static void RunOUTDemo()
        {
            //----------------------------------------------------------------------------------------  
            Console.WriteLine("BEGIN  - OUT shit:");
            ////Out shit:    
            FunWithOut.RunOUT();
            Console.ReadLine(); 
            FunWithOut.BooleanTryParse();
            Console.WriteLine("Is Purge Enabled???:  {0}",FunWithOut.isPurgeEnabled()); 
            Console.WriteLine("END  - OUT shit:");

            //----------------------------------------------------------------------------------------
        }
        public static void RunBooleanDemo()
        {

            //----------------------------------------------------------------------------------------
            Console.WriteLine("BEGIN  - Boolean shit:");
            //Boolean shit:
            bool[] answers = new bool[3];
            answers[0] = false;  //no
            answers[1] = true;  //no
            answers[2] = false;  //no
            Console.WriteLine(String.Format("_isWindshieldRepair evaluates to {0}", BooleanFun.AnswerQuestions(answers)));
            Console.WriteLine("END  - Boolean shit:");
            Console.Read();
            //----------------------------------------------------------------------------------------
        }
        public static void RunFacadePatternDemo()
        {
            Console.WriteLine("START  - Facade Pattern Demo:");
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

            Console.WriteLine("END  - Facade Pattern Demo:");

        }
        public static void RunProcessAndThreadingDemo()
        {

            //----------------------------------------------------------------------------------------
            Console.WriteLine("BEGIN  - Process and Threading Demo:");
            ConsoleTestHackingAround.Process.ProcessDemo.ListAllRunningProcesses();
            Console.WriteLine("What number process do you want to see threads for?");
            int crap = int.Parse(Console.ReadLine());
            ConsoleTestHackingAround.Process.ProcessDemo.EnumThreadsForPid(crap);  //the monogomergepurge app, which has two threads.

            //<<<<<<  SIMPLE MULTITHREAD EXAMPLE   >>>>>
            //See also p714 of Pro C# 5.0 and the .NET 4.5 Framework, 6th Edition

            ////Run it in the same thread, you'll see that ProcessDemo.GetCurrentThread() has to wait untill VerySlowOperation is done.  But not if you do multithreading!!!!!!!
            //Process.ProcessDemo.VerySlowOperation();

            //run async - ie. spawn a new thread to hopefully improve perfromance?
            System.Threading.Thread newThreadSpawn = new System.Threading.Thread(Process.ProcessDemo.VerySlowOperation);
            newThreadSpawn.Start();

            Process.ProcessDemo.GetCurrentThread();


            Console.WriteLine("END    - Process and Threading Demo:");

        }
        public static void RunCarDemo()
        {
            //Vehicle myVehicle = new Vehicle(); //Error Cannot create an instance of the abstract class or interface 
            Car myCar = new Car();
            myCar.NumOfPassengers = 2;
            Console.WriteLine("My car goes {0} and carries {1} passengers.", myCar.startEngine(), myCar.NumOfPassengers);

            Dragster myDragster = new Dragster();
            Console.WriteLine("My dragster goes {0}", myDragster.startEngine());
        }
        public static void RunEuclidDemo()
        {
            Console.WriteLine("It's useful to set a breakpoint and step thru this algorithm to think about whats going on here....ok?");
            Console.ReadLine();
            Console.WriteLine("I'm going to tell you the Greatest Common Divisor of two integers.  Enter the first integer:");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second integer:");
            int j = int.Parse(Console.ReadLine());
            int k = AlgorithmCrap.AlgorithmCrap.GreatestCommonDivisor(i, j);
            Console.WriteLine("The greatest common divisor of {0} and {1} is {2}", i, j, k);
        }
        public static void RunBinarySearchDemo()
        {

            int[] myArrayOfStupidAssIntegers = { 6, 5, 1425, 1, 10000, 22, 66, 13, 986, 88, 805, 46 };
            Array.Sort(myArrayOfStupidAssIntegers);
            Console.WriteLine("OK, here is your list of integers, hard coded in a variable that is stored in memory:");
            foreach (int crap in myArrayOfStupidAssIntegers)
            {
                Console.WriteLine(crap);
            }
            Console.WriteLine("Now, enter is some integer, and I'll tell you if it's in that array....");
            int key = int.Parse(Console.ReadLine());
            if (AlgorithmCrap.AlgorithmCrap.Rank(key, myArrayOfStupidAssIntegers) == -1)
            {
                Console.WriteLine("No, Sorry - It ain't in there.");
            }
            else
            {
                Console.WriteLine("You entered: " + key + ". and VIOLA, it's in there!");
            }
            Console.WriteLine("Play again??  (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                RunBinarySearchDemo();
            }
            else
            {
                Console.WriteLine("To generate a stack overflow error, enter the value 2147483648 now:");
                int someInt = int.Parse(Console.ReadLine());
                try
                {
                    Console.WriteLine("By the way, did you know that the value of Math.abs(-{1}) is {0} ?", AlgorithmCrap.AlgorithmCrap.RaiseStackOverflowError(someInt), someInt);
                    int f = 0;
                    int g = 1;
                    for (int i = 0; i <= 15; i++)
                    {
                        Console.WriteLine(f);
                        f = f + g;
                        g = f - g;
                    }
                }
                catch (Exception ex)
                {
                    //this will never get hit, apparently.
                    Console.WriteLine("See what I mean?  The error was {0}", ex.Message);
                }
            }
        }
        public static void RunDelegateDemo()
        {
            //Delegates: Delegates are the basic principle on which events are founded in .NET.  
            //They’re used as a proxy that tells which method or methods to call when an event is “fired”.   
            //In this regard, a delegate can be thought of as a “callback” or in other words, it is a method that can be explicitly defined 
            //which takes another method as an argument, provided that the methods have the same signature. 

            //In this example, when a person presses the doorbell button, a DoorBellRings event is raised.  
            //The dog and the person are each subscribed to that event – that is they “listen” for the doorbell and respond in their respective fashions.

            Doorbell doorbell = new Doorbell();
            doorbell.PressRinger();

            Console.WriteLine("Would you like to see another Delegate example? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                Console.WriteLine("enTeR iN sOme texT, any text, lIke a BOOK or SONG TITLE or some CrAp like that, and try to MEss uP tHe cAse:");
                string text = Console.ReadLine();
                Console.WriteLine("(1) for Lower, (2) for Upper, (3) for Title....");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(CaseManager.ManageTheCase(text, CaseManager.MakeLowercase) + " VIOLA");
                        break;
                    case 2:
                        Console.WriteLine(CaseManager.ManageTheCase(text, CaseManager.MakeUppercase) + " VIOLA");
                        break;
                    case 3:
                        Console.WriteLine(CaseManager.ManageTheCase(text, CaseManager.MakeTitlecase) + " VIOLA");
                        break;
                    default:
                        Console.WriteLine("That wasn't one of the expected numbers.....jackass....");
                        break;
                }
            }
            else
            {
                Console.WriteLine("OK.....jackass....");
            }



        }
        public static void rUntITleCaseDEMO()
        {
            Console.WriteLine("enTeR iN sOme texT, any text, lIke a BOOK or SONG TITLE or some CrAp like that, and try to MEss uP tHe cAse, And WATCH what hAPpeNS....");
            string entry = Console.ReadLine();
            ConsoleTestHack.TitleCase.FormatAndWrite(entry);
        }
        public static void RunFibonacciDemo()
        {
           
            Console.WriteLine("Enter a number from 1-100..");
            int stupidNumber = int.Parse(Console.ReadLine()); 
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Console.WriteLine("F({0}) was " + AlgorithmCrap.Fibonacci.F(stupidNumber),stupidNumber);
          
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            // Format and display the TimeSpan value. 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Progam iterated {2} times :: RunTime for {0} was: {1} ", stupidNumber, elapsedTime, AlgorithmCrap.Fibonacci.getCounter());

            //Console.WriteLine("Total RunTime as of last iteration was: ");


            //Notice that this runs really fast and then hits a wall around interation 40.  HMMMMMMMM................
            //Riddle of the day:  (Sedgewick p 57-58 Ex 1.1.19
            //What is the largest value of N for which this program takes less 1 hour to compute the value of F(N)? 
            //Develop a better implementation of F(N) that saves computed values in an array.


            //TimeSpan ts2;

            //for (int i = 1; i < 100; i++) 
            //{
            //    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //    stopwatch.Start(); 
            //    Console.WriteLine(i + " " + AlgorithmCrap.Fibonacci.F(i));
            //    stopwatch.Stop();
            //    TimeSpan ts = stopwatch.Elapsed;

            //    // Format and display the TimeSpan value. 
            //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //        ts.Hours, ts.Minutes, ts.Seconds,
            //        ts.Milliseconds / 10);
            //    Console.WriteLine("RunTime was: " + elapsedTime);                                         

            //    //Console.WriteLine("Total RunTime as of last iteration was: ");

            //}
        }
        public static void RunInterfaceDemo()
        {
            Account_Checking acct_chk = new Account_Checking();
            Account_Savings acct_sv = new Account_Savings(); 
            Console.WriteLine("Here's my Checking Account Info: acct#'{0}' : routing#:'{2}', and here's my Savings Account Info: '{1}'", acct_chk.GetAcctInfo(), acct_sv.GetAcctInfo(), acct_chk.GetABARoutingNo());

            List<ConsoleTestHackingAround.Interfaces.IAccount> Accounts = new List<ConsoleTestHackingAround.Interfaces.IAccount>();
            Accounts.Add(new Account_Checking());
            Accounts.Add(new Account_Savings());

            foreach (var account in Accounts)
            {
                Console.WriteLine(account.GetAcctInfo());
                Console.WriteLine(account.GetAcctInfo()); 
            }

        }
        public static void RunPointRollDemo()
        {
            ////ToDo: Write a program that counts the number of chars and ints in the string
            ////Return a custom object that contains chars and ints

            ////Here's one way:
            //string pointRollSucksAss = "P01ntr01l5uck5A55";
            //int charCount=0;
            //int intCount=0;
            //char[] pointRollSucksArray = pointRollSucksAss.ToCharArray();

            //foreach(char suckyChar in pointRollSucksArray)
            //{                               
            //    bool isItAnInteger = int.TryParse(suckyChar.ToString(), out intCount);
            //    if (isItAnInteger == false)
            //    {
            //        // String is not a number.
            //        charCount++;
            //    }
            //    else
            //    {
            //        intCount++;
            //    }
            //}

            //Console.WriteLine("There are {0} numbers and {1} characters in the string ",intCount,charCount);

            //Here's another way:   Fuck you pointroll.
            //PointRollCustomClass prcc = PointRollDemo.RunPointRollDemo("P01ntr01l5uck5A5533w");
            PointRollCustomClass prcc = PointRollDemo.RunPointRollDemo("pointrollsucksass");
            Console.WriteLine("There are {0} numbers and {1} characters in the string.  So fuck you, pointroll.  Who the hell needs you anyway. ", prcc.NumberCount, prcc.CharacterCount);

        }

    }
}
