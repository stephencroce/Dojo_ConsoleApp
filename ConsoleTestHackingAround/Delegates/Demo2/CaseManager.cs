using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization; 

namespace ConsoleTestHackingAround.Delegates.Demo2
{
    //notes:  although you can use delegates to implement an event listener model (see Demo1 folder/namespace), this is another usage pattern for delegates
    //http://www.dotnetperls.com/delegate
    public static class CaseManager
    {
        //here is the magic declaration of this class:
        public delegate string ManageCase(string input);
        

         public static string MakeLowercase(string input)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToLower(input); 
        }
         public static string MakeUppercase(string input)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToUpper(input);
        }
        public  static string MakeTitlecase(string input)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(input);
        }
        public static string ManageTheCase(string input, ManageCase del) 
        {            
            //there apparently are equivalent expressions - i don't really get the semantic differences, or even if they really matter. . .
            //return del(input);
            return del.Invoke(input);
        }

    }
}
