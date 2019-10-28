using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dojo_ConsoleApp.Interfaces; 

namespace Dojo_ConsoleApp
{
    class Account_Savings : IAccount 
    {
        public string GetAcctInfo()
        {
            return "My Savings Info";
        }
    }
}
