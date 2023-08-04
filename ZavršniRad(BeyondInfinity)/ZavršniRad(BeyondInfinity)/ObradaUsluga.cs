using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class ObradaUsluga
    {
        public List<Usluga> Usluge { get; }


        public ObradaUsluga()
        {
            Usluge = new List<Usluga>();


        }
        public void PrikaziteIzbornik()
        {

            Console.WriteLine(" ------------------------------------------ ");
            Console.WriteLine(" Nalazite se u izborniku za rad sa uslugama ");
            Console.WriteLine(" ------------------------------------------ ");
            Console.WriteLine("1. Pregled postojećih usluga");
            Console.WriteLine("2. Unos nove usluga");
            Console.WriteLine("3. Promjena postojeće usluge");
            Console.WriteLine("4. Brisanje postojeće usluge");
            Console.WriteLine("5. Povratak u glavni izbornik");
            switch (Pomocno.UcitajBrojRaspona("Molimo odaberite stavku izbornika usluge: ", "Pokušajte ponovno uz odabir od 1 - 5 ", 1, 5))
            {

                case 1:
                    PrikaziUsluge();
                    PrikaziteIzbornik();
                    break;


                case 2:
                    UnosNoveUsluge();
                    PrikaziteIzbornik();
                    break;

                case 3:
                    PromjenaPostojećegSmjera();
                    PrikaziteIzbornik();
                     break;



                case 5:
                    Console.WriteLine("Gotov rad sa uslugama");
                    break;



            }
        }

        private void PromjenaPostojećegSmjera()
        {
            throw new NotImplementedException();
        }

        private void UnosNoveUsluge()
        {

            var usl = new Usluga();
            usl.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id usluge:  ",
                "Unos mora biti pozitivni cijeli broj");
            usl.Naziv = Pomocno.UcitajString("Molimo da unesete naziv usluge:  ",
                "Obavezan unos usluge");
            usl.Destinacija = Pomocno.UcitajString("Molimo da unesete destinaciju usluge:  ", 
                "Obavezna unos destiancije usluge");
            usl.NacinPlacanja = Pomocno.UcitajBrojRaspona("Molimo da unesete način plaćanja usluge:  "
                , "Način plaćanja mora biti 1 ili 2!" +
                "1 - Kartično 2 - Fizičko",1 , 2 );
            usl.Cijena = Pomocno.UcitajDecimalniBroj("Molimo da unesete cijenu usluge:  "
                , "Decimalni unos obavezan");
            usl.BrojMjesta = Pomocno.UcitajCijeliBroj("Molimo da unesete broj sjedala za uslugu:  ",
                "Ponovite unos broja sjedala ");
           Usluge.Add(usl);
                
        }   

    



        private void PrikaziUsluge()
        {
            Console.WriteLine("_____________________________|");
            foreach (Usluga u in Usluge)
            

            {
                Console.WriteLine("Id : {0}" , u.id) ;
                Console.WriteLine("Naziv: {0}" , u.Naziv);
                Console.WriteLine("Destinacija {0}" , u.Destinacija);
                Console.WriteLine("Nacin plaćanja {0}" , u.NacinPlacanja);
                Console.WriteLine("Cijena {0}" , u.Cijena);
                Console.WriteLine("Broj Sjedala {0}" , u.BrojMjesta);
                Console.WriteLine("_____________________________|");

            }

        }
    }

} 
