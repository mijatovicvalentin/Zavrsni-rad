using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{

    internal class ObradaKorisnik
    {
        public List<Korisnik> Korisnici { get; }


        public ObradaKorisnik()
        {
            Korisnici = new List<Korisnik>();
            TestniPodaci();


        }
        public void PrikaziteIzbornik()
        {

            Console.WriteLine(" --------------------------------------------- ");
            Console.WriteLine(" Nalazite se u izborniku za rad sa korisnicima ");
            Console.WriteLine(" --------------------------------------------- ");
            Console.WriteLine("1. Pregled postojećih korisnika");
            Console.WriteLine("2. Unos novog korinsika");
            Console.WriteLine("3. Promjena postojećeg korinsika");
            Console.WriteLine("4. Brisanje postojećeg kornisnika");
            Console.WriteLine("5. Povratak u glavni izbornik");
            switch (Pomocno.UcitajBrojRaspona("Molimo odaberite stavku izbornika Korisnici: ", "Pokušajte ponovno uz odabir od 1 - 5 ", 1, 5))
            {

                case 1:
                    PrikaziKorisnike();
                    PrikaziteIzbornik();
                    break;


                case 2:
                    UnosNovogKorisnika();
                    PrikaziteIzbornik();
                    break;

                case 3:
                    PromjenaPostojećegKorisnika();
                    PrikaziteIzbornik();
                    break;


                case 4:
                    if (Korisnici.Count == 0)
                    {
                        Console.WriteLine("Nema smjerova za brisanje !");
                    }
                    BrisanjeKorisnika();
                    PrikaziteIzbornik();
                    break;


                case 5:
                    Console.WriteLine("Gotov rad sa uslugama");
                    break;



            }
        }

        private void BrisanjeKorisnika()

        {



            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj usluge za brisanje:",
               "Ponovite, ne valja !", 1, Korisnici.Count());
            Korisnici.RemoveAt(broj - 1);



        }

        private void PromjenaPostojećegKorisnika()
        {
            PrikaziKorisnike();

            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj korisnika za promjenu:",
                "Ponovite !", 1, Korisnici.Count());
            var kor = Korisnici[broj - 1];

            kor.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id korisnika" +
                " (" + kor.id + "): ", "Nije dobro !");
            kor.Ime = Pomocno.UcitajString("Molimo da unesete ime korisnika: (" + kor.Ime + "): ",
                "Obavezan unos usluge");
            kor.Prezime = Pomocno.UcitajString("Molimo da unesete prezime korisnika: (" + kor.Prezime + "):  ",
                "Obavezna unos destiancije usluge");
            kor.Oib = Pomocno.UcitajCijeliBroj("Molimo da unesete oib korisnika: (" + kor.Oib + "): "
                , "oib korisnika mora sadržavati 11 brojeva");
            kor.Email = Pomocno.UcitajString("Molimo da unesete email korisnika: (" + kor.Email + "):  "
                , "Decimalni unos obavezan");
           
        }

        private void UnosNovogKorisnika()
        {

            var kor = new Korisnik();
            kor.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id usluge:  ",
                "Unos mora biti pozitivni cijeli broj");
            kor.Ime = Pomocno.UcitajString("Molimo da unesete naziv usluge:  ",
                "Obavezan unos usluge");
            kor.Prezime = Pomocno.UcitajString("Molimo da unesete destinaciju usluge:  ",
                "Obavezna unos destiancije usluge");
            kor.Oib = Pomocno.UcitajBrojRaspona("Molimo da unesete način plaćanja usluge:  "
                , "Način plaćanja mora biti 1 ili 2!" +
                "1 - Kartično 2 - Fizičko", 1, 2);
            kor.Email = Pomocno.UcitajString("Molimo da unesete email korisnika: (" + kor.Email + "):  "
               , "Decimalni unos obavezan");
            Korisnici.Add(kor);

        }





        private void PrikaziKorisnike()
        {
            Console.WriteLine();
            Console.WriteLine("---------Dostupni korisnici-------");
            Console.WriteLine("-------------------------------");
            foreach(Korisnik k in Korisnici)
            {
                Console.WriteLine("Id: {0}  ", k.id);
                Console.WriteLine("Ime: {0}  " , k.Ime);
                Console.WriteLine("Prezime: {0} : ", k.Prezime);
                Console.WriteLine("Oib: {0} ", k.Oib);
                Console.WriteLine("Email: {0} ", k.Email);
                Console.WriteLine("----------------------------");

            }
            Console.WriteLine("--------------------------------");

        }


        private void TestniPodaci()
        {
            Korisnici.Add(new Korisnik() { Ime = "Marija" });
            Korisnici.Add(new Korisnik() { Ime = "Ivana" });
            Korisnici.Add(new Korisnik() { Ime = "Petra" });

        }
    }
}



