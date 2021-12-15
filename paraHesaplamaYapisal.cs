using System;

namespace ParaHesaplamaYapısal
{
    class Program
    {
        static void Main() /********Yapısal yöntem ile yazmak kod kalabalığına ve düzensizliğe sebep olur!*******/
        {
            try
            {
                Console.WriteLine("Kaç TL var?");
                int tl = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kaç Dolar var?");
                int dolar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kaç euro var?");
                int euro = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Dolar kuru?");
                int kur_d = Convert.ToInt32(Console.ReadLine());

                int dolar_tl_kar = dolar * kur_d;

                Console.WriteLine("Euro kuru?");
                int euro_kur = Convert.ToInt32(Console.ReadLine());

                int euro_tl_kar = euro * euro_kur;

                int toplam_para = tl + dolar_tl_kar + euro_tl_kar;
                Console.WriteLine("Toplam Para = " + toplam_para);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Main();
            }
        }
    }
}
