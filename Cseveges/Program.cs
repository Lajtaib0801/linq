using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Megoldas mo = new Megoldas("csevegesek.txt");
            mo.TagokBeolvas("tagok.txt");
            Console.WriteLine("4. feladat: Tagok száma: {0}fő - Beszélgetések: {1}db",mo.TagokSzama, mo.BeszelgetesekSzama);
            Console.WriteLine("5. feladat: Legosszabb beszélgetés adatai:");
            Console.WriteLine("\tKezdeményező:\t{0}",mo.LeghosszabbBeszelgetes.Kezdeményező);
            Console.WriteLine("\tFogadó:\t\t{0}",mo.LeghosszabbBeszelgetes.Fogadó);
            Console.WriteLine("\tKezdete:\t{0}",mo.LeghosszabbBeszelgetes.Kezdet.ToString("yy.MM.dd-HH:mm:ss"));
            Console.WriteLine("\tVége:\t\t{0}",mo.LeghosszabbBeszelgetes.Vég.ToString("yy.MM.dd-HH:mm:ss"));
            Console.WriteLine("\tHossz:\t\t{0}mp",mo.LeghosszabbBeszelgetes.Hossz.TotalSeconds);
            Console.Write("6. feladat: Adja meg egy tag nevét: ");
            string nev = Console.ReadLine();
            Console.WriteLine("\tA beszélgetések összes ideje: {0}",mo.AdottTagBeszélgetettIdeje(nev));
            Console.WriteLine("7. feladat: Nem beszélgettek senkivel");
            foreach (var item in mo.NemBeszélgettek2)
            {
                Console.WriteLine("\t{0}",item);
            }
            
            Console.ReadKey();
        }
    }
}
