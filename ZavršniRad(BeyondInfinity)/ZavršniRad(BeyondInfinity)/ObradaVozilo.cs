using System.Buffers;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Transactions;

namespace ZavršniRad_BeyondInfinity_
{
    internal class ObradaVozilo
    {

        private List<Vozilo> Vozila;
        private Izbornik Izbornik;

        public ObradaVozilo()
        {
            Vozila = new List<Vozilo>();


            if (Pomocno.DEV)
            {
                TestniPodaci();
            }

        }
        public ObradaVozilo(Izbornik Izbornik) : this()
        {

            this.Izbornik = Izbornik;

        }


        public void PrikaziteIzbornik()
        {

            Console.WriteLine(" ------------------------------------------ ");
            Console.WriteLine(" Nalazite se u izborniku za rad sa vozilima ");
            Console.WriteLine(" ------------------------------------------ ");
            Console.WriteLine("\t 1. Pregled postojećih vozila");
            Console.WriteLine("\t 2. Unos noveg vozila");
            Console.WriteLine("\t 3. Promjena postojećeg vozila");
            Console.WriteLine("\t 4. Brisanje postojećeg vozila");
            Console.WriteLine("\t 5. Povratak u glavni izbornik");
            Console.WriteLine("--------------------------------------------------------------|");
            switch (Pomocno.UcitajBrojRaspona("Molimo odaberite stavku izbornika vozila: ", "Pokušajte ponovno uz odabir od 1 - 5 ", 1, 5))
            {

                case 1:
                    PrikaziVozila();
                    PrikaziteIzbornik();
                    break;

                case 2:
                    UnosNovogVozila();
                    PrikaziteIzbornik();
                    break;

                case 3:
                    if (Vozila.Count == 0)
                    {
                        Console.WriteLine("Nema vozila za brisanje !");
                    }
                    PromjenaPostojećegVozila();
                    PrikaziteIzbornik();
                    break;


                case 4:
                    if (Vozila.Count == 0)
                    {
                        Console.WriteLine("Nema vozila za brisanje !");
                    }
                    else
                    {
                        BrisanjeVozila();
                    }

                    PrikaziteIzbornik();
                    break;


                case 5:
                    Console.WriteLine("\nGotov rad sa vozilima !\n");
                    break;



            }
        }

        private void BrisanjeVozila()
        {
            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj usluge za brisanje:",
             "Ponovite, ne valja !", 1, Vozila.Count());
            Vozila.RemoveAt(broj - 1);


        }

        private void PromjenaPostojećegVozila()
        {

            PrikaziVozila();


            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj djelatnika za promjenu:",
                "Ponovite !", 1, Vozila.Count());
            var voz = Vozila[broj - 1];

            voz.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id vozila:  (" + voz.id + "): ",
                  "Unos mora biti pozitivni cijeli broj");
            voz.Naziv = Pomocno.UcitajString("Molimo da unesete naziv vozila:  (" + voz.Naziv + "):  ",
                "Obavezan unos vozila");
            voz.Cijena = Pomocno.UcitajDecimalniBroj("Molimo da unesete cijenu vozila:  (" + voz.Cijena + "): ",
               "obavezan unos cijene vozila");
            voz.DatumProizvodnje = Pomocno.ucitajDatum("Molimo da unesete datum proizvodnje vozila:  (" + voz.DatumProizvodnje + "): "
                , "Datum mroa biti unesen");

            voz.Djelatnik = PostaviDjelatnik();

            voz.Tezina = Pomocno.UcitajCijeliBroj("Molimo da unesete težinu vozila:  (" + voz.Tezina + "):  ",
                "Obavezan unos  težine vozila");




        }

        public Djelatnik PostaviDjelatnik()
        {
            Izbornik.ObradaDjelatnik.PrikaziDjelatnike();
            int broj = Pomocno.UcitajBrojRaspona("Odaberi redni broj djelatnika: ", "Nije dobar odabir", 1, Izbornik.ObradaDjelatnik.Djelatnici.Count());
            return Izbornik.ObradaDjelatnik.Djelatnici[broj - 1];

        }
        private void PrikaziVozila()
        {

            Console.WriteLine();
            Console.WriteLine("---------Dostupna vozila-----------");
            Console.WriteLine("-----------------------------------");




            foreach (Vozilo v in Vozila)

            {






                Console.WriteLine("Id: {0}  ", v.id);
                Console.WriteLine("Naziv: {0}  ", v.Naziv);
                Console.WriteLine("Cijena: {0}  ", v.Cijena);
                Console.WriteLine("Datum proizvodnje: {0} ", v.DatumProizvodnje);

                foreach (Djelatnik d in Izbornik.ObradaDjelatnik.Djelatnici)

                { 

                Console.WriteLine("Djelatnik: {0} {1}", d.Ime, d.Prezime);
                }

                Console.WriteLine("Težina: {0} {1}", v.Tezina, "kg"); ;
                Console.WriteLine("----------------------------");

            }
        }




        private void UnosNovogVozila()
        {
            var voz = new Vozilo();
            {
                voz.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id vozila:  (" + voz.id + "): ",
                    "Unos mora biti pozitivni cijeli broj");
                voz.Naziv = Pomocno.UcitajString("Molimo da unesete naziv vozila:  (" + voz.Naziv + "):  ",
                    "Obavezan unos vozila");
                voz.Cijena = Pomocno.UcitajDecimalniBroj("Molimo da unesete cijenu vozila:  (" + voz.Cijena + "): ",
                   "obavezan unos cijene vozila");
                voz.DatumProizvodnje = Pomocno.ucitajDatum("Molimo da unesete datum proizvodnje vozila:  (" + voz.DatumProizvodnje + "): "
                    , "Datum mora biti unesen");
                voz.Djelatnik = PostaviDjelatnik();
                voz.Tezina = Pomocno.UcitajCijeliBroj("Molimo da unesete težinu vozila:  (" + voz.Tezina + "):  ",
                    "Obavezan unos težine vozila");



                Vozila.Add(voz);
            }
        }



        private void TestniPodaci()
        {
            Vozila.Add(new Vozilo() { Naziv = "Mercury"});
            
        }


    }
}