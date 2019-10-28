using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp
{
    class Account_Checking:Dojo_ConsoleApp.Interfaces.IAccount
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
