using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS2Implementace.Model
{
    internal class Stav_ukoluGateway
    {
        public Stav_ukolu GetOne(SqlConnection connection, int id)
        {
            Stav_ukolu result = new Stav_ukolu();
            string commandString = "Select * FROM Stav_ukolu WHERE stav_ukolu_id = @id";
            using(SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = commandString;
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                reader.Read();
                result.Stav_ukolu_id = (int)reader[0];
                result.Nazev = (string)reader[1];
                result.Popis = (string)reader[2];
                result.Datum_vytvoreni = (DateTime)reader[3];
                result.Posledni_zmena = (DateTime)reader[4];
            }
            return result;
        }
        public List<Stav_ukolu> GetAll(SqlConnection connection)
        {
            List<Stav_ukolu> list = new List<Stav_ukolu>();
            string commandString = "Select * From Stav_ukolu";
            using(SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = commandString;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stav_ukolu result = new Stav_ukolu();
                        result.Stav_ukolu_id = (int)reader[0];
                        result.Nazev = (string)reader[1];
                        result.Popis = (string)reader[2];
                        result.Datum_vytvoreni = (DateTime)reader[3];
                        result.Posledni_zmena = (DateTime)reader[4];
                        list.Add(result);
                    }
                }
            }
            return list;
        }
        public int GetIDByNazev(SqlConnection connection, string nazev)
        {
            List<Stav_ukolu> list = GetAll(connection);
            foreach(Stav_ukolu record in list)
            {
                if(record.Nazev == nazev)
                {
                    return record.Stav_ukolu_id;
                }
            }
            return -1;
        }
    }
}
