using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
{
    public class BooleanFun
    {
        public static bool AnswerQuestions(bool[] answers)
        {
            bool returnVal = false;

            if((answers[0] || answers[1] || answers[2])==false)
            {
                returnVal = true;
            }
            return returnVal;
        } 

    }
}
