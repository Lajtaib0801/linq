using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Megoldas mo = new Megoldas("SuperBowl.txt");
            Console.WriteLine("4. feladat: Dontok szama: {0}",mo.DontokSzama);
            Console.WriteLine("5. feladat: Atlagos pontkulonbseg: {0}",mo.AtlagosPontkulonbseg);
            Console.WriteLine("6. feladat: Legmagasabb nezoszam a dontok soran:");
            Console.WriteLine($"\tSorszam (datum): {new RomaiSorszam(mo.LegtobbNezovelRendelkezoDonto.Ssz).ArabSsz} ({mo.LegtobbNezovelRendelkezoDonto.Datum})");
            Console.WriteLine($"\tGyoztes csapat: {mo.LegtobbNezovelRendelkezoDonto.Gyoztes}, szerzett pontok: {mo.LegtobbNezovelRendelkezoDonto.GyoztesPont}");
            Console.WriteLine($"\tVesztes csapat: {mo.LegtobbNezovelRendelkezoDonto.Vesztes}, szerzett pontok: {mo.LegtobbNezovelRendelkezoDonto.VesztesPont}");
            Console.WriteLine($"\tHelyszin: {mo.LegtobbNezovelRendelkezoDonto.Helyszin}");
            Console.WriteLine($"\tVaros, allam: {mo.LegtobbNezovelRendelkezoDonto.VarosAllam}");
            Console.WriteLine($"\tNezoszam: {mo.LegtobbNezovelRendelkezoDonto.Nezoszam}");
            mo.SuperBowlNew();
            Console.ReadKey();
        }
    }
}
