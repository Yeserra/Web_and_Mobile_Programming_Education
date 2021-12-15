using System;

namespace ParaHesaplamaMetotsalPlus /********Tüm işlemleri fonksiyonlar yardımıyla yazınca daha düzenli ve okunabilirlik daha anlaşılır hale geldi.******/
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal tl = DecimalaCevir("Kaç tl var?");
            decimal dolar = DecimalaCevir("Kaç dolar var?");
            decimal dolar_kar = Hesapla(dolar);
            decimal euro = DecimalaCevir("Kaç euro var");
            decimal euro_kar = Hesapla(euro);

            decimal toplam = euro_kar + dolar_kar + tl;
            Yazdir(toplam);
        }

        private static void Yazdir(decimal toplam)
        {
            Console.WriteLine("Toplam Param: " + toplam);
        }

         private static decimal Hesapla(decimal deger)
        {
            try
            {
                Console.WriteLine("Kuru Giriniz");
                decimal kur = Convert.ToDecimal(Console.ReadLine());
                return kur * deger;
            }
            catch (Exception)
            {
                return Hesapla(deger);
            }
        }

        static decimal DecimalaCevir(string txt)
        {
            try
            {
                Console.WriteLine(txt);
                return Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Sayısal değer giriniz.");
                return DecimalaCevir(txt);
            }
        }
    }
}
