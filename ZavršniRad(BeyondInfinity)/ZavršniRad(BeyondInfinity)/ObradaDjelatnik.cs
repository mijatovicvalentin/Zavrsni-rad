using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{

    internal class ObradaDjelatnik  
    {
        public List<Djelatnik> Djelatnici { get; }


        public ObradaDjelatnik()
        {
            Djelatnici = new List<Djelatnik>();
            TestniPodaci();


        }
        public void PrikaziteIzbornik()
        {

            Console.WriteLine(" ---------------------------------------------- ");
            Console.WriteLine(" Nalazite se u izborniku za rad sa djelatnicima ");
            Console.WriteLine(" ---------------------------------------------- ");
            Console.WriteLine("\t 1. Pregled postojećih djelatnika");
            Console.WriteLine("\t 2. Unos novog djelatnika");
            Console.WriteLine("\t 3. Promjena postojećeg djelatnika");
            Console.WriteLine("\t 4. Brisanje postojećeg djelatnika");
            Console.WriteLine("\t 5. Povratak u glavni izbornik");
            Console.WriteLine("--------------------------------------------------------------|");


            switch (Pomocno.UcitajBrojRaspona("Molimo odaberite stavku izbornika djelatnici: ", "Pokušajte ponovno uz odabir od 1 - 5 ", 1, 5))
            {

                case 1:
                    PrikaziDjelatnike();
                    PrikaziteIzbornik();
                    break;


                case 2:
                    UnosNovogDjelatnika();
                    PrikaziteIzbornik();
                    break;

                case 3:
                    PromjenaPostojećegDjelatnika();
                    PrikaziteIzbornik();
                    break;


                case 4:
                    if (Djelatnici.Count == 0)
                    {
                        Console.WriteLine("Nema smjerova za brisanje !");
                    }
                    BrisanjeDjelatnika();
                    PrikaziteIzbornik();
                    break;


                case 5:
                    Console.WriteLine("\nGotov rad sa korisnicima !\n");
                    break;



            }
        }

        private void BrisanjeDjelatnika()

        {



            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj usluge za brisanje:",
               "Ponovite, ne valja !", 1, Djelatnici.Count());
            Djelatnici.RemoveAt(broj - 1);
          
         



        }

        private void PromjenaPostojećegDjelatnika()
        {
            PrikaziDjelatnike();

            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj korisnika za promjenu:",
                "Ponovite !", 1, Djelatnici.Count());
            var dje = Djelatnici[broj - 1];

            dje.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id korisnika" +
                " (" + dje.id + "): ", "Nije dobro !");
            dje.Ime = Pomocno.UcitajString("Molimo da unesete ime korisnika: (" + dje.Ime + "): ",
                "Obavezan unos usluge");
            dje.Prezime = Pomocno.UcitajString("Molimo da unesete prezime korisnika: (" + dje.Prezime + "):  ",
                "Obavezna unos destiancije usluge");
            dje.Oib = Pomocno.UcitajCijeliBroj("Molimo da unesete oib korisnika: (" + dje.Oib + "): "
                , "oib korisnika mora sadržavati 11 brojeva");
            dje.Kontakt = Pomocno.UcitajString("Molimo da unesete email korisnika: (" + dje.Kontakt + "):  "
                , "Decimalni unos obavezan");
            dje.JedinstveniBroj = Pomocno.UcitajCijeliBroj("Molimo da unesete email korisnika: (" + dje.JedinstveniBroj + "):  "
                , "Decimalni unos obavezan");
            dje.VrsteDjelatnika = Pomocno.UcitajString("Molimo da unesete email korisnika: (" + dje.VrsteDjelatnika + "):  "
                    , "Decimalni unos obavezan");


        }

        private void UnosNovogDjelatnika()
        {

            var dje = new Djelatnik();
            dje.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id usluge:  ",
                "Unos mora biti pozitivni cijeli broj");
            dje.Ime = Pomocno.UcitajString("Molimo da unesete naziv usluge:  ",
                "Obavezan unos usluge");
            dje.Prezime = Pomocno.UcitajString("Molimo da unesete destinaciju usluge:  ",
                "Obavezna unos destiancije usluge");
            dje.Oib = Pomocno.UcitajBrojRaspona("Molimo da unesete način plaćanja usluge:  "
                , "Način plaćanja mora biti 1 ili 2!" +
                "1 - Kartično 2 - Fizičko", 1, 2);
            dje.Kontakt = Pomocno.UcitajString("Molimo da unesete email korisnika: (" + dje.Kontakt + "):  "
               , "Decimalni unos obavezan");
            dje.JedinstveniBroj = Pomocno.UcitajCijeliBroj("Molimo da unesete email korisnika: (" + dje.JedinstveniBroj + "):  "
               , "Decimalni unos obavezan");
            dje.VrsteDjelatnika = Pomocno.UcitajString("Molimo da unesete email korisnika: (" + dje.VrsteDjelatnika + "):  "
               , "Decimalni unos obavezan");



            Djelatnici.Add(dje);

        }





        private void PrikaziDjelatnike()
        {
            Console.WriteLine();
            Console.WriteLine("---------Dostupni djelatnici-------");
            Console.WriteLine("-----------------------------------");
            foreach (Djelatnik d in Djelatnici)
            {
                Console.WriteLine("Id: {0}  ", d.id);
                Console.WriteLine("Ime: {0}  ", d.Ime);
                Console.WriteLine("Prezime: {0} : ", d.Prezime);
                Console.WriteLine("Oib: {0} ", d.Oib);
                Console.WriteLine("Email: {0} ", d.Kontakt);
                Console.WriteLine("Oib: {0} ", d.JedinstveniBroj);
                Console.WriteLine("Email: {0} ", d.VrsteDjelatnika);
                Console.WriteLine("----------------------------");

            }

        }


        private void TestniPodaci()
        {
            Djelatnici.Add(new Djelatnik() { Ime = "shaw" });
            Djelatnici.Add(new Djelatnik() { Ime = "Luke" });
            Djelatnici.Add(new Djelatnik() { Ime = "Ivan" });

        }
    }
}



