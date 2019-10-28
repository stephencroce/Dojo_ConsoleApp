using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

//The System.Diagnostics.Process class allows you to analyze the processes running on a given machine (local or remote).
//Chapter 17 & 19 of Pro C# 5.0 and the .NET 4.5 Framework, 6th Edition (pdf)
using System.Diagnostics;

namespace Dojo_ConsoleApp.Process
{
    public class ProcessDemo
    {
        public static void VerySlowOperation()
        {

            string[] message = { "this", "is", "a", "very", "slow", "moving", "operation" };

            for (int w = 0; w < message.Length; w++)
            {
                Console.WriteLine(message[w]);
                Thread.Sleep(8000);
            }
            Console.WriteLine("VerySlowOperation() is over now....");
        }

        public static void GetCurrentThread()
        {
            Thread curThread = Thread.CurrentThread;
            AppDomain appDomain = Thread.GetDomain();
            curThread.Name = "steve was here";

            for (int i = 0; i < 10;i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine("this threads name is: {0} and its domain name is : {1}, and the current context is: {2}", curThread.Name, appDomain, Thread.CurrentContext); 
            }
            
            Console.WriteLine("Abort this?");  //this, as you might think, bombs out the program. It'll try to launch a debgger which will point tothis line.
            if (Console.ReadLine().ToLower() == "y")
            {
                curThread.Abort();
            }
            Console.WriteLine("GetCurrentThread() is over now....");
        }

        public static void ListAllRunningProcesses()
        {
            // Get all the processes on the local machine, ordered by   
            // PID.   
            var runningProcs = from proc in System.Diagnostics.Process.GetProcesses(".") orderby proc.Id select proc;
            // Print out PID and name of each process.   
            foreach (var p in runningProcs)
            {
                string info = string.Format("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }
        //Investigating a Process’s Thread Set The set of threads is represented by the strongly typed ProcessThreadCollection collection, 
        //which contains some number of individual ProcessThread objects. 
        //To illustrate:  
        public static void EnumThreadsForPid(int pID)
        {
            System.Diagnostics.Process theProc = null;

            try
            {
                theProc = System.Diagnostics.Process.GetProcessById(pID);
            // List out stats for each thread in the specified process.   
            Console.WriteLine("Here are the threads used by: {0}",     theProc.ProcessName);   
            ProcessThreadCollection theThreads = theProc.Threads;  

            foreach (ProcessThread pt in theThreads)
            {
                string info = string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }

    }
}
