using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavršniRad_BeyondInfinity_;

namespace ZavršniRad_BeyondInfinity_
{
    internal class ObradaUsluga
    {
        public List<Usluga> Usluge { get; }


        public ObradaUsluga()
        {
            Usluge = new List<Usluga>();
            TestniPodaci();


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


                case 4:
                    if(Usluge.Count == 0)
                    {
                        Console.WriteLine("Nema smjerova za brisanje !");
                    }
                    BrisanjeUsluge();
                    PrikaziteIzbornik();
                    break;


                case 5:
                    Console.WriteLine("Gotov rad sa uslugama");
                    break;



            }
        }

        private void BrisanjeUsluge()

        {

           

            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj usluge za brisanje:",
               "Ponovite, ne valja !", 1, Usluge.Count());
            Usluge.RemoveAt(broj - 1);

           

        }

        private void PromjenaPostojećegSmjera()
        {
            PrikaziUsluge();

            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj usluge za promjenu:",
                "Ponovite !", 1, Usluge.Count());
            var usl = Usluge[broj - 1];

            usl.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id usluge" +
                " (" + usl.id + "): ", "Nije dobro !");
            usl.Naziv = Pomocno.UcitajString("Molimo da unesete naziv usluge: (" + usl.Naziv + "): ",
                "Obavezan unos usluge");
            usl.Destinacija = Pomocno.UcitajString("Molimo da unesete destinaciju usluge: (" + usl.Destinacija +"):  ",
                "Obavezna unos destiancije usluge");
            usl.NacinPlacanja = Pomocno.UcitajBrojRaspona("Molimo da unesete način plaćanja usluge: (" + usl.NacinPlacanja + "): "
                , "Način plaćanja mora biti 1 ili 2!" +
                "1 - Kartično 2 - Fizičko", 1, 2);   
            usl.Cijena = Pomocno.UcitajDecimalniBroj("Molimo da unesete cijenu usluge: (" + usl.Cijena + "):  "
                , "Decimalni unos obavezan");
            usl.BrojMjesta = Pomocno.UcitajCijeliBroj("Molimo da unesete broj sjedala za uslugu: (" + usl.BrojMjesta + "): ",
                "Ponovite unos broja sjedala ");

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
                "1 - Kartično 2 - Fizičko", 1, 2);
            usl.Cijena = Pomocno.UcitajDecimalniBroj("Molimo da unesete cijenu usluge:  "
                , "Decimalni unos obavezan");
            usl.BrojMjesta = Pomocno.UcitajCijeliBroj("Molimo da unesete broj sjedala za uslugu:  ",
                "Ponovite unos broja sjedala ");
            Usluge.Add(usl);

        }





        private void PrikaziUsluge()
        {
            Console.WriteLine();
            Console.WriteLine("---------Dostupne usluge-------");
            Console.WriteLine("-------------------------------");
            foreach (Usluga u in Usluge)
            {
                Console.WriteLine("Id \t{0}. :",   u.id);
                Console.WriteLine("Naziv\t{0}. ",  u.Naziv);
                Console.WriteLine("Destinacija \t{0}. ", u.Destinacija);
                Console.WriteLine("Nacin plaćanja \t{0}.",  u.NacinPlacanja);
                Console.WriteLine("Cijena \t{0}. " , u.Cijena);
                Console.WriteLine("Broj Sjedala \t{0}. "  ,  u.BrojMjesta);
                Console.WriteLine("----------------------------");

            }
            Console.WriteLine("--------------------------------");

        }


        private void TestniPodaci()
        {
            Usluge.Add(new Usluga() { Naziv = "ProximaB" });
            Usluge.Add(new Usluga() { Naziv = "ProximaZ" });
            Usluge.Add(new Usluga() { Naziv = "ProximaK" });

        }
    }

 
}



