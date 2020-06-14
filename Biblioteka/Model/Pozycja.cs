namespace Biblioteka.Model
{
    using System;

    class Pozycja
    {
        public int Id { get; set; }

        public string Tytul { get; set; }
              
        public string Wydawnictwo { get; set; }

        public int RokWydania { get; set; }

        public int IloscEgzemplazyDostepnych { get; set; }

        public int IloscEgzemplazyWypozyczonych { get; set; }

        public bool MoznaWypozyczyc()
        {
            if (IloscEgzemplazyDostepnych > 0)
                return true;

            return false;
        }

        public void Wypozycz()
        {
            if (MoznaWypozyczyc())
            {
                IloscEgzemplazyDostepnych--;
                IloscEgzemplazyWypozyczonych++;
            }
            else
            {
                Console.Out.WriteLine("Brak pozycji na stanie.");
            }
        }
    }
}