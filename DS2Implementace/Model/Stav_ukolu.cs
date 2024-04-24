using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Stav_ukolu
    {
        public int Stav_ukolu_id { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public DateTime Posledni_zmena { get; set; }

        public Stav_ukolu() { }
        public Stav_ukolu(int stav_ukolu_id, string nazev, string popis, DateTime datum_vytvoreni, DateTime posledni_zmena)
        {
            Stav_ukolu_id = stav_ukolu_id;
            Nazev = nazev;
            Popis = popis;
            Datum_vytvoreni = datum_vytvoreni;
            Posledni_zmena = posledni_zmena;
        }
    }
}
