using System;

namespace ParaHesaplamaMetotsal /*********Metotsal yazım ile biraz daha sadeleştirilmiş ve düzenlenmiş oldu.********/
{
    class Program
    {
        static decimal tl;
        static void Main(string[] args)
        {
            tl = ConvertDecimal("Kaç tl var?");
            Console.WriteLine("tl = " + tl);
        }

        static public decimal ConvertDecimal(string txt)
        {
            try
            {
                Console.WriteLine(txt);
                decimal decimal_value = Convert.ToDecimal(Console.ReadLine());
                return decimal_value;
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş! Lütfen tekrar deneyin.");
                return ConvertDecimal("Kaç tl var?");
            }
        }
    }
}
