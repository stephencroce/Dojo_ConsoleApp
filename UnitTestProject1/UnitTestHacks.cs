using System;
using ConsoleTestHackingAround.AlgorithmCrap;
using ConsoleTestHackingAround.AlgorithmCrap.LeetCode;
//using ConsoleTestHackingAround.AlgorithmCrap;
//using ConsoleTestHackingAround.AlgorithmCrap.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestHacks
{
    [TestClass]
    public class UnitTestHacks
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("this is a test method");            

            

            var startNumber = 1;
            var firstTenNubmersOfFibonacciSequece = Fibonacci.getFirstTenFibonacciSequenceNumbers(startNumber);
            Console.WriteLine(string.Format("Here are first ten numbers of the fibonacci sequence starting at {0}", startNumber));

            foreach (var number in firstTenNubmersOfFibonacciSequece)
            {
                Console.WriteLine(number);
            }
            
        }
        [TestMethod]
        public void TestBinTree()
        {
            int?[] integerArray = new int?[] { 10, 5, 15, null, null, 6, 20 }; //failed case 2 - wtf?
            Console.WriteLine(BinaryTree.IsValidBST(BinaryTree.FillBinaryTree(integerArray)));           

        }
    }
}
