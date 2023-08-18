
// DZ
//		Kreiraj program koji će koristeći for petlje
//		automatizirati ispis tablice množenja u ovom obliku:
//		-------------------------------
//		: : :  TABLICA  MNOZENJA  : : :
//		-------------------------------
//		 * |  1  2  3  4  5  6  7  8  9
//		-------------------------------
//		 1 |  1  2  3  4  5  6  7  8  9
//		 2 |  2  4  6  8 10 12 14 16 18
//		 3 |  3  6  9 12 15 18 21 24 27
//		 4 |  4  8 12 16 20 24 28 32 36
//		 5 |  5 10 15 20 25 30 35 40 45
//		 6 |  6 12 18 24 30 36 42 48 54
//		 7 |  7 14 21 28 35 42 49 56 63
//		 8 |  8 16 24 32 40 48 56 64 72
//		 9 |  9 18 27 36 45 54 63 72 81
//		-------------------------------
//		:  :  :  :  :  :   :by Tomislav
//		-------------------------------
//		Umjesto "Ime" treba ispisati ime uneseno s
//		konzole i pri tome pripaziti da zadnje slovo
//		imena bude poravnato s desnim rubom tablice.



Console.Write("Molimo upišite vaše ime: ");
string ime = Console.ReadLine();
string j;
string v;

for (int a = 0; a < 9;a++)
{
    if (a == 0 | a == 2 | a == 4 | a == 6 | a == 8)
    {
        Console.WriteLine("-------------------------------");
    }
    else if (a == 1)
    {
        Console.WriteLine(": : :  TABLICA  MNOZENJA  : : :");
    }
    else if (a == 3)
    {
        Console.Write(" * |");
        for (int d = 1; d < 10; d++)
        {
            Console.Write("  " + d);
        }
        Console.WriteLine();
    }

    else if (a == 5)
    {

        for (int l = 1; l < 10; l++)
        {
            Console.Write(" " + l + " |");
            for (int m = 1; m < 10; m++)
            {
                j  = "   " + l * m;
                Console.Write(j[^3..]);
            }
            Console.WriteLine();
        }
    }

    else if (a == 7)
    {
        v = ":  :  :  :  :  :  :  :  :  :  :  :  " + "by " + ime;
        Console.WriteLine(v[^31..]);

    }

}