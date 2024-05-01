using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Typ_projektuGateway
    {
        public List<Typ_projektu> GetAll(SqlConnection connection)
        {
            List<Typ_projektu> list  = new List<Typ_projektu>();
            string commandString = "Select * from typ_projektu";
            using(SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = commandString;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Typ_projektu result = new Typ_projektu();
                        result.Typ_projektu_id = reader.GetInt32(0);
                        result.Nazev = reader.GetString(1);
                        result.Datum_vytvoreni = reader.GetDateTime(2);
                        result.Posledni_zmena = reader.GetDateTime(3);
                        list.Add(result);
                    }
                }
            }
            return list;
        }

        public int GetIDByNazev(SqlConnection connection,  string nazev) 
        {
            List<Typ_projektu> list = GetAll(connection);
            foreach(Typ_projektu record in list)
            {
                if(record.Nazev == nazev)
                {
                    return record.Typ_projektu_id;
                }
            }
            return -1;
        }
    }
}
