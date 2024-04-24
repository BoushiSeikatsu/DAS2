using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Role
    {
        public int Role_id { get; set; }
        public string Nazev { get; set; }
        public string Privilegie { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public DateTime Posledni_zmena { get; set; }

        public Role() { }
        public Role(int role_id, string nazev, string privilegie, DateTime datum_vytvoreni, DateTime posledni_zmena)
        {
            Role_id = role_id;
            Nazev = nazev;
            Privilegie = privilegie;
            Datum_vytvoreni = datum_vytvoreni;
            Posledni_zmena = posledni_zmena;
        }
    }
}
