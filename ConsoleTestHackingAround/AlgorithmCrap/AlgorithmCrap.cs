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
            if (q == 0)
            {
                return p;
            }
            else
            {
                int remainder = p % q; //Mod
                return GreatestCommonDivisor(q, remainder);
            }
        }
        //This is a Binary Search algorithm, also known as the Divide and Conquer -  this is a "famous, effective and widely used" algorithm, according to Sedgwick, Chap1, p46
        public static int Rank(int key, int[] array)
        {
            int lo = 0;
            int hi = array.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < array[mid])
                {
                    hi = mid - 1;
                }
                else if (key > array[mid])
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
        public static int RaiseStackOverflowError(int someInt)
        {
            //If some int is 2147483648 or greater, then stack integer overflow gets raised.
            return Math.Abs(-someInt);

        }
        public class AmazonTestCase
        {
            public string[] blockArray;
            public int n;

        }
        public static int GetDoubleLastScore(int[] scoreArray)
        {
            int lastNonZeroIndex = Array.FindLastIndex(scoreArray, item => item != 0);
            return scoreArray[lastNonZeroIndex] * 2;
        }
        public static int GetSumOfLastTwoScores(int[] scoreArray)
        {
            int lastNonZeroIndex = Array.FindLastIndex(scoreArray, item => item != 0);
            return scoreArray[lastNonZeroIndex - 1] + scoreArray[lastNonZeroIndex];
        }
        public static int AmazonTotalScore(string[] blocks, int n)
        {
            int hitScore = 0;
            int[] scoreArray = new int[n];
            int totalScore = 0;
            int parsedScoreValue;
            int zHitCounter = 0;

            for (int i = 0; i < n; i++)
            {
                bool zHit = false;
                if (int.TryParse(blocks[i], out parsedScoreValue))
                {
                    //if a throw his a block marked with an integer, that throw is value of the integer
                    hitScore = parsedScoreValue;
                }
                else
                {
                    //if throw hits a block marked with x, the score is double the last score
                    if (blocks[i].ToLower() == "x")
                    {
                        if (i >= 1)
                        {                            
                            hitScore = GetDoubleLastScore(scoreArray);
                        }
                    }
                    //if throw hits block marked with +,  score is sum of last two scores
                    if (blocks[i] == "+")
                    {
                        if (i >= 2)
                        {                            
                            hitScore = GetSumOfLastTwoScores(scoreArray);
                        }
                    }
                    //if throw hits block marked with z, the last score is removed and subsequent throws ignore it
                    if (blocks[i].ToLower() == "z")
                    {
                        zHit = true;
                        zHitCounter++;
                        if (i >= 1)
                        {
                            var scoreArrayList = new List<int>(scoreArray);
                            scoreArrayList.RemoveAt(i);
                            scoreArrayList.RemoveAt(i - 1);
                            scoreArray = scoreArrayList.ToArray();
                        }
                    }
                }
                if (!zHit)
                {                    
                    int firstZeroIndex = Array.FindIndex(scoreArray, item => item == 0);
                    scoreArray[firstZeroIndex] = hitScore;
                }
            }
            //after it's all done, calculate final score by looping through calculated score array:
            for (int s = 0; s < scoreArray.Length; s++)
            {
                totalScore = totalScore + scoreArray[s];
            }
            return totalScore;

        }
        public static void QuoraPuzzler()
        {
            //TODO: sometime when you've got nothing else to do, try this:
            //Problem statement: “Define Zeroes(N) as the number of zeroes in the decimal expansion of the integer N.A number N is ZeroSpecial if Zeroes(N) > Zeroes(N - 1).
            //Write a function that determines whether N is ZeroSpecial.”
            //https://www.quora.com/How-do-folks-interview-senior-software-engineers

        }

    }
}
