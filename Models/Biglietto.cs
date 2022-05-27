namespace ProgettoCinema.Models
{
    public class Biglietto
    {

        public int idBiglietto { get; set; }
        public int numeroPosto { get; set; }

        public int idSala { get; set; }

        public double prezzo = 12.50;

        public bool maggiorenne(int età)
        {

            if (età >= 18)
                return true;
            else
                return false;

        }

        public void sconto(int età)
        {

            if (età > 70)
                prezzo = prezzo - ((prezzo * 10) / 100);
            if(età<5)
                prezzo = prezzo - ((prezzo * 50) / 100);

        }

    }
 }
