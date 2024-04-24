using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Ukol
    {
        public int Ukol_id { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public int Priorita { get; set; }
        public Stav_ukolu Stav_ukolu { get; set; }
        public DateTime Nejzazsi_termin { get; set; }
        public Projekt Projekt { get; set; }
        public Uzivatel Uzivatel { get; set; }
        public DateTime Datum_vybrani { get; set; }
        public DateTime Datum_dokonceni { get; set; }
        public int Predpo_cas { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public DateTime Posledni_zmena { get; set; }

        public Ukol(int ukol_id, string nazev, string popis, int priorita, Stav_ukolu stav_ukolu, DateTime nejzazsi_termin, Projekt projekt, Uzivatel uzivatel, DateTime datum_vybrani, DateTime datum_dokonceni, int predpo_cas, DateTime datum_vytvoreni, DateTime posledni_zmena)
        {
            Ukol_id = ukol_id;
            Nazev = nazev;
            Popis = popis;
            Priorita = priorita;
            Stav_ukolu = stav_ukolu;
            Nejzazsi_termin = nejzazsi_termin;
            Projekt = projekt;
            Uzivatel = uzivatel;
            Datum_vybrani = datum_vybrani;
            Datum_dokonceni = datum_dokonceni;
            Predpo_cas = predpo_cas;
            Datum_vytvoreni = datum_vytvoreni;
            Posledni_zmena = posledni_zmena;
        }
        public Ukol()
        {
            
        }
    }
}
