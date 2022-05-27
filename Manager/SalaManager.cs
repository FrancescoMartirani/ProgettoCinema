using ProgettoCinema.Models;
using System.Data.SqlClient;

namespace ProgettoCinema.Manager
{
    public class SaleManager
    {

        private static string ConnectionString = @"Server = ACADEMYNETPD01\SQLEXPRESS; Database = Cinema; Trusted_Connection = True; ";

        public List<SalaCinematografica> getSale(int idCinema)
        {

            List<SalaCinematografica> saleList = new List<SalaCinematografica>();
            string sql = @"SELECT * FROM Sale JOIN Cinemas ON Cinemas.IdCinema = Sale.IdCinema WHERE [Cinemas].IdCinema = @IdCinema";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdCinema", idCinema);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var sala = new SalaCinematografica
                {

                    idSala = Convert.ToInt32(reader["IdSala"].ToString()),
                    nomeSala = reader["NomeSala"].ToString(),
                    postiOccupati = Convert.ToInt32(reader["PostiOccupati"].ToString()),

                };

                saleList.Add(sala);

            }

            return saleList;

        }

        public bool svuotaSala(SalaCinematografica sala)
        {   

            string sql = @"UPDATE Sale SET PostiOccupati = 0 WHERE IdSala = @IdSala";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSala", sala.idSala);

            return command.ExecuteNonQuery() > 1;

        }

    }
}
