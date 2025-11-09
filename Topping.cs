using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk_Topping_Scanner
{
    internal class Topping
    {
        public string ResonantType;
        public string ToppingType;
        public string Stat1;
        public string Stat2;
        public string Stat3;
        public string Stat1Value;
        public string Stat2Value;
        public string Stat3Value;

        public Topping(string resonantType,
                       string toppingType,
                       string stat1,
                       string stat2,
                       string stat3,
                       string stat1Value,
                       string stat2Value,
                       string stat3Value)
        {
            if (resonantType == "Not Resonant")
            {
                this.ResonantType = "";
            }
            else
            {
                this.ResonantType = resonantType;
            }
            this.ToppingType = toppingType;
            this.Stat1 = stat1;
            this.Stat2 = stat2;
            this.Stat3 = stat3;
            this.Stat1Value = stat1Value;
            this.Stat2Value = stat2Value;
            this.Stat3Value = stat3Value;
        }

        public override string ToString()
        {
            return (this.ResonantType + " " + this.ToppingType + "\n    " + this.Stat1 + ": " + this.Stat1Value + "\n    " + this.Stat2 + ": " + this.Stat2Value + "\n    " + this.Stat3 + ": " + this.Stat3Value);
        }
    }
}
