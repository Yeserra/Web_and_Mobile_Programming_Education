using System;

namespace HataYakalama
{
    class Program
    {
        static string islem;
        static double s1, s2;

        static void Main()
        {
            try
            {
                Console.WriteLine("Birinci Sayı: ");
                s1 = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Griş!");
                Main();
            }

            try
            {
                Console.WriteLine("İkinci Sayı: ");
                s2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Griş!");
                Main();
            }

            Console.WriteLine("Yapılacak işlemi seçiniz: + - * /");
            islem = Console.ReadLine();
            if (islem == "+")
            {
                ToplamaIslemi(s1, s2);
            }
            else if (islem == "-")
            {
                CikarmaIslemi(s1, s2);
            }
            else if (islem == "*")
            {
                CarpmaIslemi(s1, s2);
            }
            else if (islem == "/")
            {
                BolmeIslemi(s1, s2);
            }
            else if (islem != "+" && islem != "-" && islem != "*" && islem == "/")
            {
                Console.WriteLine("Herhangi bir işlem seçilmedi! HATA!");
                Main();
            }
        }

        static void ToplamaIslemi(double a, double b)
        {
            double t;
            t = a + b;
            Console.WriteLine("Sonuç = " + t);
        }

        static void CikarmaIslemi(double a, double b)
        {
            double t;
            t = a - b;
            Console.WriteLine("Sonuç = " + t);
        }

        static void CarpmaIslemi(double a, double b)
        {
            double t;
            t = a * b;
            Console.WriteLine("Sonuç = " + t);
        }

        static void BolmeIslemi(double a, double b)
        {
            double t;
            t = a / b;
            Console.WriteLine("Sonuç = " + t);
        }
    }
}
