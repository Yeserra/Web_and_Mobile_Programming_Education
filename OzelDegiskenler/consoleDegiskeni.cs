using System;

namespace Ozel
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor onrenk = ConsoleColor.White; //Özel Değişken -> tipi ConsoleColor olan bir değişken
            ConsoleColor arkarenk = ConsoleColor.Red;
            Console.ForegroundColor = onrenk; //Console'un onrengini değiştirmeye yarar.
            Console.BackgroundColor = arkarenk;
            int x = 100;
            decimal y = 100.25m;
            bool EH = true;
            x = x * 2;
            string ad = "yasemin";
            Console.WriteLine("int : " + x);
            Console.WriteLine("decimal : " + y);
            Console.WriteLine("bool : " + EH);
            Console.WriteLine("string : " + ad);
        }
    }
}
