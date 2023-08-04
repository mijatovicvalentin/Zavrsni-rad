using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad_BeyondInfinity_
{
    internal class Pomocno
    {
    
        public static int UcitajBrojRaspona(string poruka, string greška, int pocetak, int kraj)
        {
            int b;
            while(true) 
            {

                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if(b >= pocetak && b <= kraj)
                    {
                        return b;
                    }
                    Console.WriteLine(greška);
                    {
                     
                    }
                    
                }
                catch
                {
                    Console.WriteLine(greška);
                }


            }


        }

        internal static int UcitajCijeliBroj(string poruka, string greška)
        {

            int b;
            while(true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if(b > 0 )
                    {
                        return b;
                    }
                    Console.WriteLine(greška);

                }
                catch
                {
                    Console.WriteLine(greška);
                }



            }

        }

        internal static bool UcitajBool(string poruka)
        {

            Console.Write(poruka);
            return Console.ReadLine().Trim().ToLower().Equals("true") ? true : false;
        }

        internal static decimal UcitajDecimalniBroj(string poruka, string greška)
        {
            decimal z;
            while(true)
            {
                Console.Write(poruka);
                try
                {
                    z = decimal.Parse(Console.ReadLine());
                    if(z > 0 )
                    {
                        return z;
                    }
                    Console.WriteLine(greška);
                }
                catch
                {
                    Console.WriteLine(greška);
                }
            }

        }

        internal static string UcitajString(string poruka   , string greška)
        {

            string q = "";
            while(true)
            {
                Console.Write(poruka);
                q = Console.ReadLine();
                if(q!=null && q.Trim().Length > 0)
                {
                    return q;
                }
                Console.WriteLine(greška);

            }
        }
    }
}
