namespace ProgettoCinema.Models
{
    public class Spettatore
    {

        public int idSpettatore { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public DateTime datanascita { get; set; }
        public Biglietto biglietto  { get; set; }

    }
}
