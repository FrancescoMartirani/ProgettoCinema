namespace ProgettoCinema.Models
{
    public class Spettatore
    {

        public int idSpettatore { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public int idFilm { get; set; }
        public DateTime datanascita { get; set; }
        public Biglietto biglietto  { get; set; }

        public int calcolaEtà()
        {

            DateTime data_oggi = DateTime.Today;
            var età = data_oggi.Year - datanascita.Year;
            return età;

        }

        public void setidFilm(int id)
        {

            idFilm = id;

        }

    }
}
