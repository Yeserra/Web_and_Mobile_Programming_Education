using System;
using System.Linq; //Kütüphane eklenerek Max, Min, Sum vs. tanımlandı.

namespace Diziler
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Sayilar = { 10, 20, 25, 7, 66 };
            Console.WriteLine(Sayilar.Length);
            Console.WriteLine(Sayilar.Count());
            Console.WriteLine(Sayilar[2]);
            Console.WriteLine(Sayilar.Max());
            Console.WriteLine(Sayilar.Min());
            Console.WriteLine(Sayilar.Sum());
            Console.WriteLine(Sayilar.Average()); //Ortalama

            string[] aylar = { "Ocak", "Şubat", "Mart" };
            Console.WriteLine(aylar[0]);
        }
    }
}
