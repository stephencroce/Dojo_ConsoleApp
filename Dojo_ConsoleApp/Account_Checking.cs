using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround
{
    class Account_Checking:ConsoleTestHackingAround.Interfaces.IAccount
    {
        public string GetAcctInfo()
        {
            return "My Checking Info";
        }
        public string GetABARoutingNo()
        {
            return "999000999";
        }
    }
}
