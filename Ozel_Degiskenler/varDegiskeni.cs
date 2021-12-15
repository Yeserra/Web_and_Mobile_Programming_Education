using System;

namespace Var
{
    class Program
    {
        static void Main(string[] args)
        {
            var onrenk = ConsoleColor.White; //Eşitliğin sağındaki değere göre değişken türünü belirleyebiliyor.
            ConsoleColor arkarenk = ConsoleColor.Red;
            Console.ForegroundColor = onrenk;
            Console.BackgroundColor = arkarenk;
            var x = 100;
            var y = 100.25m;
            var EH = true;
            x = x * 2;
            string ad = "yasemin";
            Console.WriteLine("int : " + x);
            Console.WriteLine("decimal : " + y);
            Console.WriteLine("bool : " + EH);
            Console.WriteLine("string : " + ad);
        }
    }
}
