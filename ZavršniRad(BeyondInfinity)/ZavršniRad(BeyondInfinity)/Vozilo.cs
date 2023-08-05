using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Vozilo
    {

        public string Naziv { get; set; }
        public string Cijena { get; set; }
        public DateTime DatumProizvodnje { get; set; }
        public Djelatnik Djelatnik { get; set; }
        public int Tezina { get; set; }
    }
}
