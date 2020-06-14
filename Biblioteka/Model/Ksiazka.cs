namespace Biblioteka.Model
{
    class Ksiazka : Pozycja 
    {
        public int EgzemplarzId { get; set; }

        public string Autor { get; set; }
    }
}