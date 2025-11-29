using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk_Topping_Scanner
{
    internal class Beascuit : Iitem
    {
        public Boolean Tainted { get; set; }
        public string ResonantType { get; set; }
        public string BeascuitType { get; set; }
        public string Stat1 { get; set; }
        public string Stat2 { get; set; }
        public string Stat3 { get; set; }
        public string Stat4 { get; set; }
        public double Stat1Value { get; set; }
        public double Stat2Value { get; set; }
        public double Stat3Value { get; set; }
        public double Stat4Value { get; set; }
        public Beascuit() { 
        
        }
        public override string ToString()
        {
            return ((this.Tainted && ResonantType != "" ? "Tainted":"") + " " + this.ResonantType + " " + this.BeascuitType + " Beascuit" +
                    "\n" + this.Stat1 + ": " + this.Stat1Value + "%" +
                    "\n" + this.Stat2 + ": " + this.Stat2Value + "%" +
                    "\n" + this.Stat3 + ": " + this.Stat3Value + "%" +
                    "\n" + this.Stat4 + ": " + this.Stat4Value + "%");
        }
    }
}
