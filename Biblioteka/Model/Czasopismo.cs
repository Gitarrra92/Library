namespace Biblioteka.Model
{
    class Czasopismo : Pozycja
    {
        public int EgzemplarzId { get; set; }

        public int NumerWydania { get; set; }
    }
}