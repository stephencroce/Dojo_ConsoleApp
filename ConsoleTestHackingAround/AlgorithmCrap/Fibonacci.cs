using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.AlgorithmCrap
{
    public class Fibonacci
    {
        private static int _counter = 0;
        private static int _nextNumber = 0;
        private static int _lastNumber = 0;
        //this is recursive
        public static long F(int N)
        {
            _counter = 0;
            if (N == 0) return 0;
            if (N == 1) return 1;

            long returnVal = F(N - 1) + F(N - 2);
            _counter++;
            return returnVal;


        }
        public static int getCounter()
        {
            //Console.WriteLine("Counter Value was: {0}", _counter) ;
            return _counter;
        }
        //Dittman Incentive Marketing Bullshit puzzle:
        public static int[] getFirstTenFibonacciSequenceNumbers(int startingNumber)
        {
            //1,2,3,5,8,13,21,34,55....
            int[] Fibs = new int[10];
            int nextNumber;

            Fibs[0] = startingNumber;

            for (int j = 1; j < 10; j++)
            {
                //nextNumber = 
                if (j == 1)
                {
                    Fibs[j] = j + 1;
                }
                else
                {
                    nextNumber = Fibs[j - 1] + Fibs[j - 2];
                    Fibs[j] = nextNumber;

                }
            }
            return Fibs;
        }
        public static int getFirstTenFibonacciSequenceNumbersUsingRecursion(int startingNumber)
        {
            if (_counter > 9)
                return 0;

            int nextNumber;

            if (startingNumber == 1)
            {
                Console.WriteLine(startingNumber);
                nextNumber = startingNumber + 1;
                _nextNumber = startingNumber + 1;
                _lastNumber = startingNumber;
            }
            else
            {
                nextNumber = startingNumber + _lastNumber;
                _lastNumber = startingNumber;
            }

            Console.WriteLine(nextNumber);
            _counter++;

            return getFirstTenFibonacciSequenceNumbersUsingRecursion(nextNumber);

        }
        public static int Recursive(int value, ref int count)
        {
            count++;
            if (value >= 10)
            {
                // throw new Exception("End");
                return value;
            }
            return Recursive(value + 1, ref count);
        }

    }
}
