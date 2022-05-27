namespace ProgettoCinema.Models
{
    public class SalaCinematografica
    {

        public int idSala { get; set; }
        public string nomeSala { get; set; }

        public int postiMassimi { get; set; }

        public int postiOccupati{ get; set; }
        public Film film { get; set; }

    }
}
