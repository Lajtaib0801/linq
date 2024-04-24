using System;

namespace SuperBowl_Gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Megoldas mo = new Megoldas("SuperBowl.txt");
            Console.WriteLine("4. feladat: Döntők száma: {0}",mo.DontokSzama);
            Console.WriteLine("5. feladat: Átlagos pontkülönbség: {0}",mo.AtlagosPontkulonbseg);
            Console.WriteLine("6. feladat: Legmagasabb nézőszám a döntők során:");
            mo.Kiiras(mo.LegmagasabbNezettség);
            mo.SuperBowlNew();
            Console.ReadKey();
        }
    }
}
