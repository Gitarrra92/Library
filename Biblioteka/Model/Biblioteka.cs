namespace Biblioteka.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Biblioteka
    {
        private int _idKlienta = 0;

        private int _idPozycja = 0;

        private int _idWypozyczenia = 0;

        private string nazwaPliku = "biblioteka.csv";

        private List<Klient> _klienci; 

        public List<Klient> Klienci { get; set; }

        public List<Wypozyczenie> Wypozyczenia { get; set; }

        public List<Pozycja> Pozycje { get; set; }

        public Biblioteka()
        {
            Klienci = new List<Klient>();
            Wypozyczenia = new List<Wypozyczenie>();
            Pozycje = new List<Pozycja>();
        }

        public void WprowadzKlienta()
        {
            Klient nowyKlient = new Klient();
            nowyKlient.Id = ++_idKlienta;
            Console.Out.WriteLine("Podaj imię: ");
            var imie = Console.ReadLine();
            nowyKlient.Imie = imie;
            Console.Out.WriteLine("Podaj nazwisko: ");
            var nazwisko = Console.ReadLine();
            nowyKlient.Nazwisko = nazwisko;

            Klienci.Add(nowyKlient);
            Console.Out.WriteLine("Dodano klienta. ID = " + _idKlienta);
        }


        public void WprowadzKsiazke()
        {
            Ksiazka nowaKsiazka = new Ksiazka();
            nowaKsiazka.Id = ++_idPozycja;

            Console.Out.WriteLine("Podaj tytul: ");
            var tytul = Console.ReadLine();
            nowaKsiazka.Tytul = tytul;
            Console.Out.WriteLine("Podaj wydawnictwo: ");
            var wydawnictwo = Console.ReadLine();
            nowaKsiazka.Wydawnictwo = wydawnictwo;
            Console.Out.WriteLine("Podaj autora: ");
            var autor = Console.ReadLine();
            nowaKsiazka.Autor = autor;

            Console.Out.WriteLine("Podaj rok wydania: ");
            var rokWydania = Console.ReadLine();
            nowaKsiazka.RokWydania = Convert.ToInt32(rokWydania);
       
            Console.Out.WriteLine("Podaj ilosc egzemplarzy: ");
            var iloscEgzemplarzy = Console.ReadLine();
            nowaKsiazka.IloscEgzemplazyDostepnych = Convert.ToInt32(iloscEgzemplarzy);

            Pozycje.Add(nowaKsiazka);
            Console.Out.WriteLine("Dodano ksiazkę. ID = " + _idPozycja);
        }


        public void WprowadzCzasopismo()
        {
            Czasopismo noweCzasopismo = new Czasopismo();
            ;
            noweCzasopismo.Id = ++_idPozycja;

            Console.Out.WriteLine("Podaj tytul: ");
            var tytul = Console.ReadLine();
            noweCzasopismo.Tytul = tytul;
            Console.Out.WriteLine("Podaj wydawnictwo: ");
            var wydawnictwo = Console.ReadLine();
            noweCzasopismo.Wydawnictwo = wydawnictwo;
            Console.Out.WriteLine("Podaj nr wydania: ");
            var nrWydania = Console.ReadLine();
            noweCzasopismo.NumerWydania = Convert.ToInt32(nrWydania);

            Console.Out.WriteLine("Podaj rok wydania: ");
            var rokWydania = Console.ReadLine();
            noweCzasopismo.RokWydania = Convert.ToInt32(rokWydania);

            Console.Out.WriteLine("Podaj ilosc egzemplarzy: ");
            var iloscEgzemplarzy = Console.ReadLine();
            noweCzasopismo.IloscEgzemplazyDostepnych = Convert.ToInt32(iloscEgzemplarzy);

            Pozycje.Add(noweCzasopismo);
            Console.Out.WriteLine("Dodano czasopismo. ID = " + _idPozycja);
        }

        public void WypozyczKsiazke()
        {
            Console.Out.WriteLine("Podaj Id Klienta: ");
            var idKlienta = Convert.ToInt32(Console.ReadLine());

            var znalazlKlienta = false;
            foreach (var klient in Klienci)
            {
                 // sprawdz czy istnieje w systemie klient o podanym ID    
                if (klient.Id == idKlienta)
                {
                    znalazlKlienta = true;
                    Console.Out.WriteLine("Podaj Id Pozycji: ");
                    var idPozycji = Convert.ToInt32(Console.ReadLine());

                    var znalazlPozycje = false;
               
                    // przeszukanie kolekcji z pozycjami 
                    foreach (var pozycja in Pozycje)
                    {
                        // sprawdz czy istnieje taka pozycja w systemie 
                        if (pozycja.Id == idPozycji)
                        {
                            znalazlPozycje = true;

                            if (pozycja.MoznaWypozyczyc())
                            {
                                pozycja.Wypozycz();

                                var noweWypozyczenie = new Wypozyczenie();
                                noweWypozyczenie.Id = ++_idWypozyczenia;
                                noweWypozyczenie.Klient = klient;
                                noweWypozyczenie.Pozycja = pozycja;
                                noweWypozyczenie.DataWypozyczenia = DateTime.Now;
                                noweWypozyczenie.DataZwrotu = DateTime.Now.AddDays(2 * 7);

                                Console.Out.WriteLine("Dodano wypozyczenie. ID = " + _idWypozyczenia);
                            }
                            else
                            {
                                Console.Out.WriteLine("Brak pozycji na stanie.");
                            }
                        }
                    }

                    if (znalazlPozycje == false)
                    {
                        Console.Out.WriteLine("Nie znaleziono pozycji o takim ID.");
                    }
                }
            }

            if (znalazlKlienta == false)
            {
                Console.Out.WriteLine("Nie znaleziono klienta o takim ID.");
            }
        }

        public void ZapiszDoPliku()
        {
            // zapisz stan katalogowy 
            var sciezkaDoPliku = Path.Combine(Directory.GetCurrentDirectory(), nazwaPliku);

            try
            {
                using (var w = new StreamWriter(sciezkaDoPliku))
                {
                    w.WriteLine("ID;Tytul;Wydawnictwo;RokWydania;IloscEgzemplarzyDostepnych;IloscEgzemplarzyWypozyczonych");
                    foreach (var pozycja in Pozycje)
                    {
                        var wiersz = string.Format("{0};{1};{2};{3};{4};{5}",
                            pozycja.Id,
                            pozycja.Tytul,
                            pozycja.Wydawnictwo,
                            pozycja.RokWydania,
                            pozycja.IloscEgzemplazyDostepnych,
                            pozycja.IloscEgzemplazyWypozyczonych);

                        w.WriteLine(wiersz);
                        w.Flush();
                    }

                    Console.Out.WriteLine("Zapisane dane do pliku.");
                }
            }
            catch 
            {
                Console.Out.WriteLine("Wystapił problem z zapisem stanu katalogowego.");
            } 
        }
    }
}