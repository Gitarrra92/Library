namespace Biblioteka.Model
{
    using System;

    class Wypozyczenie
    {
        public int Id { get; set; } 

        public Klient Klient { get; set; }

        public Pozycja Pozycja { get; set; }  

        public DateTime DataWypozyczenia { get; set; }

        public DateTime DataZwrotu { get; set; }
    }
}