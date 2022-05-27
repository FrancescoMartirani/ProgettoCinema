namespace ProgettoCinema.Models
{
    public class Biglietto
    {

        public int idBiglietto { get; set; }
        public int numeroPosto { get; set; }

        public SalaCinematografica salaCinematografica { get; set; }
        public decimal prezzo { get; set; }

    }
}
