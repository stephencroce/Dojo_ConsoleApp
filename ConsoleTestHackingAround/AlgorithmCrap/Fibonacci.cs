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
    }
}
