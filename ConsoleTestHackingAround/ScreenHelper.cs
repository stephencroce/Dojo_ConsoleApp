using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround
{
    class ScreenHelper
    {
        public static void Welcome()
        {
            Console.WriteLine("       Welcome to Console Test Hacking Around (CTHA - Cheetah)               ");
        }
        public static void ListOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("Available Commands:");
            Console.WriteLine("");
            Console.WriteLine("1     : Custom Configuration Sections Demo");
            Console.WriteLine("2     : IComparable implementation Demo -(i.e. allowing things to be sortable)");
            Console.WriteLine("3     : Dependency Injection with Unity Demo");
            Console.WriteLine("4     : Factory Pattern Demo");
            Console.WriteLine("5     : FileStream Shit");
            Console.WriteLine("6     : OUT Shit:");
            Console.WriteLine("7     : Boolean Shit");
            Console.WriteLine("8     : Facade Pattern Demo");
            Console.WriteLine("9     : Process and Threading Demo");
            Console.WriteLine("10    : Car Demo");
            Console.WriteLine("11    : Euclid's Algorithm");
            Console.WriteLine("12    : Try a Binary Search Algorithm");     
            Console.WriteLine("EXIT  : Exit Application");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("Please type a command:");
        }
        public static void SignOff()
        {
            Console.WriteLine(String.Format("{0}Program ending.  Thank you for using CHEETAH.", Environment.NewLine));
            Environment.Exit(0);
        }
        public static void WritePrompt()
        {
            Console.Write("Cheetah:>");
        }
        public static void ShowContinuePrompt()
        {
            WritePrompt();
            string[] args = new string[] { "rerun" };
            ConsoleTestHackingAround.StupidAss.Program.Main(args);
        }
    }
}
