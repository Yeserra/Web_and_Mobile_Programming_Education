using System;

namespace objectTip
{
    class Program
    {
        static void Main(string[] args)
        {
            object onrenk = ConsoleColor.White; //Eşitliğin sağındaki değere göre değişken türünü belirleyebiliyor.
            ConsoleColor arkarenk = ConsoleColor.Red;
            Console.ForegroundColor = (ConsoleColor)onrenk;
            Console.BackgroundColor = arkarenk;

            object x = 100;
            object y = 100.25m;
            object EH = true;
            x = (int)x * 2;
            string ad = "yasemin";
            Console.WriteLine("int : " + x);
            Console.WriteLine("decimal : " + y);
            Console.WriteLine("bool : " + EH);
            Console.WriteLine("string : " + ad);
        }
    }
}
