using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ConsoleTestHack
{
    public static class TitleCase
    {
        //private static string _unformattedTitle;
        //public static void Main()
        public static void FormatAndWrite(string unformattedTitle)
        {
           

            // Defines the string with mixed casing.
            //string myString = "wAr aNd pEaCe";
            string myString = unformattedTitle;

            // Creates a TextInfo based on the "en-US" culture.
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            // Changes a string to lowercase.
            Console.WriteLine("\"{0}\" to lowercase: {1}", myString, myTI.ToLower(myString));

            // Changes a string to uppercase.
            Console.WriteLine("\"{0}\" to uppercase: {1}", myString, myTI.ToUpper(myString));

            // Changes a string to titlecase.
            Console.WriteLine("\"{0}\" to titlecase: {1}", myString, myTI.ToTitleCase(myString));

        }
    }
}






//using System;
//using System.Globalization;


//public class SamplesTextInfo  {

//   public static void Main()  {

//      // Defines the string with mixed casing.
//      string myString = "wAr aNd pEaCe";

//      // Creates a TextInfo based on the "en-US" culture.
//      TextInfo myTI = new CultureInfo("en-US",false).TextInfo;

//      // Changes a string to lowercase.
//      Console.WriteLine( "\"{0}\" to lowercase: {1}", myString, myTI.ToLower( myString ) );

//      // Changes a string to uppercase.
//      Console.WriteLine( "\"{0}\" to uppercase: {1}", myString, myTI.ToUpper( myString ) );

//      // Changes a string to titlecase.
//      Console.WriteLine( "\"{0}\" to titlecase: {1}", myString, myTI.ToTitleCase( myString ) );

//   }

//}