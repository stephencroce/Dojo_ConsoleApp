using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.TracingCrap
{
    //The Attributes property identifies the custom attributes referenced in the application's configuration file. Unreferenced custom attributes are not enumerated. Classes that inherit from the TraceSource class can add custom attributes by overriding the Switch.GetSupportedAttributes method and returning a string array of custom attribute names.
    //https://msdn.microsoft.com/en-us/library/system.diagnostics.tracesource.attributes(v=vs.110).aspx
    public class MyTraceSource : System.Diagnostics.TraceSource
    {
        public MyTraceSource(string myName): base(myName)
        {

        }
        protected override string[] GetSupportedAttributes()
        {
            return new string[] {   "crapolaSetting", "myStupidsetting", "dingaling", "expires"  };
        }
    }
}
