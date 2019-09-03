using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround
{
    public abstract class Vehicle
    {
        //private string _year;
        //private string _make;
        //private string _model;

        public Vehicle() { }
        


        //public Vehicle(string year, string make, string model)
        //{
        //    this._year = year;
        //    this._make = make;
        //    this._model = model;
        //}
        public abstract string startEngine();
        //{
            //return "Chugga chugga";
        //}
    }


}
