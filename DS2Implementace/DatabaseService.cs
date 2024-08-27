using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Numerics;
using DS2Implementace.Model;

namespace DS2Implementace
{
    internal class DatabaseService
    {
        public DatabaseService() { }
        public void RunServerSide(string procedureName, List<SqlParameter> parameters)
        {
            string connectionString = @"******************;";
            // List of parameters (if any)


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure

                        // Add parameters to the command
                        command.Parameters.AddRange(parameters.ToArray());

                        // Execute the stored procedure
                        command.ExecuteNonQuery(); // For non-query procedures (updates, deletes, inserts)
                                                   // Alternatively, use command.ExecuteReader() for procedures returning data sets
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions here
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Stored procedure executed successfully!");
        }
        public bool RunClientSide(int projectId)
        {
            string connectionString = @"Server=dbsys.cs.vsb.cz\sqldb;Database=DUB0074;User Id=DUB0074;Password=LHj9H0QZW78EKN6v;TrustServerCertificate=True;";
            int v_id_stavu;
            int v_id_typu;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Select pro IDčka
                Stav_ukoluGateway stav_UkoluGateway = new Stav_ukoluGateway();
                Typ_projektuGateway typ_ProjektuGateway = new Typ_projektuGateway();
                v_id_stavu = stav_UkoluGateway.GetIDByNazev(connection, "Archivovany");
                v_id_typu = typ_ProjektuGateway.GetIDByNazev(connection, "Archivovany");
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string queryString = @"
                        UPDATE UKOL 
                        SET Stav_ukolu_Stav_ukolu_id = @v_id_stavu, 
                            Posledni_zmena = CURRENT_TIMESTAMP 
                        WHERE Projekt_Projekt_id = @p_projekt_id 
                            AND Stav_ukolu_Stav_ukolu_id != @v_id_stavu";
                        using (SqlCommand updateTaskCommand = new SqlCommand(queryString, connection))
                        {
                            // Nastaveni ukolu na archivovane


                            updateTaskCommand.Parameters.AddWithValue("@p_projekt_id", projectId);
                            updateTaskCommand.Parameters.AddWithValue("@v_id_stavu", v_id_stavu);
                            updateTaskCommand.Transaction = transaction;
                            updateTaskCommand.ExecuteNonQuery();
                        }
                        queryString = @"
                        INSERT INTO Historie_uzivatelu(Uzivatel_Uzivatel_id, Projekt_Projekt_id) 
                        SELECT Uzivatel_Uzivatel_id, Projekt_Projekt_id 
                        FROM Uzivatel_Projekt 
                        WHERE Projekt_Projekt_id = @p_projekt_id";
                        using (SqlCommand insertHistoryCommand = new SqlCommand(queryString, connection))
                        {
                            // Presun uzivatelu do Historie_uzivatelu

                            insertHistoryCommand.Parameters.AddWithValue("@p_projekt_id", projectId);
                            insertHistoryCommand.Transaction = transaction;
                            insertHistoryCommand.ExecuteNonQuery();
                        }
                        queryString = @"
                        DELETE Uzivatel_Projekt 
                        WHERE Projekt_Projekt_id = @p_projekt_id";
                        using (SqlCommand deleteUserProjectCommand = new SqlCommand(queryString, connection))
                        {
                            // Smazani uzivatelu z projektu

                            deleteUserProjectCommand.Parameters.AddWithValue("@p_projekt_id", projectId);
                            deleteUserProjectCommand.Transaction = transaction;
                            deleteUserProjectCommand.ExecuteNonQuery();
                        }
                        queryString = @"
                        UPDATE Projekt 
                        SET Typ_projektu_Typ_projektu_id = @v_id_typu, 
                            Posledni_zmena = CURRENT_TIMESTAMP 
                        WHERE Projekt_id = @p_projekt_id";
                        using (SqlCommand updateProjectCommand = new SqlCommand(queryString, connection))
                        {
                            // Nastaveni typu projektu na archivovany

                            updateProjectCommand.Parameters.AddWithValue("@p_projekt_id", projectId);
                            updateProjectCommand.Parameters.AddWithValue("@v_id_typu", v_id_typu);
                            updateProjectCommand.Transaction = transaction;
                            updateProjectCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
            }    
        }
    }
}
