using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.Pointroll
{
    public static class PointRollDemo
    {
        public static PointRollCustomClass RunPointRollDemo(string pointRollSucksAss)
        {
            //ToDo: Write a program that counts the number of chars and ints in the string
            //Return a custom object that contains chars and ints

            //string pointRollSucksAss = "P01ntr01l5uck5A55";
            PointRollCustomClass prcc = new PointRollCustomClass();
            int charCount=0;
            int numCount=0;
            int count;
            char[] pointRollSucksArray = pointRollSucksAss.ToCharArray();

            foreach (char suckyChar in pointRollSucksArray)
            {
                bool isItAnInteger = int.TryParse(suckyChar.ToString(), out count);
                if (isItAnInteger == false)
                {
                    // String is not a number.
                    charCount++;
                }
                else
                {
                    numCount++;
                }
            }

            //Console.WriteLine("There are {0} numbers and {1} characters in the string ", intCount, charCount);
            prcc.CharacterCount = charCount;
            prcc.NumberCount = numCount; 
            return prcc;
        }
        public static bool AmIAPalindrome(string input)
        {
            //if(input==input.Reverse())  //someone said this would work.  It's not true.
            //{
            //    Console.WriteLine("it's a palin");
            //}
            


            var inputArray = input.ToCharArray();
            var inputArrayReversed = inputArray.Reverse();
            
            //Stack Overflow:16847894 - How to compare two character arrays for equivalency of element content
            //if(input==inputArrayReversed.ToArray().ToString())
            //{
            //    return true;
            //}
            if (inputArray.SequenceEqual(inputArrayReversed))
            {
                return true;
            }
            return false;
        }
        public static bool AmIAPalindrome2(string input) 
        {
            char[] inputCharArray = input.ToCharArray();
            StringBuilder sbReversed = new StringBuilder();
            for (int i = inputCharArray.Length-1; i >= 0; i--)
            {
                sbReversed.Append(inputCharArray[i]);               

            }
            return input==sbReversed.ToString();
        }
    }
}
