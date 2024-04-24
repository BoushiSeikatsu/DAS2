using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Projekt
    {
        public int Projekt_id { get; set; }
        public Uzivatel Uzivatel { get; set; }
        public Typ_projektu Typ_Projektu { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public DateTime? Posledni_zmena { get; set; }
        public Projekt() { }
        public Projekt(int projektId, Uzivatel uzivatel, Typ_projektu typ_projektu, DateTime datum_vytvoreni, DateTime posledni_zmena)
        {
            Projekt_id = projektId;
            Uzivatel = uzivatel;
            Typ_Projektu = typ_projektu;
            Datum_vytvoreni = datum_vytvoreni;
            Posledni_zmena = posledni_zmena;
        }
    }
}
