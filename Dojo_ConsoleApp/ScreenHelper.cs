using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
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
            Console.WriteLine("13    : Delegates");
            Console.WriteLine("14    : tItLe CAsE dEmO");
            Console.WriteLine("15    : Fibonacci Sequence crap");
            Console.WriteLine("16    : Interface crap");
            Console.WriteLine("17    : Stupidass Pointroll Demo");
            Console.WriteLine("18    : Tracing and Logging Demo");
            Console.WriteLine("19    : RESTful Crap");
            Console.WriteLine("20    : Sync/Async Messaging Crap");
            Console.WriteLine("21    : Regex Crap");
            Console.WriteLine("22    : Bitwise Operators and Flags stuff");
            Console.WriteLine("23    : Send an SMS text programmatically");
            Console.WriteLine("24    : MONGO DB Crap");
            Console.WriteLine("25    : STOCK Crap from Dittman puzzle");
            Console.WriteLine("26    : Compare File Names");
            Console.WriteLine("27    : Amazon Crap");
            Console.WriteLine("28    : Quora Puzzler");
            Console.WriteLine("29    : LeetCode Algorithm Shit");
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
            Dojo_ConsoleApp.StupidAss.Program.Main(args);
        }
    }
}
