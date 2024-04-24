using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBowl_Gyak
{
    internal class Donto
    {
        public string Ssz { get; private set; }
        public string Dátum { get; private set; }
        public string Győztes { get; private set; }
        public string Eredmény { get; private set; }
        public string Vesztes { get; private set; }
        public string Helyszín { get; private set; }
        public string VárosÁllam { get; private set; }
        public int Nézőszám { get; private set; }
        public int GyoztesPontok { get { return int.Parse(Eredmény.Split('-')[0]); } }
        public int VesztesPontok { get { return int.Parse(Eredmény.Split('-')[1]); } }


        public int Különbség { get { return Math.Abs(GyoztesPontok - VesztesPontok); } }

        public Donto(string sor)
        {
            string[] seged = sor.Split(';');
            Ssz = seged[0];
            Dátum = seged[1];
            Győztes = seged[2];
            Eredmény = seged[3];
            Vesztes = seged[4];
            Helyszín = seged[5];
            VárosÁllam = seged[6];
            Nézőszám = int.Parse(seged[7]);
        }
    }
}
