using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.Pointroll
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
    }
}
