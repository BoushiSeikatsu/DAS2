using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Uzivatel
    {
        public int Uzivatel_id { get; set; }
        public string Uzivatelske_jmeno { get; set; }
        public string Krestni_jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Heslo { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public DateTime Datum_vytvoreni { get; set; }
        public DateTime Posledni_zmena { get; set; }
        public DateTime Posledni_login { get; set; }
        public string Prihlasen { get; set; }

        public Uzivatel() { }
        public Uzivatel(int uzivatel_id, string uzivatelske_jmeno, string krestni_jmeno, string prijmeni, string heslo, string email, Role role, DateTime datum_vytvoreni, DateTime posledni_zmena, DateTime posledni_login, string prihlasen)
        {
            Uzivatel_id = uzivatel_id;
            Uzivatelske_jmeno = uzivatelske_jmeno;
            Krestni_jmeno = krestni_jmeno;
            Prijmeni = prijmeni;
            Heslo = heslo;
            Email = email;
            Role = role;
            Datum_vytvoreni = datum_vytvoreni;
            Posledni_zmena = posledni_zmena;
            Posledni_login = posledni_login;
            Prihlasen = prihlasen;
        }
    }
}
