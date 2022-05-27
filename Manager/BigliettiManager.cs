using ProgettoCinema.Models;
using System.Data.SqlClient;

namespace ProgettoCinema.Manager
{
    public class BigliettiManager
    {
        private static string ConnectionString = @"Server = ACADEMYNETPD01\SQLEXPRESS; Database = Cinema; Trusted_Connection = True; ";

        public void aggiungiBiglietto(Spettatore spettatore)
        {

            string sql = @"INSERT INTO [dbo].[Biglietti]
                        ([NumeroPosto]
                            ,[IdSala] 
                            ,[Prezzo])
                        OUTPUT INSERTED.IdBiglietto
                        VALUES (@NumeroPosto,
                                @IdSala,
                                @Prezzo)";

            if (!divieto(spettatore))
            {

                spettatore.biglietto.sconto(spettatore.calcolaEtà());
                
                var saleManager = new SaleManager();
                spettatore.biglietto.idSala = saleManager.getIdSalaByIdFilm(spettatore.idFilm);

                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@NumeroPosto", spettatore.biglietto.numeroPosto);
                command.Parameters.AddWithValue("@IdSala", spettatore.biglietto.idSala);
                command.Parameters.AddWithValue("@Prezzo", spettatore.biglietto.prezzo);

                var idBiglietto = Convert.ToInt32(command.ExecuteScalar());

                if(idBiglietto > 0)
                {

                    spettatore.biglietto.idBiglietto = idBiglietto;
                    var spettatoriManager = new SpettatoriManager();
                    spettatoriManager.aggiungiSpettatore(spettatore);

                }

            }

            else
            {
                throw new Exception("Film Vietato");

            }

        }

        public bool divieto(Spettatore spettatore)
        {

            string sql = @"SELECT Genere FROM Film WHERE IdFilm = @IdFilm ";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@IdFilm", spettatore.idFilm);

            var genere = command.ExecuteScalar().ToString();

            var divieto = true;

            if(genere == "Horror")
            {

                if (spettatore.calcolaEtà() > 14 ){

                    divieto = false;
                }

                else
                {

                    divieto = true;

                }

            }

            else
            {

                divieto = false;

            }

            return divieto;

        }

    }
}
