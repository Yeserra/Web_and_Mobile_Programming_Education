using System;

namespace HesapMakinesiMetotsal
{
    class Program
    {
        static decimal sayi1, sayi2, cevap;
        static void Main(string[] args)
        {
            sayi1 = Cevir("Birinci Sayı");
            sayi2 = Cevir("İkinci Sayı");
            string islem_kod = Islem();
            decimal sonuc = Hesapla(islem_kod, sayi1, sayi2);
            Console.WriteLine("Sonuç = " + sonuc);
        }

        private static decimal Cevir(string txt)
        {
            try
            {
                Console.WriteLine(txt);
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Lütfen sayısal değer girin.");
                return Cevir(txt);
            }
        }

        private static string Islem()
        {
            Console.WriteLine("İşlem Kodu? + - * /");
            string i_kod = Console.ReadLine();
            if (i_kod == "+" || i_kod == "-" || i_kod == "*" || i_kod == "/")
            {
                return i_kod;
            }
            else
            {
                Console.WriteLine("Geçersiz işlem kodu!");
                return Islem();
            }
        }

        private static decimal Hesapla(string ikod, decimal s1, decimal s2)
        {
            decimal cvp = 0;
            if (ikod == "+")
            {
                cvp = Toplama(s1, s2);
            }
            else if (ikod == "-")
            {
                cvp = Cikarma(s1, s2);
            }
            else if (ikod == "*")
            {
                cvp = Carpma(s1, s2);
            }
            else if (ikod == "/")
            {
                cvp = Bolme(s1, s2);
            }
            return cvp;
        }

        private static decimal Toplama(decimal s1, decimal s2)
        {
            return s1 + s2;
        }

        private static decimal Cikarma(decimal s1, decimal s2)
        {
            return s1 - s2;
        }

        private static decimal Carpma(decimal s1, decimal s2)
        {;
            return s1 * s2;
        }

        private static decimal Bolme(decimal s1, decimal s2)
        {
            do
            {
                Console.WriteLine("İkinci sayı sıfır olamaz! Lütfen ikinci sayıyı tekrar giriniz.");
                s2 = Cevir("İkinci Sayı");
            } while (s2 == 0);

            if (s2 != 0)
            {
                return s1 / s2;
            }
            else
            {
                return 0;
            }
        }
    }
}
