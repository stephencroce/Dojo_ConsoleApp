using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
{
    public class Stock
    {
        //This was the other Dittman Puzzle
        public Dictionary<string, string> StockData;
        public Stock()
        {
            //http://stackoverflow.com/questions/4980500/literal-notation-for-dictionary-in-c
            StockData = new Dictionary<string, string>
            {
                //{time (day), price (dollars) } of google stock.
                { "10", "100" },
                { "20", "120" },
                { "30", "140" },   //{ "30", "150" },  'Here is an example of a scenario where this solution is inadequate - If this KVP were used, the solution will fail it would answer that you should have sold in the past, which is not possible.
                { "45", "150" },
                { "40", "110" },
                { "50", "90" },
                { "60", "140" },
                { "70", "120" },
                { "80", "130" },
                { "90", "150" },
                { "100", "135" }
            };
        }
        public Stock(int price)
        {

        }
        public Stock(int price, string ticker)
        {

        }
        //to do:  knowing this historical data, find the optimal time to buy and sell the stock for maximal profit.        
    }
}
