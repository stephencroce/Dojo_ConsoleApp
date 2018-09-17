using System;
using ConsoleTestHackingAround;
using ConsoleTestHackingAround.AlgorithmCrap;
using ConsoleTestHackingAround.AlgorithmCrap.LeetCode;
//using ConsoleTestHackingAround.AlgorithmCrap;
//using ConsoleTestHackingAround.AlgorithmCrap.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ConsoleTestHackingAround.AlgorithmCrap.LeetCode.BinaryTree;

namespace UnitTestHacks
{
    [TestClass]
    public class UnitTestHacks
    {
        [TestMethod]
        public void TestFib()
        {
            Console.WriteLine("this is a test method");
            //Arrange
            int startNumber = 1;
            int[] expectedResult = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

            //Act
            int[] firstTenNubmersOfFibonacciSequence = Fibonacci.getFirstTenFibonacciSequenceNumbers(startNumber);

            //Assert
            //TODO: this is very handy, but I should probably figure out how this really works, cuz i don't think it's necessarily straightforward.  It's probably a separate puzzle unto itself.
            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(firstTenNubmersOfFibonacciSequence, expectedResult));

        }

        [TestMethod]
        public void ValidateTree11()
        {
            //Arrange
            int?[] integerArray = new int?[] { 2, 1, 3 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree, int.MinValue, int.MaxValue);

            //Assert
            Assert.IsTrue(isValidTree);
        }




        //[TestMethod]
        //public void ValidateTree1()
        //{
        //    //Arrange
        //    int?[] integerArray = new int?[] { 12, 3, 9, 8, 20, 24, 18 };


        //    //Act
        //    TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
        //    bool isValidTree = IsValidBST(binaryTree);

        //    //Assert
        //    Assert.IsTrue(isValidTree);
        //}





        [TestMethod]
        public void ValidateTree9()
        {
            //Arrange
            int?[] integerArray = new int?[] { 2147483647 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree, Int64.MinValue, Int64.MaxValue);

            //Assert
            Assert.IsTrue(isValidTree);
        }

        [TestMethod]
        public void ValidateTree12()
        {

            
            //Arrange
            int?[] integerArray = new int?[] { -2147483648 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            //bool isValidTree = IsValidBST(binaryTree, int.MinValue, int.MaxValue);
            bool isValidTree = IsValidBST(binaryTree, Int64.MinValue, Int64.MaxValue);
            

            //Assert
            Assert.IsTrue(isValidTree);
        }

        [TestMethod]
        public void ValidateTree13()
        {


            //Arrange
            int?[] integerArray = new int?[] { 2147483647, 2147483647 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);            
            bool isValidTree = IsValidBST(binaryTree, Int64.MinValue, Int64.MaxValue);


            //Assert
            Assert.IsFalse(isValidTree);
        }

        [TestMethod]
        public void ValidateTree10()
        {
            //Arrange
            int?[] integerArray = new int?[] { -2147483647 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree, int.MinValue, int.MaxValue);

            //Assert
            Assert.IsTrue(isValidTree);
        }

        [TestMethod]
        public void ValidateTree8a()
        {
            //Arrange
            int?[] integerArray = new int?[] { 8, 8, null, null, null, null, 5, 5, 5, 5, 5 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree, int.MinValue, int.MaxValue);

            //Assert
            Assert.IsFalse(isValidTree);
        }
        [TestMethod]
        public void ValidateTree8()
        {
            //Arrange
            int?[] integerArray = new int?[] { 8, 8, null, null, null, null, 5, 5, 5, 5, 5 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree);

            //Assert
            Assert.IsFalse(isValidTree);
        }
        [TestMethod]
        public void ValidateTree6()
        {
            //Arrange
            int?[] integerArray = new int?[] { null, null, null, null, null, null, null };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree);

            //Assert
            Assert.IsFalse(isValidTree);
        }
        [TestMethod]
        public void ValidateTree5()
        {
            //Arrange
            int?[] integerArray = new int?[] { 0, 0, 0, 0, 0, 0, 0 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree);

            //Assert
            Assert.IsFalse(isValidTree);
        }

        [TestMethod]
        public void ValidateTree4()
        {
            //Arrange
            int?[] integerArray = new int?[] { 5, 1, 4, null, null, 3, 6 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree);

            //Assert
            Assert.IsFalse(isValidTree);
        }

        [TestMethod]
        public void ValidateTree3()
        {
            //Arrange
            int?[] integerArray = new int?[] { 10, 5, 15, null, null, 6, 20 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree);


            //Assert
            Assert.IsFalse(isValidTree);
        }

        [TestMethod]
        public void ValidateTree2a()
        {
            //Arrange
            int?[] integerArray = new int?[] { 1, 1 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree, int.MinValue, int.MaxValue);

            //Assert
            Assert.IsFalse(isValidTree);
        }

        [TestMethod]
        public void ValidateTree2()
        {
            //Arrange
            int?[] integerArray = new int?[] { 1, 1 };

            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree);

            //Assert
            Assert.IsFalse(isValidTree);
        }

        [TestMethod]
        public void ValidateTree1a()
        {
            //Arrange
            int?[] integerArray = new int?[] { 12, 3, 9, 8, 20, 24, 18 };


            //Act
            TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
            bool isValidTree = IsValidBST(binaryTree, int.MinValue, int.MaxValue);

            //Assert
            Assert.IsTrue(isValidTree);
        }


        //[TestMethod]
        //public void ValidateTree1()
        //{
        //    //Arrange
        //    int?[] integerArray = new int?[] { 12, 3, 9, 8, 20, 24, 18 };


        //    //Act
        //    TreeNode binaryTree = BinaryTree.FillBinaryTree(integerArray);
        //    bool isValidTree = IsValidBST(binaryTree);

        //    //Assert
        //    Assert.IsTrue(isValidTree);
        //}


    }
}
