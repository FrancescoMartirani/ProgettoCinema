using ProgettoCinema.Models;
using System.Data.SqlClient;

namespace ProgettoCinema.Manager
{
    public class FilmManager
    {

        private static string ConnectionString = @"Server = ACADEMYNETPD01\SQLEXPRESS; Database = Cinema; Trusted_Connection = True; ";

        public List<Film> getCinemaFilm(int idCinema)
        {

            List<Film> filmList = new List<Film>();
            string sql = @"SELECT Sale.NomeSala, Film.* FROM Film JOIN Sale ON Sale.IdFilm = Film.IdFilm JOIN Cinemas ON Cinemas.IdCinema = Sale.IdCinema WHERE Cinemas.IdCinema = @IdCinema";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdCinema", idCinema);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var film = new Film
                {

                    idFilm = Convert.ToInt32(reader["IdFilm"].ToString()),
                    titolo = reader["Titolo"].ToString(),
                    autore = reader["Autore"].ToString(),
                    produttore = reader["Produttore"].ToString(),
                    genere = reader["Genere"].ToString(),
                    durata = reader["Durata"].ToString(),
                    nomeSala = reader["NomeSala"].ToString()

                };

                filmList.Add(film);

            }

            return filmList;

        }

        public List<Film> getSalaFilm(int idSala)
        {

            List<Film> filmList = new List<Film>();
            string sql = @"SELECT * FROM Film JOIN Sale ON Sale.IdFilm = Film.IdFilm WHERE Sale.IdSala = @idSala";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSala", idSala);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var film = new Film
                {

                    idFilm = Convert.ToInt32(reader["IdFilm"].ToString()),
                    titolo = reader["Titolo"].ToString(),
                    autore = reader["Autore"].ToString(),
                    produttore = reader["Produttore"].ToString(),
                    genere = reader["Genere"].ToString(),
                    durata = reader["Durata"].ToString(),

                };

                filmList.Add(film);

            }

            return filmList;

        }

    }
}
