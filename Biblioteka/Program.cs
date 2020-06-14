namespace Biblioteka
{
    using System;
    using Model;

    class Program
    {
        static void Main(string[] args)
        {
            var biblioteka = new Biblioteka();
            ConsoleKeyInfo info;

            do
            {
                PrintMenu();
                info = Console.ReadKey();
                Console.WriteLine();

                switch (info.KeyChar)
                {
                    case '1':
                        biblioteka.WprowadzKlienta(); 
                        break;
                    case '2': 
                        biblioteka.WprowadzKsiazke();
                        break;
                    case '3':
                        biblioteka.WprowadzCzasopismo();
                        break;
                    case '4':
                        biblioteka.WypozyczKsiazke();
                        break;
                    case '5':
                        biblioteka.ZapiszDoPliku();
                        break;

                }

            } while (info.KeyChar != 'q');

            Console.Out.WriteLine("Program został zakończony.");
            Console.ReadLine();
        }

        private static void PrintMenu()
        {
            Console.Out.WriteLine("=== System Biblioteczny ===");
            Console.Out.WriteLine("Menu: ");
            Console.Out.WriteLine("1: Wprowadz klienta");
            Console.Out.WriteLine("2: Wprowadz pozycję (książkę)");
            Console.Out.WriteLine("3: Wprowadz pozycję (czasopismo)");
            Console.Out.WriteLine("4: Wprowadz wypozyczenie");
            Console.Out.WriteLine("5: Wyeksportuj dane do pliku.");

            Console.Out.WriteLine("q: Zakoncz program.");
            Console.Out.WriteLine("Wybierz opcje z menu:");
        }
    }
}
