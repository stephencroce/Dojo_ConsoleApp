using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.AlgorithmCrap
{
    public class MoreAmazonCrap
    {
        //EIGHT HOUSES

        /*
        Eight houses, represented as cells, are arranged in a straight line.  
        Each day every cell competes with its adjacent cells (neighbors)

        An integer value of 1 represents an active cell and a value of 0 represents an inactive cell.  

        If the neighbors on both sides of a cell are either active or
        inactive, the cell becomes inactive on the next day; otherwise the cell becomes active.  

        The two cells on each end have a single adjacent cell,
        so assume that the unoccupied space on the opposite side is an inactive cell.  

        Even after updating the cell state, consider its previous state when updating the state
        of the other cells.  The state information of all cells should be updated simultaneously.

        //============================
        Write an algorithm to output the state of the cells after the given number of days.
        //============================

        INPUT
        the input to the function/method consists of two arguements:
        states, a list of integers representing the current state of cells;
        days, an integer representing the number of days.

        OUTPUT
        Return a list of integers representing the state of the cells after the given number of days.

        NOTES
        The elements of the list states contains 0s and 1s only
        */
        //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED        
        public List<int> CellCompete(int[] states, int days)
        {
            //your code here
            if(days > 0)
            {
                outputCurrentStates(states, days);
                for (int s = 0; s < states.Length; s++)
                {
                    if(s==0)
                    {
                        if (states[s + 1] == 0) { states[s] = 0; } else { states[s] = 1; } 

                    }
                    if(s == states.Length - 1)
                    {
                        if (states[s - 1] == 0) { states[s] = 0; } else { states[s] = 1; }                        

                    }
                    if (s != 0 && s != states.Length - 1)
                    {
                        if (states[s - 1] == states[s + 1])
                        {
                            states[s] = 0;
                        }
                        states[s] = 1;
                    }
                }                
                CellCompete(states, days-1);
            }
            return states.ToList();
        }
        //METHOD SIGNATURE ENDS
        private void outputCurrentStates(int[] currentState, int days)
        {
            Console.WriteLine(string.Format("With {0} days to go, the current state looks like this: ", days));
            foreach(int stateVal in currentState)
            {                
                Console.WriteLine(stateVal);
            }
        }
    }
}







