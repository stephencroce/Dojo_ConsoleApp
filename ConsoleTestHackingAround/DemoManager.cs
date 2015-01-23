using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Microsoft.Practices.Unity;

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
            //IComparable shit - turns out that the big benefit of implementing this C# interface is that it allows things to be sortable.  This doesn't work here
            //because I think the implementation is screweed up, but see http://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx
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
            // Sort ArrayList.
            temperatures.Sort();

            foreach (ConsoleTestHackingAround.IComparableDemo.Temperature temp in temperatures)
                Console.WriteLine(temp.Fahrenheit);

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
            //unitycontainer.RegisterType<Company,Company>();
            unitycontainer.RegisterType<DependencyInjectionExample2.Company>();

            DependencyInjectionExample2.Employee emp2 = unitycontainer.Resolve<DependencyInjectionExample2.Employee>();
            emp2.DisplaySalary();

            unitycontainer.RegisterType<DependencyInjectionExample3.Company>();

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
            Console.WriteLine("END    - Process and Threading Demo:");
            


        }

    }
}
