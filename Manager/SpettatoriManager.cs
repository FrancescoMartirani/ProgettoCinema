using ProgettoCinema.Models;
using System.Data.SqlClient;

namespace ProgettoCinema.Manager
{
    public class SpettatoriManager
    {

        private static string ConnectionString = @"Server = ACADEMYNETPD01\SQLEXPRESS; Database = Cinema; Trusted_Connection = True; ";

        public bool aggiungiSpettatore(Spettatore spettatore)
        {

            string sql = @"INSERT INTO Spettatori (Nome,Cognome,DataNascita,IdBiglietto) VALUES (@Nome,@Cognome,@DataNascita,@IdBiglietto)";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", spettatore.nome);
            command.Parameters.AddWithValue("@Cognome", spettatore.cognome);
            command.Parameters.AddWithValue("@DataNascita", spettatore.datanascita);
            command.Parameters.AddWithValue("@IdBiglietto", spettatore.biglietto.idBiglietto);

            var managerSale = new SaleManager();
            managerSale.updatePosti(spettatore.idFilm);

            return command.ExecuteNonQuery() > 1;

        }
    }
}
