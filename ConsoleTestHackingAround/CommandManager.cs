using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround
{
    class CommandManager
    {
        public static void ParseCommand(string response)
        {

            switch (response.ToUpper())
            {
                case "CLS":
                    Console.Clear();
                    break;
                case "1":
                    DemoManager.RunCustomConfigSectionsDemo();                    
                    break;
                case "2":
                    DemoManager.RunIComparableDemo();
                    break;
                case "3":
                    DemoManager.RunDependencyInjectionWithUnityDemo(); 
                    break;
                case "4":
                    DemoManager.RunFactoryPatternDemo(); 
                    break;
                case "5":
                    DemoManager.RunFileStreamDemo(); 
                    break;
                case "6":
                    DemoManager.RunOUTDemo(); 
                    break;
                case "7":
                    DemoManager.RunBooleanDemo(); 
                    break;
                case "8":
                    DemoManager.RunFacadePatternDemo(); 
                    break;
                case "9":
                    DemoManager.RunProcessAndThreadingDemo(); 
                    break;
                case "10":
                    DemoManager.RunCarDemo();
                    break;
                case "11":
                    DemoManager.RunEuclidDemo();              
                    break;
                case "12":
                    DemoManager.RunBinarySearchDemo();
                    break;
                case "13":
                    DemoManager.RunDelegateDemo();
                    break;
                case "14":
                    DemoManager.rUntITleCaseDEMO();
                    break;
                case "15":
                    DemoManager.RunFibonacciDemo();
                    break;
                case "16":
                    DemoManager.RunInterfaceDemo();
                    break;
                case "17":
                    DemoManager.RunPointRollDemo();
                    break;
                case "18":
                    DemoManager.RunTracingAndLoggingDemo();
                    break;
                case "19":
                    DemoManager.RunRESTfulCrapDemo();
                    break;
                case "HELP":
                case "?":
                    ScreenHelper.Welcome();
                    ScreenHelper.ListOptions();
                    break;
                case "EXIT":
                case "X":
                case "Q":
                case "QUIT":
                    ScreenHelper.SignOff();
                    break;
                default:
                    //TestHelper.RunTest(); 
                    Console.WriteLine("Unknown command.");
                    break;
            }
            if (Environment.UserInteractive)
                ScreenHelper.ShowContinuePrompt();
        }
    }
}
