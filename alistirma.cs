using System;

namespace Alistirma
{
    class Program
    {
        static string yarimKure;
        static int ay;
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.Write("Hangi ay? ");
                    ay = Convert.ToInt32(Console.ReadLine());
                    if (ay >= 13 || ay <= 0)
                    {
                        Console.WriteLine("HATA! 12 tane ay vardır.");
                    }
                } while (ay >= 13 || ay <= 0);
            }
            catch (Exception)
            {
                Console.WriteLine("HATA! Tekrar deneyiniz lütfen.");
                Main(null);
            }

            Console.Write("Hangi yarım küre: K / G ? ");
            yarimKure = Console.ReadLine();

            if (yarimKure == "K")
            {
                switch (ay)
                {
                    case 1 or 2 or 12:
                        Console.WriteLine("Kış Mevsimi");
                        break;
                    case 3 or 4 or 5:
                        Console.WriteLine("Bahar Mevsimi");
                        break;
                    case 6 or 7 or 8:
                        Console.WriteLine("Yaz Mevsimi");
                        break;
                    case 9 or 10 or 11:
                        Console.WriteLine("Sonbahar Mevsimi");
                        break;
                    default:
                        break;
                }
            }
            else if (yarimKure == "G")
            {
                switch (ay)
                {
                    case 1 or 2 or 12:
                        Console.WriteLine("Yaz Mevsimi");
                        break;
                    case 3 or 4 or 5:
                        Console.WriteLine("Sonbahar Mevsimi");
                        break;
                    case 6 or 7 or 8:
                        Console.WriteLine("Kış Mevsimi");
                        break;
                    case 9 or 10 or 11:
                        Console.WriteLine("İlkbahar Mevsimi");
                        break;
                    default:
                        break;
                }
            }
            else  
            {
                Console.WriteLine("HATA! Lütfen gösterildiği gibi yazınız.");
                Main(null);
            }
        }
    }
}
