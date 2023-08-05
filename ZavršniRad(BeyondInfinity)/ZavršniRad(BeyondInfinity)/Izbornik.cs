using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Izbornik
    {

        private ObradaUsluga ObradaUsluga;
        private ObradaKorisnik ObradaKorisnik;



        public Izbornik()
            
        {
            ObradaKorisnik = new ObradaKorisnik();
            ObradaUsluga = new ObradaUsluga();
            PorukaPozdrava();
            PrikaziteIzbornik();        
        }



        private void PorukaPozdrava()
        {
            Console.WriteLine("|------------------------------------------------------------|");
            Console.WriteLine("|>>>>>>>>>>>>>>> Beyond Infinity Console App <<<<<<<<<<<<<<<<|");
            Console.WriteLine("|------------------------------------------------------------|");

        }


        private void PrikaziteIzbornik()
        {
            Console.WriteLine("Dobrodođli u glavni izbornik Konzolne aplikacije BeyondInfinity  ^°^° ");
            Console.WriteLine("1. Usluge");
            Console.WriteLine("2. Korisnici");
            Console.WriteLine("3. Vozila");    
            Console.WriteLine("4. Djelatnici");
            Console.WriteLine("5. izlaz iz aplikacije");
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
                    Console.WriteLine("Za rad sa korisnicima");
                    PrikaziteIzbornik();
                    break;

                case 4:
                    Console.WriteLine("Za rad sa djelatnicima");
                    PrikaziteIzbornik();
                     break;


                case 5:
                    Console.WriteLine("Zahvaljujemo se na vašem vremenu, Ugodan ostatak dana želimo!");
                    break;
            }
        }
    }
}
