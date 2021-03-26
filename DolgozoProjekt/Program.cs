using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjekt
{
    class Program
    {
        static List<Dolgozo> dolgozok = new List<Dolgozo>();
        static void Main(string[] args)
        {
            Beolvasas();

            Feladat3();

            Feladat4();

            Feladat5();
            
            Feladat6();
            
            Feladat7();

            Feladat8();

            Console.ReadKey();
        }

        private static void Feladat8()
        {
            var diakok = dolgozok.FindAll(d => d.Eletkor < 18);
            StreamWriter sw = new StreamWriter("diakok.txt");
            foreach (var diak in diakok)
            {
                sw.WriteLine("{0} {1} {2} {3} {4} Ft", diak.Vezeteknev, diak.Keresztnev, diak.Nem, diak.Eletkor, diak.Fizetes);
            }
            sw.Close();
        }

        private static void Feladat7()
        {
            Console.Write("7. Feladat: Diákok száma életkor szerint csoportosítva:");
            var fiatalokCsoportja = dolgozok.FindAll(d => d.Eletkor < 18).GroupBy(f => f.Eletkor);
            foreach (var fiatal in fiatalokCsoportja)
            {
                Console.Write("\n\t{0} éves: {1} fő", fiatal.Key, fiatal.Count());
            }
        }

        private static void Feladat6()
        {
            Console.Write("6. feladat: Kérem adjon meg egy összeget: ");
            
            bool szamE = Int32.TryParse(Console.ReadLine(), out int osszeg);
            if (szamE)
            {
                if (dolgozok.FindAll(d => d.Fizetes > osszeg).Count > 0)
                {
                    Console.WriteLine("\tVan olyan dolgozó, akinek a fizetése {0} Ft felett van", osszeg);
                }
                else
                {
                    Console.WriteLine("\tNincs olyan dolgozó, akinek a fizetése {0} Ft felett van", osszeg);
                }
            }
            else
            {
                Console.WriteLine("\tNem számot adott meg.");
                Feladat6();
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("\n5. feladat: A legnagyobb fizetésű dolgozó adatai: " +
                dolgozok.OrderByDescending(d => d.Fizetes).First());
        }

        private static void Feladat4()
        {
            Console.Write("4. feladat: 25 év alattiak összfizetése: ");
            Console.Write(dolgozok.Where(d => d.Eletkor < 25).Sum(e => e.Fizetes) + " Ft");
        }

        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: Dolgozók száma: " + dolgozok.Count);
        }

        private static void Beolvasas()
        {
            StreamReader sr = new StreamReader("adatok.txt");
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                dolgozok.Add(new Dolgozo(
                    temp[0],
                    temp[1],
                    temp[2],
                    Int32.Parse(temp[3]),
                    Int32.Parse(temp[4])
                    ));
            }
        }
    }
}
