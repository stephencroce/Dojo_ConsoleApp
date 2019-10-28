using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
{
    class FunWithOut
    {
        //http://www.dotnetperls.com/out
        //http://stackoverflow.com/questions/7716641/using-out-keyword-in-c-sharp

        public static void TestString(string value, out bool period, out bool comma, out bool semicolon)
        //public static void TestString(string value, bool period, bool comma, bool semicolon)
        //public static void TestString(string value, ref bool period, ref bool comma, ref bool semicolon)
        {
            period = comma = semicolon = false; // Assign all out parameters to false

            for (int i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case '.':
                        {
                            period = true; // Set out parameter
                            break;
                        }
                    case ',':
                        {
                            comma = true; // Set out parameter
                            break;
                        }
                    case ';':
                        {
                            semicolon = true; // Set out parameter
                            break;
                        }
                }
            }
        }
        public static void RunOUT()
        {
            bool period; // Used as out parameter
            bool comma;
            bool semicolon;
            const string value = "has period, comma."; // Used as input string

            //TestString(value, period, comma, semicolon);
            TestString(value, out period, out comma, out semicolon);
            //TestString(value, ref period, ref comma, ref semicolon);

            Console.WriteLine(value); // Display value
            Console.Write("period: "); // Display labels and bools
            Console.WriteLine(period);
            Console.Write("comma: ");
            Console.WriteLine(comma);
            Console.Write("semicolon: ");
            Console.WriteLine(semicolon);
        }
        public static void BooleanTryParse()
        {
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b); // [1]

            value = "False";
            b = bool.Parse(value);
            Console.WriteLine(b); // [2]

            value = "Perls";
            if (bool.TryParse(value, out b))
            {
                Console.WriteLine("Not reached");
            }

        }
        public static bool isPurgeEnabled()
        {
            bool retVal;
            //if (Boolean.TryParse("stupidhead", out retVal))
            if (Boolean.TryParse("true", out retVal))
            //if (Boolean.TryParse("false", out retVal))
            {
                return retVal;
            }
            return false;
        }
        public static int getAppConfigSetting()
        {
            //this is your basic plain vanilla example pattern that more or less explicitly outlines how TryParse works.  Seen this at places like charp corner or .net pearls.
            string str = "95XOXLPF";  //say this was coming from an app.config file
            int intStr;
            bool intResultTryParse = int.TryParse(str, out intStr);
            if (intResultTryParse == true)
            {
                //Console.WriteLine(String.Format("The string parsed to {0}", intStr));
                return intStr; 
            }
            else
            {
                //Console.WriteLine("Input is not in integer format");
                return 30;

            }
        }
        public static int getAppConfigSetting2()
        {
            //this is a shortened version of the above pattern:
            string str = "95";
            int returnVal = int.TryParse(str, out returnVal) ? returnVal : 30;
            return returnVal; 
        }

    }
}
