using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    internal class Donto
    {
        public string Ssz { get; private set; }
        public string Datum { get; private set; }
        public string Gyoztes { get; private set; }
        public string Eredmeny { get; private set; }
        public string Vesztes { get; private set; }
        public string Helyszin { get; private set; }
        public string VarosAllam { get; private set; }
        public int Nezoszam { get; private set; }
        public int GyoztesPont { get; private set; }
        public int VesztesPont { get; private set; }
        public Donto(string sor)
        {
            string[] seged = sor.Split(';');
            Ssz= seged[0];
            Datum = seged[1];
            Gyoztes = seged[2];
            Eredmeny = seged[3];
            GyoztesPont = int.Parse(seged[3].Split('-')[0]);
            VesztesPont = int.Parse(seged[3].Split('-')[1]);
            Vesztes = seged[4];
            Helyszin = seged[5];
            VarosAllam = seged[6];
            Nezoszam = int.Parse(seged[7]);

        }
    }
}
