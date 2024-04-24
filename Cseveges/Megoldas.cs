using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    internal class Megoldas
    {
        List<Beszelgetes> beszelgetesek = new List<Beszelgetes>();
        List<string> tagok = new List<string>();
        public Megoldas(string filename)
        {
            File.ReadAllLines(filename).Skip(1).ToList().ForEach(x => beszelgetesek.Add(new Beszelgetes(x)));
        }
        public void TagokBeolvas(string filename) => File.ReadAllLines(filename).ToList().ForEach(x => tagok.Add(x));
        public int BeszelgetesekSzama => beszelgetesek.Count();
        public int TagokSzama => tagok.Count();
        public Beszelgetes LeghosszabbBeszelgetes => beszelgetesek.OrderByDescending(x => x.Hossz).First();
        public TimeSpan AdottTagBeszélgetettIdeje(string nev) => TimeSpan.FromSeconds(beszelgetesek.Where(x => x.Kezdeményező == nev || x.Fogadó == nev).Sum(x => x.Hossz.TotalSeconds));
        public TimeSpan AdottTagBeszélgetettIdejeSima(string nev)
        {
            TimeSpan ido = new TimeSpan();
            foreach (var item in beszelgetesek)
            {
                if (item.Kezdeményező == nev || item.Fogadó == nev)
                    ido += item.Hossz;
            }
            return ido;
        }

        public List<string> NemBeszélgettek
        {
            get
            {
                List<string> nevek = tagok;
                for (int i = 0; i < beszelgetesek.Count; i++)
                {
                    for (int j = 0; j < nevek.Count; j++)
                    {
                        if (beszelgetesek[i].Kezdeményező == nevek[j] || beszelgetesek[i].Fogadó == nevek[j])
                            nevek.RemoveAt(j);
                    }
                }
                return nevek;
            }
        }
        public List<string> NemBeszélgettek2
        {
            get
            {
                HashSet<string> beszelgettek = new HashSet<string>();
                //foreach (var item in beszelgetesek)
                //{
                //    beszelgettek.Add(item.Kezdeményező);
                //    beszelgettek.Add(item.Fogadó);
                //}
                beszelgettek = beszelgetesek.SelectMany(x => new List<string>() { x.Fogadó, x.Kezdeményező }).ToHashSet();
                return tagok.Except(beszelgettek).ToList();
            }
        }
        public List<string> NemBeszélgettekLinq => tagok.Except(beszelgetesek.Select(x => new List<string>() { x.Fogadó,x.Kezdeményező}).SelectMany(x => x)).ToList();
        public List<string> NemBeszélgettekLinq2 => tagok.Except(beszelgetesek.SelectMany(x => new List<string>() { x.Fogadó,x.Kezdeményező})).ToList();
        //public List<string> Test123 => beszelgetesek.Select(x => new List<string>() { x.Kezdeményező, x.Fogadó }).SelectMany(x => x).ToHashSet().ToList();

    }
}
