using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    internal class Beszelgetes
    {
        public DateTime Kezdet { get; private set; }
        public DateTime Vég { get; private set; }
        public string Kezdeményező { get; private set; }
        public string Fogadó { get; private set; }
        public TimeSpan Hossz => Vég - Kezdet;


        public Beszelgetes(string sor)
        {
            //21.09.27-15:00:37;21.09.27-15:04:19;Marci;Krisztián
            string[] seged = sor.Split(';');
            Kezdet = DateTime.ParseExact(seged[0], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
            Vég = DateTime.ParseExact(seged[1], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
            Kezdeményező = seged[2];
            Fogadó = seged[3];
        }
    }
}
