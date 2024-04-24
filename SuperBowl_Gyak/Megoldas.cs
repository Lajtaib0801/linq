using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SuperBowl_Gyak
{
    internal class Megoldas
    {
        List<Donto> dontok = new List<Donto>();
        public Megoldas(string forras)
        {
            File.ReadAllLines(forras).Skip(1).ToList().ForEach(x => dontok.Add(new Donto(x)));
        }
        public int DontokSzama => dontok.Count;
        public double AtlagosPontkulonbseg => Math.Round(dontok.Average(x => x.Különbség),1);
        public Donto LegmagasabbNezettség => dontok.OrderByDescending(x => x.Nézőszám == dontok.Max(y => y.Nézőszám)).First();
        public void Kiiras(Donto maxNezettsegDonto)
        {

            Console.WriteLine("\tSorszám (dátum): {0} ({1})", new RomaiSorszam(maxNezettsegDonto.Ssz).ArabSsz,maxNezettsegDonto.Dátum);
            Console.WriteLine("\tGyőztes csapat: {0}, szerzett pontok: {1}", maxNezettsegDonto.Győztes,maxNezettsegDonto.GyoztesPontok);
            Console.WriteLine("\tVesztes csapat: {0}, szerzett pontok: {1}", maxNezettsegDonto.Vesztes, maxNezettsegDonto.VesztesPontok);
            Console.WriteLine("\tHelyszín: {0}", maxNezettsegDonto.Helyszín);
            Console.WriteLine("\tVáros, állam: {0}, {1}", maxNezettsegDonto.VárosÁllam.Split(',')[0].Trim(), maxNezettsegDonto.VárosÁllam.Split(',')[1].Trim());
            Console.WriteLine("\tNézőszám: {0}", maxNezettsegDonto.Nézőszám);
        }
        public void SuperBowlNew()
        {
            List<string> superBowlNew= new List<string>();
            superBowlNew.Add("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
            foreach (var item in dontok)
            {
                superBowlNew.Add($"{new RomaiSorszam(item.Ssz).ArabSsz};" +
                    $"{item.Dátum};" +
                    $"{item.Győztes} ({dontok.Take(int.Parse(new RomaiSorszam(item.Ssz).ArabSsz.TrimEnd('.'))).Count(x => x.Győztes == item.Győztes || x.Vesztes == item.Győztes)});" +
                    $"{item.Eredmény};" +
                    $"{item.Vesztes} ({dontok.Take(int.Parse(new RomaiSorszam(item.Ssz).ArabSsz.TrimEnd('.'))).Count(x => x.Győztes == item.Vesztes || x.Vesztes == item.Vesztes)});" +
                    $"{item.Nézőszám}");
            }
            File.WriteAllLines("SuperBowlNew.txt", superBowlNew);
        }
    }
}
