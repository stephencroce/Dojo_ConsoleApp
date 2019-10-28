using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.Delegates.DaFunc
{
    public class DaFunc
    {        
        public string DoDaFunk(string firstname, string lastname)
        {
            return FormatName(firstname, lastname); 
        }
        //the rule is the first two string, string are the input.  the last string is the return.
        public static Func<string, string, string> FormatName = (fname, lname) => {

            string toReturn = string.Empty;
            if (!string.IsNullOrEmpty(fname))
            {
                toReturn = fname;
            }

            if (!string.IsNullOrEmpty(lname))
            {
                toReturn = toReturn + ((toReturn.Length > 0) ? " " : "").ToString() + lname;
            }
            return (toReturn.Length > 0) ? toReturn : "Name not on file";
        };
    }
}
