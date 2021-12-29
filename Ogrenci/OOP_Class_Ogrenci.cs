using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenciler
{
    class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public char Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Cadde { get; set; }
        public int KapiNo { get; set; }
        public int Maas { get; set; }

        public string GetTitle()
        {
            if (Cinsiyet == 'E')
            {
                return "Sn. Bay " + Ad + " " + Soyad;
            }
            else
            {
                return "Sn. Bayan " + Ad + " " + Soyad;
            }
        }

        public int GetAge()
        {
            DateTime bugun = DateTime.Now;
            int yas = bugun.Year - DogumTarihi.Year;
            DateTime dogumgunu = DogumTarihi.AddYears(yas);
            if (dogumgunu < bugun)
            {
                yas++;
            }
            return yas;
        }

        public List<string> GetAdres()
        {
            List<string> adres = new List<string>();
            adres.Add(Cadde);
            adres.Add(KapiNo.ToString());
            adres.Add(Ilce + "/" + Sehir);
            return adres;
        }

        public string GetAdres2()
        {
            return $"Adres : {Cadde}, {KapiNo}, {Ilce} / {Sehir}";
        }

        public string[] GetAdres3()
        {
            string[] adres = { Cadde, KapiNo.ToString(), Ilce + "/" + Sehir };
            return adres;
        }
    }
}
