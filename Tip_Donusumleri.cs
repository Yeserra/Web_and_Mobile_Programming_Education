using System;

namespace Donusumler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Convert
            int x = 100;
            string y = "200";
            int toplam = x + Convert.ToInt32(y);
            Console.WriteLine("Toplam : " + toplam);

            string a = "100";
            string b = "200";
            var top1 = b + a;
            Console.WriteLine("Toplam : " + top1);

            //Cast (parantezle çevirme)
            object a1 = 100;
            int b1 = 200;
            int top2 = (int)a1 + b1;
            Console.WriteLine("Toplam : " + top2);

            //Metotsal -> ToString()
            long Tc = 44566394142;
            string isim = "Yasemin";
            string soyisim = "Gereksar";

            string info = Tc.ToString() + " " + isim + " " + soyisim;
            Console.WriteLine("Info = " + info);
        }
    }
}
