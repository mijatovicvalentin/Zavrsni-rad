using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Djelatnik : Povezivanje
    {


        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Int64 Oib { get; set; }
        public int Kontakt { get; set; }
        public int JedinstveniBroj { get; set; }
        public string VrsteDjelatnika { get; set; }
    
    }
}
