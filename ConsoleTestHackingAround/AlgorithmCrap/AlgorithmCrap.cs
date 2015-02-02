using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.AlgorithmCrap
{
    public static class AlgorithmCrap
    {
        //Euclid's algorithm
        public static int GreatestCommonDivisor(int p, int q)
        {
            if (q == 0) {
                return p;
            }
            else
            {
                int remainder = p % q; //Mod
                return GreatestCommonDivisor(q, remainder);
            }
        }
        //This is a Binary Search algorithm, also known as the Divide and Conquer
            public static int Rank(int key, int[] array)
            {
                int lo = 0;
                int hi = array.Length - 1;

                while (lo <= hi) 
                {
                    int mid = lo + (hi - lo) / 2;
                    if(key < array[mid])
                    {
                        hi = mid - 1;
                    }
                    else if(key > array[mid])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                return -1;
            }
        //}        
    }
}
