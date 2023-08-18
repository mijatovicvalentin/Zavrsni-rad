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
            if(Pomocno.DEV)
            {
                TestniPodaci();
            }



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
                    if (Djelatnici.Count == 0)
                    {
                        Console.WriteLine("Nema smjerova za brisanje !");
                    }
                    PromjenaPostojećegDjelatnika();
                    PrikaziteIzbornik();
                    break;


                case 4:
                    if (Djelatnici.Count == 0)
                    {
                        Console.WriteLine("Nema smjerova za brisanje !");
                    }
                    else
                    {
                        BrisanjeDjelatnika();
                    }

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

            int broj = Pomocno.UcitajBrojRaspona("Molimo odaberite redni broj djelatnika za promjenu:",
                "Ponovite !", 1, Djelatnici.Count());
            var dje = Djelatnici[broj - 1];

            dje.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id djelatnika" +
                " (" + dje.id + "): ", "Nije dobro !");
            dje.Ime = Pomocno.UcitajString("Molimo da unesete ime djelatnika: (" + dje.Ime + "): ",
                "Obavezan unos usluge");
            dje.Prezime = Pomocno.UcitajString("Molimo da unesete prezime djelatnika: (" + dje.Prezime + "):  ",
                "Obavezna unos destiancije usluge");
            dje.Oib = Pomocno.UcitajCijeliBroj("Molimo da unesete oib djelatnika:  (" + dje.Oib + "): "
                , "obavezan unos od 11 brojeva");
            dje.Kontakt = Pomocno.UcitajCijeliBroj("Molimo da unesete kontakt djelatnika: (" + dje.Kontakt + "):  "
                , "Decimalni unos obavezan");
            dje.JedinstveniBroj = Pomocno.UcitajCijeliBroj("Molimo da unesete Jedinstveni broj djelatnika: (" + dje.JedinstveniBroj + "):  "
                , "Decimalni unos obavezan");
            dje.VrsteDjelatnika = Pomocno.UcitajString("Molimo da unesete radnu titulu djelatnika: (" + dje.VrsteDjelatnika + "):  "
                    , " Unos titule obavezan");


        }

        private void UnosNovogDjelatnika()
        {

            var dje = new Djelatnik();
            dje.id = Pomocno.UcitajCijeliBroj("Molimo da unesete id djelatnika:  (" + dje.id + "): ",
                "Unos mora biti pozitivni cijeli broj");
            dje.Ime = Pomocno.UcitajString("Molimo da unesete naziv djelatnika: (" + dje.Ime + "):  ",
                "Obavezan unos imena");
            dje.Prezime = Pomocno.UcitajString("Molimo da unesete prezime djelatnika:  (" + dje.Prezime + "): ",
                "Obavezna unos prezimena ");
            dje.Oib = Pomocno.UcitajCijeliBroj("Molimo da unesete oib djelatnika:  (" + dje.Oib + "): "
                , "obavezan unos od 11 brojeva" );
            dje.Kontakt = Pomocno.UcitajCijeliBroj("Molimo da unesete kontakt djelatnika: (" + dje.Kontakt + "):  "
               , "Kontakt broj obavezan");
            dje.JedinstveniBroj = Pomocno.UcitajCijeliBroj("Molimo da unesete jedinstveni broj djelatnika: (" + dje.JedinstveniBroj + "):  "
               , "Broj obavezan !");
            dje.VrsteDjelatnika = Pomocno.UcitajString("Molimo da unesete radnu titulu djelatnika: (" + dje.VrsteDjelatnika + "):  "
               , "Unos titule riječima obavezan");



            Djelatnici.Add(dje);

        }





        public void PrikaziDjelatnike()
        {
            Console.WriteLine();
            Console.WriteLine("---------Dostupni djelatnici-------");
            Console.WriteLine("-----------------------------------");
            foreach (Djelatnik d in Djelatnici)
            {
                Console.WriteLine("Id: {0}  ", d.id);
                Console.WriteLine("Ime: {0}  ", d.Ime);
                Console.WriteLine("Prezime: {0}  ", d.Prezime);
                Console.WriteLine("Oib: {0} ", d.Oib);
                Console.WriteLine("Kontakt: {0} ", d.Kontakt);
                Console.WriteLine("Jedinstveni broj: {0} ", d.JedinstveniBroj);
                Console.WriteLine("Radna titula: {0} ", d.VrsteDjelatnika);
                Console.WriteLine("----------------------------");

            }

        }


        private void TestniPodaci()
        {
            Djelatnici.Add(new Djelatnik() { Ime = "shaw" });
            Djelatnici.Add(new Djelatnik() { Ime = "bbb" });
        }
    }
}



