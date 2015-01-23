using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace ConsoleTestHackingAround.Process
{
    public class ProcessDemo
    {
        public static void ListAllRunningProcesses() {   
            // Get all the processes on the local machine, ordered by   
            // PID.   
            var runningProcs = from proc in System.Diagnostics.Process.GetProcesses(".") orderby proc.Id select proc;  
           // Print out PID and name of each process.   
            foreach(var p in runningProcs)   
            {     
                string info = string.Format("-> PID: {0}\tName: {1}",       p.Id, p.ProcessName);     
                Console.WriteLine(info);  
            }   
            Console.WriteLine("************************************\n"); } 
    }
}
