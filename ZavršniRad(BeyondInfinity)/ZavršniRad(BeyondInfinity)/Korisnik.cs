using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Korisnik : Povezivanje
    {
        

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Oib { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {

            return Ime + " " + Prezime;

        }
    }
}    



         
    




        

    

    

