//Class Library üzerinden bir proje oluşturuldu ve kütüphanenin içeriği bu projeenin içine yazılıp Build edildi, kaydedildi.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public static class Kisi
    {

        public static string Ad()
        {
            Random random = new Random();
            List<string> isim = new List<string>();
            isim.Add("Büşra");
            isim.Add("Beyza");
            isim.Add("Yasemin");
            isim.Add("Hilal");
            isim.Add("Merve");
            int index = random.Next(isim.Count);
            return isim[index];
        }

        public static string Soyad()
        {
            Random random = new Random();
            List<string> soyisim = new List<string>();
            soyisim.Add("Ak");
            soyisim.Add("Mılık");
            soyisim.Add("Gereksar");
            soyisim.Add("Türker");
            soyisim.Add("Ercan");
            int index = random.Next(soyisim.Count);
            return soyisim[index];
        }

        public static string Sehir()
        {
            Random random = new Random();
            List<string> s = new List<string>();
            s.Add("İstanbul");
            s.Add("İzmir");
            s.Add("Antalya");
            s.Add("Malatya");
            s.Add("Mardin");
            int index = random.Next(s.Count);
            return s[index];
        }
    }
}
