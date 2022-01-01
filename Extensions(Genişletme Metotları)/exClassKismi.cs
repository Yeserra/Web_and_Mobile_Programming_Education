//PROJENİN CLASS KISMI
//namespace'lerin aynı olmasına dikkat edilmelidir!

using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public static class MyExtensions
    {
        //2021001 1 Ocak
        //2021002 2 Ocak
        //2022365

        public static string IlkHarfBuyuk(this String txt) //string bir ifadenin ilk harfini büyülten bir metot
        {
            return txt.Substring(0, 1).ToUpper() + txt.Substring(1);
        }

        public static int ToJulian(this DateTime d) //Tarihi, Julian gösterimine çeviren bir metot
        {
            int yil = d.Year * 1000;
            int ay = d.DayOfYear;
            yil = yil + ay;

            return yil;
        }

        public static DateTime ToDate(this string x) //Julian şeklindeki string tarihi ay.gün.yıl olarak döndüren bir metot
        {
            int jDate = Convert.ToInt32(x);
            int day = jDate % 1000;
            int year = (jDate - day) / 1000;
            var date1 = new DateTime(year, 1, 1);
            var result = date1.AddDays(day - 1);
            return result;
        }
    }
}
