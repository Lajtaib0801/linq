using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton
{
    internal class Megoldas
    {
        List<Versenyzo> versenyzok = new List<Versenyzo>();
        public Megoldas(string filename) =>
            File.ReadAllLines(filename).Skip(1).ToList().ForEach(x => versenyzok.Add(new Versenyzo(x)));
        public double NemTeljesitokArany => (691 - (double)versenyzok.Count) / 691;
        public int RövidtávúNőiFő => versenyzok.Where(x => new Versenytav(x.Rajtszám).getTav() == "Rövid")
            .Where(x => x.Kategória[x.Kategória.Length - 1] == 'n').Count();
        public bool VoltEHatÓraFelettiLinq => versenyzok.Where(x => x.Idő.Split(':')[0] == "6").Any();
        public Versenyzo Gyoztes => versenyzok.Where(x => x.Rajtszám[0] == 'R').Where(x => x.Kategória == "ff").OrderBy(x => x.IdőMp).First();
        public Dictionary<string, int> Stat => versenyzok.Where(x => x.Kategória[x.Kategória.Length - 1] == 'f').GroupBy(x => x.Kategória)
            .ToDictionary(x => x.Key, x => versenyzok.Where(y => y.Kategória == x.Key).Count());

    }
}
