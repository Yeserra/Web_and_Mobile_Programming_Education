using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1- Diziler1");
            Console.WriteLine("2- Diziler2");
            Console.WriteLine("3- Array List");
            Console.WriteLine("4- Generic1");
            Console.WriteLine("5- Generic2");
            Console.WriteLine("6- Generic3");
            Console.WriteLine("7- Generic4");
            string secim = Console.ReadLine();
            Secim(secim);
        }

        static private void Secim(string secim)
        {
            if (secim == "1")
            {
                Dizi1();
            }
            else if (secim == "2")
            {
                Dizi2();
            }
            else if (secim == "3")
            {
                A_List();
            }
            else if (secim == "4")
            {
                Generic1();
            }
            else if (secim == "5")
            {
                Generic2();
            }
            else if (secim == "6")
            {
                Generic3();
            }
            else if (secim == "7")
            {
                Generic4();
            }

            Main(null);
        }

        static private void Generic1() //Tip korumalı: int dışında başka değişken türünde bir değer girilemez!
        {
            List<int> sayilar = new List<int>();
            sayilar.Add(10);
            sayilar.Add(20);
            sayilar.Add(30);
            //sayilar.Remove(30);
            //sayilar.RemoveAt(1);
            foreach (int item in sayilar)
            {
                Console.WriteLine(item);
            }
        }

        static private void Generic2() //Sadece string değerler!
        {
            List<string> sayilar = new List<string>();
            sayilar.Add("Elma");
            sayilar.Add("Nar");
            sayilar.Add("Karpuz");
            //sayilar.Remove(30);
            //sayilar.RemoveAt(1);
            foreach (string item in sayilar)
            {
                Console.WriteLine(item);
            }
        }

        static private void Generic3() //object kullanıdığı zaman tip korumasız da olabiliyor!
        {
            List<object> esnek = new List<object>();
            esnek.Add("Elma");
            esnek.Add("Nar");
            esnek.Add("Karpuz");
            esnek.Add(100);
            foreach (object item in esnek)
            {
                Console.WriteLine(item);
            }
        }

        static private void Generic4() //Her türlü değişken türünü kabul ediyor.
        {
            List<ConsoleColor> col = new List<ConsoleColor>();
            col.Add(ConsoleColor.DarkYellow);
            col.Add(ConsoleColor.DarkRed);
            col.Add(ConsoleColor.Yellow);
            col.Add(ConsoleColor.Blue);
            foreach (ConsoleColor item in col)
            {
                Console.BackgroundColor = item;
                Console.WriteLine(item);
            }
        }

        static private void A_List()
        {
            Console.WriteLine("ArrayList1");
            ArrayList alist = new ArrayList();
            alist.Add(10);
            alist.Add(20);
            alist.Add("Mandalina");
            alist.Add("Ocak");
            alist.Remove("Ocak");
            alist.RemoveAt(1);
            foreach (var item in alist)
            {
                Console.WriteLine(item);
            }
        }

        static private void Dizi1()
        {
            Console.WriteLine("Dizi1");
            int[] sayilar = { 10, 20, 30, 40 };
            foreach (int item in sayilar)
            {
                Console.WriteLine(item);
            }
        }

        static private void Dizi2()
        {
            Console.WriteLine("Dizi2");
            string[] meyveler = { "Elma", "Armut", "Çilek", "Portakal", "Erik" };
            foreach (string item in meyveler)
            {
                Console.WriteLine(item);
            }
        }
    }
}
