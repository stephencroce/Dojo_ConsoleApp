using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.MongoCrap
{
    public class TraceEntry
    {
        //public TraceEntry()
        public TraceEntry(){}

        public int? AppSubSysID { get; set; }
        public string Entry { get; set; }
        public DateTime? Expires { get; set; }
        public Guid Id { get; set; }
        public Dictionary<string, string> Keys { get; set; }
        public int? LogTypeID { get; set; }
        public DateTime Occurred { get; set; }
        public int ProcessID { get; set; }
        public string ServerName { get; set; }
        public Guid SessionID { get; set; }
        public int Severity { get; set; }
        public string Source { get; set; }
        public string ThreadID { get; set; }
    }
}
