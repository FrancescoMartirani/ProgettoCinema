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
                    postiMassimi = Convert.ToInt32(reader["MaxPosti"].ToString())

                };

                saleList.Add(sala);

            }

            return saleList;

        }

        public void svuotaSala(int id)
        {

            string update = @"UPDATE Sale SET PostiOccupati = 0 WHERE IdSala = @IdSala; ";
            
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(update, connection);
            command.Parameters.AddWithValue("@IdSala", id);
            command.ExecuteNonQuery();

            string select1 = @"SELECT IdBiglietto FROM Biglietti WHERE IdSala = @IdSala;";
            using var command2 = new SqlCommand(select1, connection);
            command2.Parameters.AddWithValue("@IdSala", id);
            int idBiglietto = Convert.ToInt32(command2.ExecuteScalar());

            string delete1 = @"DELETE FROM Spettatori WHERE Spettatori.IdBiglietto = @IdBiglietto ";
            using var command3 = new SqlCommand(delete1, connection);
            command3.Parameters.AddWithValue("@IdBiglietto", idBiglietto);
            command3.ExecuteNonQuery();

            string delete2 = @"DELETE FROM Biglietti WHERE IdSala = @IdSala;";
            using var command4 = new SqlCommand(delete2, connection);
            command4.Parameters.AddWithValue("@IdSala", id);
            command4.ExecuteNonQuery();

        }

        public int getIdSalaByIdFilm (int idFilm)
        {

            string sql = @"SELECT Sale.IdSala FROM Sale JOIN Film ON Film.IdFilm = Sale.IdFilm WHERE Film.IdFilm = @IdFilm";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdFilm", idFilm);

            return Convert.ToInt32(command.ExecuteScalar());

        }

        public bool updatePosti(int idFilm)
        {

            var idSala = getIdSalaByIdFilm(idFilm);

            string sql = @"SELECT PostiOccupati FROM Sale WHERE Sale.IdSala=@IdSala";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSala", idSala);

            var postiOccupati = Convert.ToInt32(command.ExecuteScalar());
            postiOccupati++;

            string sql2 = @"UPDATE Sale SET PostiOccupati=@PostiOccupati WHERE IdSala=@IdSala";
            using var command2 = new SqlCommand(sql2, connection);
            command2.Parameters.AddWithValue("@IdSala", idSala);
            command2.Parameters.AddWithValue("@PostiOccupati", postiOccupati);

            return command2.ExecuteNonQuery()>1;
        }

        public bool controllaPosto(int numeroPosto)
        {

            return true;
        }

    }
}
