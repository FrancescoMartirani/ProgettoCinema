using ProgettoCinema.Models;
using System.Data.SqlClient;

namespace ProgettoCinema.Manager
{
    public class CinemaManager
    {

        private static string ConnectionString = @"Server = ACADEMYNETPD01\SQLEXPRESS; Database = Cinema; Trusted_Connection = True; ";

        public List<Cinema> getAllCinemas()
        {

            List<Cinema> cinemasList = new List<Cinema>();
            string sql = @"SELECT * FROM [dbo].[Cinemas]";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cinema = new Cinema
                {
                    idCinema = Convert.ToInt32(reader["IdCinema"].ToString()),
                    nomeCinema = reader["NomeCinema"].ToString(),
                    indirizzo = reader["Indirizzo"].ToString(),

                };
                cinemasList.Add(cinema);

            }

            return cinemasList;

        }

    }
}
