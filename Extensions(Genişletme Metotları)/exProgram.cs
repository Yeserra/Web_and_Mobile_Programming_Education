using System;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string ad = "yasemin";

            DateTime bugun = DateTime.Now;

            string s = "2021365"; //Tarihin Julian gösterimi

            Console.WriteLine(ad.IlkHarfBuyuk());
            Console.WriteLine(bugun.ToJulian());
            Console.WriteLine(s.ToDate());
        }
    }
}
