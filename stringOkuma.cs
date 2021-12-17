using System;

namespace Alistirma
{
    class Program
    {
        static string kelime;
        static int i, j;

        static void Main(string[] args)
        {
            Console.Write("Bir kelime giriniz: ");
            kelime = Console.ReadLine();

            MetinTespiti(kelime);
        }

        static void MetinTespiti(string str)
        {
            if (str[0] == '0' && str.Contains('.'))
            {
                for (i = 1; i < str.Length; i++)
                {
                    if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9' || str[i] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (i == str.Length)
                {
                    Console.WriteLine("Tam sayı bir kelime girilmiştir.");
                }
                else
                {
                    Console.WriteLine("Girilen kelime ondalıklı bir sayı değildir!");
                }
            }
            else if (str[0] == '-' || str[0] == '+' || str[0] == '1' || str[0] == '2' || str[0] == '3' || str[0] == '4' || str[0] == '5' || str[0] == '6' || str[0] == '7' || str[0] == '8' || str[0] == '9')
            {
                for (i = 1; i < str.Length; i++)
                {
                    if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9' || str[i] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (i == str.Length)
                {
                    Console.WriteLine("Tam sayı bir kelime girilmiştir.");
                }
                else
                {
                    Console.WriteLine("Girilen kelime ondalıklı bir sayı değildir!");
                }
            }
            else
            {
                Console.WriteLine("Girilen kelime ondalıklı bir sayı değildir!");
            }
        }
    }
}
