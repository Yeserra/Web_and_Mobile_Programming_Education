using System;

namespace StringMetotlar
{
    class Program
    {
        static void Main(string[] args)
        {
            string ad = "Yasemin";
            Console.WriteLine(ad.ToLower());
            Console.WriteLine(ad.ToUpper());
            string str = "Gurultu";
            Console.WriteLine(str.Contains("ul"));
            Console.WriteLine(str.GetType());
            Console.WriteLine(str.IndexOf("u"));
            Console.WriteLine(str.Replace('u', 'ü'));
            
            object a = "50";
            string isim = "*******Yasemin*******";
            Console.WriteLine(isim.Trim('*')); //Hangi karakteri yazarsan onu yok eder.
            Console.WriteLine(isim.TrimEnd('*'));
            Console.WriteLine(isim.TrimStart('*'));
        }
    }
}
