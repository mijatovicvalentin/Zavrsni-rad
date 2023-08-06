using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Izbornik
    {

        private ObradaUsluga ObradaUsluga;
        private ObradaKorisnik ObradaKorisnik;
        public ObradaDjelatnik ObradaDjelatnik { get; }
        private ObradaVozilo ObradaVozilo;


        public Izbornik()
            
        {
            ObradaKorisnik = new ObradaKorisnik();
            ObradaUsluga = new ObradaUsluga();
            ObradaDjelatnik = new ObradaDjelatnik(); 
            ObradaVozilo = new ObradaVozilo(this);          
            PorukaPozdrava();
            PrikaziteIzbornik();        
        }



        private void PorukaPozdrava()
        {
            Console.WriteLine("|------------------------------------------------------------|");
            Console.WriteLine("|>>>>>>>>>>>>>>> Beyond Infinity Console App <<<<<<<<<<<<<<<<|");
            Console.WriteLine("|------------------------------------------------------------|");
            Console.WriteLine();
            Console.WriteLine();
        }


        private void PrikaziteIzbornik()
        {
            Console.WriteLine("Glavni izbornik Konzolne aplikacije BeyondInfinity  ^°^°^°^°^° ");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Usluge");
            Console.WriteLine("2. Korisnici");
            Console.WriteLine("3. Djelatnici");
            Console.WriteLine("4. Vozila");     
            Console.WriteLine("5. izlaz iz aplikacije");
            Console.WriteLine("--------------------------------------------------------------|");
            switch (Pomocno.UcitajBrojRaspona("Molimo odaberite stavku izbornika:  ", "Pokušajte ponovno uz odabir od 1 - 5 ", 1, 5))
            {
                case 1:
                    ObradaUsluga.PrikaziteIzbornik();
                    PrikaziteIzbornik();
                    break;

                case 2:
                    ObradaKorisnik.PrikaziteIzbornik();
                    PrikaziteIzbornik();
                    break;

                case 3:
                    ObradaDjelatnik.PrikaziteIzbornik();
                    PrikaziteIzbornik();
                    break;

                case 4:
                    ObradaVozilo.PrikaziteIzbornik();
                    PrikaziteIzbornik();
                     break;


                case 5:
                    Console.WriteLine("Zahvaljujemo se na vašem vremenu, Ugodan ostatak dana želimo!");
                    break;
            }
        }
    }
}
