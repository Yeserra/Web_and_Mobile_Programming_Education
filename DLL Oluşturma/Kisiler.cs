using System;
using Kutuphane; //OLUŞTURULAN KÜTÜPHANE USING İLE PROJELERE EKLENEBİLİR.

namespace Kisiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kisi.Ad());
            Console.WriteLine(Kisi.Soyad());
            Console.WriteLine(Kisi.Sehir());
        }
    }
}
