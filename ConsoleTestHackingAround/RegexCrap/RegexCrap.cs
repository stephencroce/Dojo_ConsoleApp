using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleTestHackingAround.RegexCrap
{
    public static class RegexCrap
    {
        public static string FixPhoneNumber(string crappyPhoneNumber)
        {
            string goodPhoneNum = System.Text.RegularExpressions.Regex.Replace(crappyPhoneNumber, @"[-)( ]", String.Empty); 
            return goodPhoneNum;
        }

    }
}
