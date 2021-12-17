using System;

namespace Tekrar
{
    class Program
    {
        static void Main(string[] args)
        {/*
            #region TEK BOYUTLU ARRAY
            int[] arr;
            arr = new int[10];
            arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }; //1.Yöntem

            for (int i = 0; i < arr.Length; i++) //2.Yöntem
            {
                arr[i] = (i * i) + 1;
            }

            //arr = null;

            Random rnd = new Random(); //3.Yöntem
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }

            int[] arr2;
            arr2 = arr;
            arr[0] = 100;
            int[] arr3 = new int[10];

            Array.Copy(arr, arr2, arr.Length); //method overload
            arr[0] = 1000;

            TekBoyutluArrayGoster(arr);
            Console.WriteLine("-------------------------");
            TekBoyutluArrayGoster(arr3);

            #endregion
            */

            /*
            #region ÇİFT BOYUTLU ARRAY

            int[,] ikiBoyutluArr;
            int[,] ikiBoyutluArr2 = new int[3, 3];
            int[,] ikiBoyutluArr3 = new int[,] { { 0, 1, 2 }, 
                                                 { 1, 2, 3 }, 
                                                 { 2, 3, 4 }, 
                                                 { 3, 4, 5 } };

            IkiBoyutluArrayYazdir(IkıBoyutluArrayDoldur(ikiBoyutluArr3));

            #endregion
            */

            #region JAGGED ARRAYS

            int[][] jaggedArr; //1.yötem tanımlama biçimi: değeri null'dır.
            int[][] jaggedArr2 = new int[5][]; //2.yöntem
            jaggedArr2[0] = new int[] { 1, 2, 3 };
            jaggedArr2[1] = new int[] { 1, 2, 3, 4, 5, 6 };
            jaggedArr2[2] = new int[] { 1, 2, 3, 4 };
            jaggedArr2[3] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            jaggedArr2[4] = new int[] { 1 };

            JaggedArrayYazdir(jaggedArr2);

            #endregion
        }

        static void TekBoyutluArrayGoster(int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Null array. İşlem yapılamıyor.");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        static int[,] IkıBoyutluArrayDoldur(int[,] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Null array! İşlem yapılamıyor.");
                return null;
            }
            else
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = (i + 1) * (j + 1);
                    }
                }
                return arr;
            }
        }

        static void IkiBoyutluArrayYazdir(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        static void JaggedArrayYazdir(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++) // arr.Length yerine arr.GetLength(0) da çalışır.
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}
