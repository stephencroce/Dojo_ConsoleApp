using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround.IComparableDemo
{
    //IComparable shit - turns out that the big benefit of implementing this C# interface is that it allows things to be sortable.  
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
                
                //////////////////////////////////////////
                //The fucking demo was wrong on MSDN.  Thanks fucking Microsoft, for nothing.  This doesn't work here
                //because I think the implementation is screweed up, but see http://msdn.microsoft.com/en-us/library/system.icomparable%28v=vs.110%29.aspx
                //return this.temperatureF.CompareTo(otherTemperature.temperatureF);

                //See this demo instead of dumbass microsoft.   http://www.dotnetperls.com/icomparable

                //use this line instead:

                //CHECK IT OUT: this will return ASCENDING Sort:
                //return this.Fahrenheit.CompareTo(otherTemperature.Fahrenheit);
                //WHEREAS: this will return DESCENDING Sort:
                return otherTemperature.Fahrenheit.CompareTo(this.Fahrenheit);
            else
                throw new ArgumentException("Object is not a Temperature");
        }
    }
}
