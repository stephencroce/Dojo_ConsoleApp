using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.AlgorithmCrap.LeetCode
{
    public static class BinaryTree
    {
        public static void DoLeetCodeBinaryTreeCrap()
        {
            //Calling it....using my superior computer scientist reasoning, I think the output is 16.
            //first iteration  i=0  ; x=1
            //second iteration  i=1 ; x=1+5 = 6
            //third iteration   i=2 ; x=6+10 = 6
            //application should write out 6.
            var whatIThoughtTheAnswerWas = 16;
            var x = 1;
            for (var i = 0; i < 3; i++)
            {
                x += 5 * i;
            }
            Console.WriteLine(string.Format("using my superior computer scientist reasoning, I think the output is {0}", x));
            if(whatIThoughtTheAnswerWas == x)
            {
                Console.WriteLine("You are brilliant and have a bright future in computer science.");
            }
            else { Console.WriteLine("Wrong.  you are an idiot."); }



            //Assignment:
            //Given a binary tree, return the preorder traversal of its nodes' values.
            //For example:
            //Given binary tree[1, null, 2, 3], visualized as below:
            //   1
            //    \
            //     2
            //    /
            //   3
            //return [1, 2, 3].
            //Note: Recursive solution is trivial, could you do it iteratively?
            //useful illustration of binary tree vs binary "search" tree: http://orcunyilmaz.com/coding-c/difference-between-binary-tree-and-binary-search-tree.html
            //Pre-order traversal is to visit the root first. Then traverse the left subtree. Finally, traverse the right subtree.
            //In-order traversal is to traverse the left subtree first. Then visit the root. Finally, traverse the right subtree.
            //Post-order traversal is to traverse the left subtree first. Then traverse the right subtree. Finally, visit the root.     

            //IList<int> PreorderTraversal(TreeNode root)
            //{
            //in the integer array, the preorder traversal solution would yield the set []

            //    return new List<int>();
            //}            


            //first, you need to create a binary tree from the given array.  You do that in this case be creating a nullable array like so:
            int?[] values = new int?[] { 1, null, 2, 3 };
            //Console.WriteLine("Press key to begin...");
            //Console.ReadKey();
            string[] people = new string[] { "Lewis", "Chloe", "Imogen", "Harry", "Tracy", "Xavier", "James", "Rachel" };
            
            int[] integerArray = new int[] { 12, 3, 9, 8, 20, 24, 18 };

            Console.WriteLine("here's the original:");
            foreach(int integer in integerArray)
            {
                Console.WriteLine(integer);
            }

            TreeNode theTreeNode=null;
            TreeNode currentNode = null;

            for (int i=0; i<integerArray.Length; i++)
            {
                if(theTreeNode ==null) //first node insertion. 
                {
                    theTreeNode = new TreeNode(integerArray[i]);
                }
                else
                {                 
                    if (integerArray[i] < theTreeNode.val)
                    {

                        TreeNode treeNode = new TreeNode(integerArray[i]);
                        theTreeNode.left = treeNode; 
                    }
                    else
                    {
                        TreeNode treeNode = new TreeNode(integerArray[i]);
                        theTreeNode.right = treeNode;                    
                    }
                }
            }
        }
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; } //constructor
        }        
    }
}
