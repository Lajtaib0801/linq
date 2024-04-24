using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Megoldas mo = new Megoldas("bukkm2019.txt");
            Console.WriteLine("4. feladat: Versenytávot nem teljesítők: {0:P14}",mo.NemTeljesitokArany);
            Console.WriteLine("5. feladat: Női versenyzők száma rövidtávú versenyen: {0}fő",mo.RövidtávúNőiFő);
            Console.WriteLine("6. feladat: {0} ilyen versenyző", mo.VoltEHatÓraFelettiLinq ? "Volt" : "Nem volt");
            Console.WriteLine("7. feladat: A felnőtt férfi (ff) kategória győztese rövid távon");
            Console.WriteLine("\tRajtszám: {0}",mo.Gyoztes.Rajtszám);
            Console.WriteLine("\tNév: {0}", mo.Gyoztes.Név);
            Console.WriteLine("\tEgyesület: {0}", mo.Gyoztes.Egyesület);
            Console.WriteLine("\tIdő {0}", mo.Gyoztes.Idő);
            Console.WriteLine("8. feladat: Statisztika");
            foreach (var item in mo.Stat)
            {
                Console.WriteLine("\t{0} - {1}fő",item.Key,item.Value);
            }
            Console.ReadKey();
        }
    }
}
