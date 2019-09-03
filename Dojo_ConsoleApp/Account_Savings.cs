using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleTestHackingAround.Interfaces; 

namespace ConsoleTestHackingAround
{
    class Account_Savings : IAccount 
    {
        public string GetAcctInfo()
        {
            return "My Savings Info";
        }
    }
}
