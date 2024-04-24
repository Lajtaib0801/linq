using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton
{
    internal class Versenyzo
    {
        public string Rajtszám { get; private set; }
        public string Kategória { get; private set; }
        public string Név { get; private set; }
        public string Egyesület { get; private set; }
        public string Idő { get; private set; }

        public int IdőMp
        {
            get
            {
                return int.Parse(Idő.Split(':')[0]) * 3600 +  int.Parse(Idő.Split(':')[1]) * 60 + int.Parse(Idő.Split(':')[2]);
            }
        }
        public Versenyzo(string sor)
        {
            string[] seged = sor.Split(';');
            Rajtszám = seged[0];
            Kategória = seged[1];
            Név = seged[2];
            if (seged[3] == null) Egyesület = "";
            else Egyesület = seged[3];
            Idő = seged[4];
        }
    }
}
