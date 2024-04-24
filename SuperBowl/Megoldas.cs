using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    internal class Megoldas
    {
        List<Donto> dontok = new List<Donto>();
        public Megoldas(string filename)
        {
            File.ReadAllLines(filename).Skip(1).ToList().ForEach(x => dontok.Add(new Donto(x)));
        }
        public int DontokSzama => dontok.Count;
        public double AtlagosPontkulonbseg => Math.Round(dontok.Average(x => x.GyoztesPont - x.VesztesPont),1);
        public Donto LegtobbNezovelRendelkezoDonto => dontok.OrderByDescending(x => x.Nezoszam).First();
        public void SuperBowlNew()
        {
            List<string> newFile = new List<string>();
            newFile.Add("Ssz;Datum;Gyoztes;Eredmeny;Vesztes;Nezoszam");
            foreach (var item in dontok)
            {
                newFile.Add($"{new RomaiSorszam(item.Ssz).ArabSsz};" +
                    $"{item.Datum};" +
                    $"{item.Gyoztes} ({dontok.Take(int.Parse(new RomaiSorszam(item.Ssz).ArabSsz.TrimEnd('.'))).Count(x => x.Gyoztes == item.Gyoztes || x.Vesztes == item.Gyoztes)});" +
                    $"{item.Eredmeny};" +
                    $"{item.Vesztes} ({dontok.Take(int.Parse(new RomaiSorszam(item.Ssz).ArabSsz.TrimEnd('.'))).Count(x => x.Vesztes == item.Vesztes || item.Vesztes == x.Gyoztes)});" +
                    $"{item.Nezoszam}");
            }
            File.WriteAllLines("SuperBowlNew.txt",newFile);
        }
    }
}
