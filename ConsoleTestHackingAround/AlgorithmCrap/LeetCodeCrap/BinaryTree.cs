using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.AlgorithmCrap.LeetCode
{
    public static class BinaryTree
    {
        public static TreeNode theTree = null;
        public static TreeNode theTempTree = null;        
        public static List<int?> PreOrderedList = new List<int?>();

        public static void WhatDoesThisCodeDo()
        {
            //Console.WriteLine("Press key to begin...");
            //Console.ReadKey();

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
            if (whatIThoughtTheAnswerWas == x)
            {
                Console.WriteLine("You are brilliant and have a bright future in computer science.");
            }
            else { Console.WriteLine("Wrong.  you are an idiot."); }

        }
        /// <summary>
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
        /// </summary>

        //Definition of a binary tree node.
        public class TreeNode
        {
            public int? val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int? x) { val = x; } //constructor
        }
        public static void DoLeetCodeBinaryTreeCrap()
        {
            //just for fun....
            //WhatDoesThisCodeDo(); 

            //SETUP :: first, you need to create a binary tree from the given array.  You do that in this case be creating a nullable array like so:

            //int?[] integerArray = new int?[] { 12, 3, 9, 8, 20, 24, 18 };
            //int?[] integerArray = new int?[] { 1,1 }; //failed case 1 - fixed
            int?[] integerArray = new int?[] { 10, 5, 15, null, null, 6, 20 }; //failed case 2 - wtf?
            


            //TODO: try these if you ever figure out the first example...
            //int?[] values = new int?[] { 1, null, 2, 3 };
            //string[] nameArray = new string[] { "Lewis", "Chloe", "Imogen", "Harry", "Tracy", "Xavier", "James", "Rachel" };

            Console.WriteLine("here's an enumeration of what's in the original array:");

            foreach (int? integer in integerArray)
            {
                Console.WriteLine(integer);
            }

            //allocate a default TreeNode to return:
            theTree = null;

            //first, fill the tree with data from the array:
            theTree = FillBinaryTree(integerArray);

            //once that's done, then you can write out a traversal of your choice:
            if (IsValidBST(theTree))
            {
                EnumeratePreOrder(theTree);
            }
            else
            {
                Console.WriteLine("you idiot.  it's not a valid tree"); 
            }

            //The End.            
        }        
        public static TreeNode FillBinaryTree(int?[] integerArray)
        {
            //Q: see - fucking crap like this is confusing....how the hell do you handle it?
            //A: static variables - https://en.wikipedia.org/wiki/Static_variable
            //theRootTreeNode.left.left.left.left
            //theRootTreeNode.right.left.right.left
            //theRootTreeNode.right.right.right.right.right.left.val 

            for (int i = 0; i < integerArray.Length; i++)
            {
                //special or base case
                if (theTree == null) //first node insertion. 
                {
                    theTree = new TreeNode(integerArray[i]);
                }
                else
                {
                    AddSubNode(theTree, new TreeNode(integerArray[i]));
                }
            }
            Console.WriteLine("Tree Created!");
            return theTree;
        }
        public static void AddSubNode(TreeNode theTree, TreeNode newNode)
        {
            // this is the fucking part that crosses up my fucking brain!!!!!!!!!!   
            //oh stop it.  it's just recursion.  Don't be a freaking nutcase.
            if (newNode.val < theTree.val)
            {
                if (theTree.left == null)
                {
                    theTree.left = newNode;
                }
                else 
                {
                        theTempTree = theTree;
                        TreeNode currentNode;
                        currentNode = theTempTree.left;
                        //this call obliterates theTree in memory, so it won't work right....                        
                        AddSubNode(currentNode, newNode);               
                }
            }
            else
            {
                if (theTree.right == null)
                {
                    theTree.right = newNode;
                }
                else 
                {
                    theTempTree = theTree;
                    TreeNode currentNode;
                    currentNode = theTempTree.right;
                    //this call obliterates theTree in memory, so it won't work right....                        
                    AddSubNode(currentNode, newNode);
                }
            }
        }
        public static void EnumeratePreOrder(TreeNode theFilledTree)
        {
            int?[] PreOrderedArray = DoPreOrder(theFilledTree);
            int loopCounter = 0;
            Console.WriteLine("Here is your Pre-Order of the tree...");
            
            Console.Write("[");
            foreach(int? i in PreOrderedArray)
            {
                if (loopCounter != PreOrderedArray.Length-1)
                {
                    Console.Write(string.Format("{0}, ", i));
                }
                else
                {
                    Console.Write(string.Format("{0}", i));
                }
                loopCounter++;
            }
            Console.Write("]");
            Console.WriteLine(); 
            //Ta DAAAA
        }
        /// <summary>
        //Pseudocode - recursive
        //preorder(node)
        //if node==null then return
        //visit(node)
        //preorder(node.left)
        //preorder(node.right)
        /// </summary>
        /// <param name="theTree"></param>
        /// <returns></returns>
        public static int?[] DoPreOrder(TreeNode theTree)
        {
            //ok all you need is this - it's the "trivial" recursive answer, but why the fuk does it work?
            ////Pre-order traversal is to visit the root first. Then traverse the left subtree. Finally, traverse the right subtree.
            ////so Root, Left, Right...i think for the numbers example, we should end up with 12, 3, 9, 8, 20, 18, 24
            if (theTree!=null)
            {
                PreOrderedList.Add(theTree.val); //aka "visit the node"
                DoPreOrder(theTree.left);
                DoPreOrder(theTree.right);
            }            
            #region NOPE  ain't workin'...WAYYYY too complicated.....
              
            //TreeNode currentNode;

            ////Base case:
            ////if (PreOrderedList.Count == 0)
            ////{
            //PreOrderedList.Add(theTree.val);
            ////}

            //if (theTree.left != null)
            //{
            //    theTempTree = theTree;
            //    currentNode = theTempTree.left;
            //    PreOrderedList.Add(currentNode.val);
            //    if (currentNode.left != null)
            //        DoPreOrder(currentNode.left);
            //    else if (currentNode.right != null)
            //        DoPreOrder(currentNode.right);
            //    else
            //    {
            //        DoPreOrder(theOriginalFilledTree.right);
            //    }
            //}
            //else if (theTree.right != null)
            //{
            //    theTempTree = theTree;
            //    currentNode = theTempTree.right;
            //    PreOrderedList.Add(currentNode.val);
            //    if (currentNode.left != null)
            //        DoPreOrder(currentNode.left);
            //    else if (currentNode.right != null)
            //        DoPreOrder(currentNode.right);
            //}
            //else
            //{
            //    //something still doesn't work right.  when there are two leaves, it doesn't work.
            //    DoPreOrder(theTree.right);
            //} 
            #endregion
            return PreOrderedList.ToArray();
        }
        /// <summary>
        //  The left subtree of a node contains only nodes with keys less than the node's key.
        //  The right subtree of a node contains only nodes with keys greater than the node's key.
        //  Both the left and right subtrees must also be binary search trees.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// 

        // //method 2
        // The max-Min solution, only 68 of 75 cases passed on LeetCode.  WTF
        public static bool IsValidBST(TreeNode root, Int64? min, Int64? max)
        {
            if (root != null)
            {
                if (root.val >= max || root.val <= min)
                {
                    return false;
                }
                return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
            }
            else
            {
                return true;
            }
        }
        public static bool IsValidBST(TreeNode root)
        {
            //suspect the upper limits method might be better ye....








            //70 / 75 test cases passed - got this solution from SO
            // https://stackoverflow.com/questions/9667315/how-to-validate-a-binary-search-tree
            // Terminal case, empty sub-tree is valid.

            if (root == null)
                    return false ;

                // Left node >= current means invalid

                if (root.left != null)
                    if (root.left.val >= root.val)
                        return false;

            // Right node <= current means invalid

            if (root.right != null)
                if (root.right.val <= root.val)
                    return false;

                if (!IsValidBST(root.left))

                // Invalid entire left subtree means invalid.
                return false;

                // Otherwise return state of entire right subtree.
                return IsValidBST(root.right);

            #region 57/75 test cases passed (my first attempt) on leetcode, not horrible...
            //if (root != null)
            //{
            //    if(root.left!=null)
            //    if (root.left.val >= root.val)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        IsValidBST(root.left);
            //    }
            //    if (root.right != null)
            //    if (root.right.val <= root.val)
            //    {
            //        return false;                        
            //    }
            //    else
            //    {
            //        IsValidBST(root.right);
            //    }
            //}
            //else { return false; }
            //return true;
            #endregion


        }

        public static void thisIsAlinkedListInCSharp()
        {
            //This generic type allows fast inserts and removes. It implements a classic linked list. Each object is separately allocated.
            //In the LinkedList, certain operations do not require the whole collection to be copied. But in many common cases LinkedList hinders performance.
            //Lots of interesting things to be learned about the C#/.NET implementation of it here: https://www.dotnetperls.com/linkedlist

            // Create a new linked list object instance.

            LinkedList<string> linked = new LinkedList<string>();

            // Use AddLast method to add elements at the end.
            // Use AddFirst method to add element at the start.

            linked.AddLast("cat");
            linked.AddLast("dog");
            linked.AddLast("man");
            linked.AddFirst("first");

            // Loop through the linked list with the foreach-loop.

            foreach (var item in linked)
            {
                Console.WriteLine(item);
            }
        }
    }
}

