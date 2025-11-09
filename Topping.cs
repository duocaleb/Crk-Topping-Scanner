using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk_Topping_Scanner
{
    internal class Topping
    {
        public string ResonantType {get; set; }
        public string ToppingType{get; set;}
        public string Stat1{get; set;}
        public string Stat2{get; set;}
        public string Stat3{get; set;}
        public string Stat1Value{get; set;}
        public string Stat2Value{get; set;}
        public string Stat3Value{get; set;}

        public Topping()
        {
            if (this.ResonantType == "Not Resonant")
            {
                this.ResonantType = "";
            }
        }

        public override string ToString()
        {
            return (this.ResonantType + " " + this.ToppingType + "\n    " + this.Stat1 + ": " + this.Stat1Value + "\n    " + this.Stat2 + ": " + this.Stat2Value + "\n    " + this.Stat3 + ": " + this.Stat3Value);
        }
    }
}
