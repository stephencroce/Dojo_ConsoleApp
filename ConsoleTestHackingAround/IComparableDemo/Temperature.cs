using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.IComparableDemo
{
    //IComparable shit - turns out that the big benefit of implementing this C# interface is that it allows things to be sortable.  This doesn't work here
    //because I think the implementation is screweed up, but see http://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx
    public class Temperature : IComparable
    {
        public int Fahrenheit { get; set; }

        // The temperature value 
        protected int temperatureF;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Temperature otherTemperature = obj as Temperature;
            if (otherTemperature != null)
                return this.temperatureF.CompareTo(otherTemperature.temperatureF);
            else
                throw new ArgumentException("Object is not a Temperature");
        }
    }
}
