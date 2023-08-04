using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Usluga : Povezivanje
    {
        public string Naziv { get; set; }
        public string Destinacija { get; set; }
        public int NacinPlacanja { get; set; }
        public decimal Cijena { get; set; }
        public int BrojMjesta { get; set; }
    }
}
