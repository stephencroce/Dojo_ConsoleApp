using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Microsoft.Practices.Unity;

using Dojo_ConsoleApp.Demo1.Delegates;
using Dojo_ConsoleApp.Delegates.Demo2;
using Dojo_ConsoleApp.Pointroll;
using Dojo_ConsoleApp.TracingCrap;
using System.Net;
using System.IO;
using Dojo_ConsoleApp.RESTFulCrap;
using System.Data;
using Newtonsoft.Json;
using Dojo_ConsoleApp.MongoCrap;
using System.IO;
using Dojo_ConsoleApp.AlgorithmCrap;

namespace Dojo_ConsoleApp
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
            Dojo_ConsoleApp.CustomConfigSections.MyCustomConfigHandler config = (Dojo_ConsoleApp.CustomConfigSections.MyCustomConfigHandler)System.Configuration.ConfigurationManager.GetSection("pageAppearanceGroup/pageAppearance");

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
                Dojo_ConsoleApp.IComparableDemo.Temperature temp = new Dojo_ConsoleApp.IComparableDemo.Temperature();
                temp.Fahrenheit = degrees;
                temperatures.Add(temp);
            }
            // Sort ArrayList - this is the whole point to IComparable.
            temperatures.Sort();

            foreach (Dojo_ConsoleApp.IComparableDemo.Temperature temp in temperatures)
            {
                Console.WriteLine(temp.Fahrenheit);
                //Console.WriteLine(temp.CompareTo(100);
            }

            Console.WriteLine("END  - IComparable implementation Demo - allowing things to be sortable:");
        }
        public static void RunDependencyInjectionWithUnityDemo()
        {

            Console.WriteLine("BEGIN  - Dependency Injection with Unity Demo:");
            //Dependency Injection bullshit:
            //http://www.c-sharpcorner.com/UploadFile/dacca2/inversion-of-control-using-unity/
            ////Dojo_ConsoleApp.DependencyInjectionExample1.Client myClient = new DependencyInjectionExample1.Client();
            //Dojo_ConsoleApp.DependencyInjectionExample1.Client myClient = new DependencyInjectionExample1.Client(new DependencyInjectionExample1.Service()) ;
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
            Console.WriteLine("Is Purge Enabled???:  {0}", FunWithOut.isPurgeEnabled());
            Console.WriteLine("My app.config setting is {0}", FunWithOut.getAppConfigSetting());
            Console.WriteLine("My app.config setting(2) is {0}", FunWithOut.getAppConfigSetting2());
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
            Dojo_ConsoleApp.Process.ProcessDemo.ListAllRunningProcesses();
            Console.WriteLine("What number process do you want to see threads for?");
            int crap = int.Parse(Console.ReadLine());
            Dojo_ConsoleApp.Process.ProcessDemo.EnumThreadsForPid(crap);  //the monogomergepurge app, which has two threads.

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

            Console.WriteLine("Would you like to see a Delegate example that does crap with upper, lower and title cases? (y/n)");
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
                Console.WriteLine("OK then....Would you like to see a FUNC example? (y/n)");
                answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("enter a first name...");
                    string fn = Console.ReadLine();
                    Console.WriteLine("enter a last name...");
                    string ln = Console.ReadLine();

                    Dojo_ConsoleApp.Delegates.DaFunc.DaFunc BringDaFunk = new Delegates.DaFunc.DaFunc();
                    Console.WriteLine(BringDaFunk.DoDaFunk(fn,ln));

                    return;
                }

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
            Console.WriteLine("F({0}) was " + AlgorithmCrap.Fibonacci.F(stupidNumber), stupidNumber);

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


            //This was one of the stupid puzzles from Dittman Incentive Marketing:
            Console.WriteLine("To see the first ten numbers of the Fibonacci sequence, press enter....");
            Console.ReadLine();

            int startNumber = 1;
            int[] firstTenNubmersOfFibonacciSequece = AlgorithmCrap.Fibonacci.getFirstTenFibonacciSequenceNumbers(startNumber);

            Console.WriteLine(string.Format("Here are first ten numbers of the fibonacci sequence starting at {0}", startNumber));

            foreach (var number in firstTenNubmersOfFibonacciSequece)
            {
                Console.WriteLine(number);
            }

            //Here is the same Dittman puzzle using recursion:
            Console.WriteLine("To see the first ten numbers of the Fibonacci sequence utilizing recursion, press enter....");
            Console.ReadLine();
            AlgorithmCrap.Fibonacci.getFirstTenFibonacciSequenceNumbersUsingRecursion(startNumber);


            //int count = 0;
            //int total = AlgorithmCrap.Fibonacci.Recursive(5, ref count);
            //Console.WriteLine(total);
            //Console.WriteLine(count);



        }
        public static void RunInterfaceDemo()
        {
            Account_Checking acct_chk = new Account_Checking();
            Account_Savings acct_sv = new Account_Savings();
            Console.WriteLine("Here's my Checking Account Info: acct#'{0}' : routing#:'{2}', and here's my Savings Account Info: '{1}'", acct_chk.GetAcctInfo(), acct_sv.GetAcctInfo(), acct_chk.GetABARoutingNo());

            List<Dojo_ConsoleApp.Interfaces.IAccount> Accounts = new List<Dojo_ConsoleApp.Interfaces.IAccount>();
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

            Console.WriteLine("Enter a word.  I will tell you if it's a palindrome");
            string entry = Console.ReadLine();
            if (PointRollDemo.AmIAPalindrome(entry))
            {
                Console.WriteLine("Yes! - that word is a palindrome!");
            }
            else
            {
                Console.WriteLine("NO! - that word is NOT a palindrome!");
            }

            Console.WriteLine(PointRollDemo.AmIAPalindrome2(entry) ? "Hell YES!!!" : "NOPE! No way.");

        }
        public static void RunTracingAndLoggingDemo()
        {
            //How often have you been in a project and you wanted to create a simple log file to log out errors and, if debugging an annoying error, parameter and variable values?
            //To get started in the simplest way, all you need to do is to update the config file to include the System.Diagnostics section and then update the code you want to log out the information that you want.
            //Everything used here lives in the System.Diagnostics .NET namespace:

            //System.Diagnostics.TraceSource traceSource = new System.Diagnostics.TraceSource("MyFirstLoggingSource");
            //System.Diagnostics.TraceListenerCollection traceListenerCollection = traceSource.Listeners;
            MyTraceSource traceSource = new MyTraceSource("MyFirstLoggingSource");
            System.Diagnostics.TraceListenerCollection traceListenerCollection = traceSource.Listeners;

            //Console.WriteLine(traceListenerCollection[i].Attributes);
            // Get the custom attributes for the TraceSource.
            Console.WriteLine("Number of custom trace source attributes = " + traceSource.Attributes.Count);

            foreach (DictionaryEntry de in traceSource.Attributes)
            {
                Console.WriteLine("Custom trace source attribute = " + de.Key + "  " + de.Value);
            }

            int expires = int.Parse(traceSource.Attributes["expires"]);

            Console.WriteLine(String.Format("The default setting is {0} days.", expires));


            Console.WriteLine("Do you want to see all of the System.Diagnostic tracing listeners defined in app config? (Y/N)");
            var response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            {

                for (int i = 0; i <= traceListenerCollection.Count - 1; i++)
                {
                    Console.WriteLine(traceListenerCollection[i].Name);
                }
            }
            else { Console.WriteLine("Fine, I didn't want to show you anyway."); }


            //PROB:  supposed to write a file into the path \Dojo_ConsoleApp\bin\Debug\MyFirstListener.log.   the file gets created, but there's nothing the fuck in it. - WTF???
            //SOLUTION: "You may have noticed that I'm calling the Flush() and Close() methods on the TraceSource object. This is done to make sure the file gets written to and is closed properly."
            //"If you aren't getting everything written to your listener, these calls may be all that's needed. However, I've seen cases where it's not always required."
            traceSource.TraceData(System.Diagnostics.TraceEventType.Verbose, 1, "This is a log entry.  Whooppdeee doo.");  //NOTE-if it specifies TraceEventType.Verbose here in the code, it must also specify VERBOSE in app.config, or it won't write to file.
            traceSource.TraceInformation(string.Format("This is written on {0} by a call from traceSource.TraceInformation, which is supposed to write an informative message.  hoo fucking ray.", DateTime.Now));
            traceSource.Flush();
            traceSource.Close();


            //Q:  what happens if you try to trace to a source not defined in app.config.  
            //A:  Probably nothing good - and I'd be right:
            System.Diagnostics.TraceSource traceSourceCrap = new System.Diagnostics.TraceSource("CrapolaSource");
            traceSourceCrap.TraceInformation("This is utter crap, and won't show up anywhere because it isn't defined in the app.config.  It will fail silently, however.");


            //Now, what if I wanted to not log to a crappy text file, but instead wanted to use a crappy database like Mongo?  Well, I'd have to set that up in app.config also:
            //HMMMMMMMMMMMMMMMMMMMMMMMM
        }
        public static void RunRESTfulCrapDemo()
        {
            //One Way:
            Console.WriteLine("First example:  talk to the raritan pointe website");
            Console.ReadKey();
            try
            {
                string strUrl = "http://www.raritanpointe.org";
                //string strUrl = "http://ntsvr41v4:6405/biprws/logon/long";
                RESTFulHTTPHelper.MakeBasicHttpRequest(strUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.  Message was {0}", ex.Message);
            }
            Console.WriteLine("press enter to continue to the next example....");
            Console.ReadKey();
            Console.WriteLine("do the same thing via a different set of mechanics - talk to 'del.icio.us' where i posted as ZanaizbarBukBukMcFate...");
            Console.ReadKey();
            //Another Way:
            try
            {
                //The DELICIOUS web site communicates with clients through HTTP, but the web service uses secure HTTPS.
                Uri uri = new Uri("https://api.del.icio.us/v1/posts/recent");
                RESTFulHTTPHelper.MakeDeliciousRESTFULRequest("ZanizbarBukBuk", "ZanzibarBukBukMcFate2015~", uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.  Message was {0}", ex.Message);
            }
            RESTFulHTTPHelper.DeserializeADataSet();
            try
            {
                RESTFulHTTPHelper.GetDriverCareDocumentList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("You tried to talk to the SAP Server at CEI, but it couldn't be done because {0}", ex.Message);
            }
            Console.WriteLine("press enter to continue to the next example....");
            Console.ReadKey();
            Console.WriteLine("enter a valid url to some website:  This uses the GetHtml() method from CEI shared, which I think is just a restful request similar to all the other crap here.");
            String websiteUrl = Console.ReadLine();
            try
            {
                Console.WriteLine("Press enter to get the html from the page you requested....");
                Console.ReadKey();
                Console.Write(RESTFulCrap.RESTFulHTTPHelper.GetHTML(websiteUrl));
            }
            catch (Exception ex)
            {
                Console.WriteLine("You tried to talk to {0}, but it couldn't be done because {1}", websiteUrl, ex.Message);
            }
            Console.WriteLine("press enter to continue to the next example....");
            Console.ReadKey();
            Console.WriteLine("Press enter to queue a build on CEI's TFS 2015 server using TFS2015's restful api:");
            Console.ReadKey();
            try
            {
                RESTFulCrap.RESTFulHTTPHelper.QueueTFSBuild();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something blew up when trying to talk to TFS.  Sorry.  {0}", ex.Message);
            }
            Console.ReadKey();
            Console.WriteLine("End of RESTful Crap Demo");
            Console.ReadKey();
        }
        public static void RunLoopingDemo()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("looping");
            }
        }
        public static void RunAsycCrapDemo()
        {
            string filePath = @"C:\Temp\CorporateIpsum.txt";

            Console.WriteLine("this will simulate a long running process such as the reading a big text file - (or imagine something stupid like that) -  using plain ol' SYNCronous messaging, which is the default programming approach in C# .NET, and in fact in most languages. - OK???");
            Console.ReadKey();
            Console.WriteLine("\n Start Sync!");
            Console.WriteLine(Dojo_ConsoleApp.AsyncMessaging.AsyncCrap.LogReadRegularOldSynchWay(filePath));
            Console.WriteLine("\n Done Sync!");
            Console.WriteLine("\n now, this will simulate a long running process such as the stupid thing referenced above, but using ASYNC.  OK???");
            Console.ReadKey();
            Console.WriteLine("\n Start Async!");
            Console.WriteLine(Dojo_ConsoleApp.AsyncMessaging.AsyncCrap.LogReadAsync(filePath));
            Console.WriteLine("\n Done Async!");
            //RunLoopingDemo();      
            //Console.ReadKey();
        }
        public static void RunRegexCrapDemo()
        {
            Console.WriteLine("enter this phone number:  '800) 531-8669'");
            var crappyPhoneNumber = Console.ReadLine().ToString();
            Console.WriteLine("the fixed phone number looks like this: {0}", Dojo_ConsoleApp.RegexCrap.RegexCrap.FixPhoneNumber(crappyPhoneNumber));
        }
        public static void RunBitWiseDemo()
        {
            //Purpose: to get your head around the contrast between logical AND OR (&&  ||) comparisons and bitwise AND OR (& |) comparisons.
            //http://www.codeproject.com/Articles/544990/Understand-how-bitwise-operators-work-Csharp-and-V
            //https://en.wikipedia.org/wiki/Bitwise_operation
            //http://www.binaryhexconverter.com/decimal-to-binary-converter
            //http://stackoverflow.com/questions/7331686/why-and-not
            Console.WriteLine("this is an example of bitwise comparison - the single '&' or the single '|' operator - this is why you have to use '&&'  '||', because it means something different");
            Console.WriteLine("V for Villanova and, also: {0}", 1 & 2);
            Console.WriteLine("V for Victory, also: {0}", 2 & 2);
            Console.WriteLine("B for Blue, also: {0}", 3 & 2);
            Console.WriteLine("W for White, also: {0}", 1 & 1);
            Console.WriteLine("The Blue and the White, and also: {0}", 1 & 0);
            Console.WriteLine("We will fight fight fight fight, and also: {0}", 0 & 1);
            Console.WriteLine("Fight for Villanova, and also: {0}", 0 & 0);
            Console.WriteLine("Fight for Victory, and also: {0}", 123 & 321);
            Console.WriteLine("da da da da da da and also {0}", 10 & 11);
            Console.ReadKey();
        }
        public static void RunSMSTextingDemo()
        {
            Textler textler = new Textler();
            //textler.SendSMSTextBasic();
            textler.SendSMSViaTwilio();
        }
        public static void RunMONGODemo()
        {
            MongoUtility.SeedOrUnseed();
        }
        public static void RunSTOCKSDemo()
        {
            //sources consulted:
            //http://stackoverflow.com/questions/3653970/minimum-value-in-dictionary-using-linq
            //http://stackoverflow.com/questions/3066182/convert-an-iorderedenumerablekeyvaluepairstring-int-into-a-dictionarystrin
            //http://stackoverflow.com/questions/2807461/c-sort-dictionary-in-descending-order

            Console.WriteLine("Wanna see when you should have bought Google?  ");
            Console.ReadKey();

            Stock googleStockDictionary = new Stock();

            var lowKey = googleStockDictionary.StockData.OrderBy(kvp => int.Parse(kvp.Value)).First().Key;
            var lowVal = googleStockDictionary.StockData.OrderBy(kvp => int.Parse(kvp.Value)).First().Value;

            var hiKey = googleStockDictionary.StockData.OrderByDescending(kvp => int.Parse(kvp.Value)).First().Key;
            var hiVal = googleStockDictionary.StockData.OrderByDescending(kvp => int.Parse(kvp.Value)).First().Value;

            Console.WriteLine(string.Format("If you were smart, you would have bought google stock at time interval {0} for ${1} and sold it at time interval {2} for ${3}.", lowKey, lowVal, hiKey, hiVal));
        }
        public static void RunFileNameCompareDemo()
        {

            //this is a program written for CEI to compare file names in two separate directories, separating out which ones aren't in the other one.
            string htmlNamePath = "C:\\Compare\\html";
            string pdfNamePath = "C:\\Compare\\pdf";
            string filePath = "C:\\Compare\\final.txt";

            List<string> missingPdfClaimIdList = new List<string>();

            string[] htmlPaths = Directory.GetFiles(htmlNamePath);
            string[] pdfPaths = Directory.GetFiles(pdfNamePath);

            List<string> htmlFileClaimIdList = new List<string>();
            List<string> pdfFileClaimIdList = new List<string>();

            int countOfTheMissing = 0;


            for (int h = 0; h <= htmlPaths.Length - 1; h++)
            {
                htmlFileClaimIdList.Add(Path.GetFileNameWithoutExtension(htmlPaths[h]).Substring((Path.GetFileNameWithoutExtension(htmlPaths[h]).IndexOf("_") + 1), 7));
            }
            for (int p = 0; p <= pdfPaths.Length - 1; p++)
            {
                pdfFileClaimIdList.Add(Path.GetFileNameWithoutExtension(pdfPaths[p]).Substring((Path.GetFileNameWithoutExtension(pdfPaths[p]).IndexOf("_") + 1), 7));
            }

            foreach (string htmlFileClaimId in htmlFileClaimIdList)
            {
                if (!pdfFileClaimIdList.Contains(htmlFileClaimId))
                {
                    missingPdfClaimIdList.Add(htmlFileClaimId);
                    countOfTheMissing++;
                }

            }
            Console.WriteLine(string.Format("Here are the {0} missing claimids:", countOfTheMissing));

            //wait a sec..
            Console.ReadKey();

            //now write to screen:
            foreach (string missingClaimId in missingPdfClaimIdList)
            {
                Console.WriteLine(missingClaimId);
            }

            //write to file
            File.WriteAllLines(filePath, missingPdfClaimIdList);


            //routine that separates out the missing ones:
            foreach (string htmlPath in htmlPaths)
            {
                foreach (string missingClaimId in missingPdfClaimIdList)
                {
                    if (htmlPath.Contains(missingClaimId))
                    {
                        try
                        {
                            File.Copy(htmlPath, htmlPath.Replace("Compare\\html", "Compare2\\missing"));
                        }
                        catch (Exception ex)
                        { }
                        finally
                        { }

                    }
                }
            }

        }
        public static void RunAmazonCrap()
        {
            //Amazon test id taken 5/10/2017 was 23280666931046
            //https://takeamcat2.aspiringminds.com/testCenter.php?mode=f
            //consider edge cases - handle large inputs effectively    

            Console.WriteLine("Amazon Crap Begin");
            Console.WriteLine("Bohmmm Bohmmmmm.....");

            //test cases  
            var amazonTestCaseList = new List<AlgorithmCrap.AlgorithmCrap.AmazonTestCase>();
            int counter = 1;

            AlgorithmCrap.AlgorithmCrap.AmazonTestCase atc1 = new AlgorithmCrap.AlgorithmCrap.AmazonTestCase();
            atc1.blockArray = new string[] { "5", "-2", "4", "z", "x", "9", "+", "+" };
            atc1.n = 8;
            amazonTestCaseList.Add(atc1);
            //output should be 27

            AlgorithmCrap.AlgorithmCrap.AmazonTestCase atc2 = new AlgorithmCrap.AlgorithmCrap.AmazonTestCase();
            atc2.blockArray = new string[] { "1", "2", "+", "Z" };
            atc2.n = 4;
            amazonTestCaseList.Add(atc2);
            //output should be 3

            foreach (var amazonTestCase in amazonTestCaseList)
            {
                //Console.WriteLine("the score is" + AlgorithmCrap.AlgorithmCrap.AmazonTotalScore(blocks, n));
                Console.WriteLine("the score for test case #{0} is " + AlgorithmCrap.AlgorithmCrap.AmazonTotalScore(amazonTestCase.blockArray, amazonTestCase.n), counter);
                counter++;
            }


            //int[] states = {1, 0, 1, 0, 1, 0, 1, 0};
            //int[] states = { 1, 1, 1, 0, 1, 0, 0, 0 };
            //int[] states = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] states = { 1, 1, 1, 1, 1, 1, 1, 1 };

            int days = 6;

            var moreAmazonCrap = new MoreAmazonCrap();
            List<int> completedCellState = moreAmazonCrap.CellCompete(states, days);            
            Console.WriteLine(string.Format("Final:  At the end of {0} days, the completed cell state was: ", days));
            foreach(int cellValue in completedCellState)
            {
                Console.WriteLine(cellValue);
            }


            Console.WriteLine("Chick-ah chick ahhhhhhhhhhhhhhhhhh");

            Console.WriteLine("Amazon Crap End");

        }
        public static void RunQuoraPuzzler()
        {
            AlgorithmCrap.AlgorithmCrap.QuoraPuzzler();
        }
        public static void RunLeetCodeShit()
        {
            AlgorithmCrap.LeetCode.BinaryTree.DoLeetCodeBinaryTreeCrap();             
        }
        public static void RunLongestCommonSubstringAlgorithmDemo() {

            //POC for UDCOP2-333
            Console.WriteLine("Nope, this probably aint gonna work......");

            //try filtering out coupon syntax ie: [X] and vertical bar syntax i.e. |


             // Function calls
             String[] graceArr = { "grace", "graceful", "disgraceful", "gracefully" };    
             String graceStem = AlgorithmCrap.AlgorithmCrap.findstem(graceArr);
             Console.WriteLine("The stem is : " + graceStem);
            List<string> tempList = new List<string>();

            String[] layerStructureArray = { 
                    "EML: [A] HM203:GD2036 10% 400Å [B] HM203:GD2036 12% 400Å [C] HM203:GD2036 15% 400Å || HIL: LG101 100Å | HTL: HHT44 400Å | EBL: H355 50Å | ETL: Liq:NTU66 35% 350Å | EIL: Liq 10Å | Cath: Al 1000Å"
                  , "EML: [A] HM203:GD2036 10% 400Å [B] HM203:GD2036 12% 400Å [C] HM203:GD2036 15% 400Å || HIL: LG101 100Å | HTL: HHT44 400Å | EBL: H355 50Å | ETL: Liq:NTU66 35% 350Å | EIL: Liq 10Å | Cath: Al 1000Å"
                  , "EML: [A] HM203:GD2036 10% 400Å [B] HM203:GD2036 12% 400Å [C] HM203:GD2036 15% 400Å || HIL: LG101 100Å | HTL: HHT44 400Å | EBL: H355 50Å | ETL: Liq:NTU66 35% 350Å | EIL: Liq 10Å | Cath: Al 1000Å"
                  , "EML: [A] HM203:GD990 10% 400Å [B] HM203:GD990 12% 400Å [C] HM203:GD990 15% 400Å || HIL: LG101 100Å | HTL: HHT44 400Å | EBL: H355 50Å | ETL: Liq:NTU66 35% 350Å | EIL: Liq 10Å | Cath: Al 1000Å"
                  , "EML: [A] HM203:GD990 10% 400Å [B] HM203:GD990 12% 400Å [C] HM203:GD990 15% 400Å || HIL: LG101 100Å | HTL: HHT44 400Å | EBL: H355 50Å | ETL: Liq:NTU66 35% 350Å | EIL: Liq 10Å | Cath: Al 1000Å"
                  , "EML: [A] HM203:GD990 10% 400Å [B] HM203:GD990 12% 400Å [C] HM203:GD990 15% 400Å || HIL: LG101 100Å | HTL: HHT44 400Å | EBL: H355 50Å | ETL: Liq:NTU66 35% 350Å | EIL: Liq 10Å | Cath: Al 1000Å"
             };


            Console.WriteLine("BEFORE:  ");
            foreach (string layerStructure in layerStructureArray)
            {
 
                Console.WriteLine(layerStructure);
            }
       

            String layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(layerStructureArray);
            Console.WriteLine("the stem is : " + layerStructureStem);

            Console.WriteLine("AFTER:  ");
            //string[] newLayerStructureArray = { };

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in layerStructureArray)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);                    
                }
            }

       
            string[] tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER2:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER3:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : "  +layerStructureStem);
            Console.WriteLine("AFTER4:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER5:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER6:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER7:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER8:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER9:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }

            tempArr = tempList.ToArray();
            layerStructureStem = AlgorithmCrap.AlgorithmCrap.findstem(tempArr);
            Console.WriteLine("the new stem is : " + layerStructureStem);
            Console.WriteLine("AFTER10:  ");
            tempList.Clear();

            if (layerStructureStem != string.Empty)
            {
                foreach (string layerStructure in tempArr)
                {
                    string newLayerStructure = layerStructure.Replace(layerStructure.Substring(layerStructure.IndexOf(layerStructureStem), layerStructureStem.Length), string.Empty);
                    Console.WriteLine(newLayerStructure);
                    tempList.Add(newLayerStructure);
                }
            }


        }
    }
}
