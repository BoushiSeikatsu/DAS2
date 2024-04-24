using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Typ_projektu
    {
        public int Typ_projektu_id { get; set; }
        public string Nazev { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public DateTime Posledni_zmena { get; set; }

        public Typ_projektu()
        {
            
        }
        public Typ_projektu(int typ_projektu_id, string nazev, DateTime datum_vytvoreni, DateTime posledni_zmena)
        {
            Typ_projektu_id = typ_projektu_id;
            Nazev = nazev;
            Datum_vytvoreni = datum_vytvoreni;
            Posledni_zmena = posledni_zmena;
        }
    }
}
