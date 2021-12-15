using System;

namespace Donguler
{
    class Program
    {
        static int[] sayilar = { 10, 15, 72, 37, 48 };
        static int sayac = 0;
        static int t = 0;

        static void Main(string[] args)
        {
            baslik("For Döngüsü");
            for (int i = 0; i < sayilar.Length; i++)
            {
                Console.WriteLine(i + "." + "sayilar[" + i + "] = " + sayilar[i]);
                Console.WriteLine("sayac = " +sayac);
                sayac++;
                t += sayilar[i];
            }
            toplam(t);

            baslik("Do While Döngüsü");
            do
            {
                Console.WriteLine("Yasemin");
                sayac--;
                t += sayilar[sayac];
            } while (sayac > 0);
            toplam(t);

            baslik("While Döngüsü");
            while (sayac < sayilar.Length)
            {
                Console.WriteLine(sayilar[sayac]);
                t += sayilar[sayac];
                sayac++;
            }
            toplam(t);

            baslik("Foreach Döngüsü");
            foreach (int item in sayilar)
            {
                Console.WriteLine(item);
                t += item;
            }
            toplam(t);
        }

        private static void baslik(string b)
        {
            t = 0;
            Console.WriteLine();
            Console.WriteLine(b);
            Console.WriteLine();
        }

        private static void toplam(int s)
        {
            Console.WriteLine();
            Console.WriteLine("Toplam = " + s);
            Console.WriteLine();
        }
    }
}
