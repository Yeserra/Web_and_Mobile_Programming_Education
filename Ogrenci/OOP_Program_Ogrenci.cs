using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenciler
{
    class Program
    {
        static List<Ogrenci> o_list = new List<Ogrenci>();

        static Ogrenci secOgr;

        static void Main(string[] args)
        {
            Doldur();
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("1-Tüm Veriler");
            Console.WriteLine("2-Detayları Görüntüle");
            Console.WriteLine("3-Yeni Öğrenci");
            Console.WriteLine("4-Silme");
            Console.WriteLine("5-Güncelleme");
            Console.WriteLine("6-Arama");
            Console.WriteLine("7-İsme göre sırala (A-Z)");
            Console.WriteLine("8-İsme göre sırala (Z-A)");

            int secim = Convert.ToInt32(Console.ReadLine());

            if (secim == 1)
            {
                Yazdir(o_list);
            }
            else if (secim == 2)
            {
                Detay();
            }
            else if (secim == 3)
            {
                Giris();
            }
            else if (secim == 4)
            {
                Sil();
            }
            else if (secim == 5)
            {
                Guncelle();
            }
            else if (secim == 6)
            {
                Arama();
            }
            else if (secim == 7)
            {
                SiralaAZ();
            }
            else if (secim == 8)
            {
                SiralaZA();
            }
            else
            {
                Console.WriteLine("Yanlış Seçim!");
            }
            Menu();
        }

        private static void SiralaAZ()
        {
            var yolist = o_list.OrderBy(x => x.Ad).ToList();
            Yazdir(yolist);
        }

        private static void SiralaZA()
        {
            var yolist = o_list.OrderByDescending(x => x.Ad).ToList();
            Yazdir(yolist);
        }

        private static void Arama()
        {
            Console.Write("Aranan Öğrencinin adı? ");
            string ara = Console.ReadLine();
            var yolist = o_list.Where(x => x.Ad.Contains(ara) || x.Soyad.Contains(ara)).ToList();
            Yazdir(yolist);
        }

        private static void Guncelle()
        {
            Ogrenci guncelOgr = OgrenciIdSec();

            YeniVeriler(guncelOgr);

            Yazdir(o_list);
        }

        private static void Sil()
        {
            o_list.Remove(OgrenciIdSec());
            Yazdir(o_list);
        }

        private static void Giris()
        {
            Ogrenci yeniOgrenci = new Ogrenci();

            yeniOgrenci.Id = o_list.Max(x => x.Id) + 1;
            yeniOgrenci = YeniVeriler(yeniOgrenci);

            o_list.Add(yeniOgrenci);
            Yazdir(o_list);
        }

        private static void Detay()
        {
            secOgr = OgrenciIdSec();

            //1.YÖNTEM
            Console.WriteLine(secOgr.GetTitle() + " (" + secOgr.GetAge() + ")");
            
            Console.WriteLine("Adres:");
            foreach (var item in secOgr.GetAdres())
            {
                Console.WriteLine(item);
            }

            //2.YÖNTEM
            Console.WriteLine("\n" + secOgr.GetAdres2() + "\n");

            //3.YÖNTEM
            Console.WriteLine("Adres:");
            foreach (var item in secOgr.GetAdres3())
            {
                Console.WriteLine(item);
            }
            
            //Console.WriteLine("Ad: " + secilenOgrenci.Ad);
            //Console.WriteLine("Soyad: " + secilenOgrenci.Soyad);
            //Console.WriteLine("Cinsiyet: " + secilenOgrenci.Cinsiyet);
            //Console.WriteLine("Doğum Tarihi: " + secilenOgrenci.DogumTarihi);
            //Console.WriteLine("Şehir: " + secilenOgrenci.Sehir);
            //Console.WriteLine("İlçe: " + secilenOgrenci.Ilce);
            //Console.WriteLine("Cadde: " + secilenOgrenci.Cadde);
            //Console.WriteLine("Kapı No: " + secilenOgrenci.KapiNo);
            
            Console.WriteLine();
        }

        private static void Doldur()
        {
            int c, yas;
            for (int i = 1; i <= 20; i++)
            {
                Ogrenci o = new Ogrenci();
                o.Ad = FakeData.NameData.GetFirstName();
                
                o.Cadde = FakeData.PlaceData.GetStreetName();
                
                c = FakeData.NumberData.GetNumber(0, 2);
                if (c == 0)
                {
                    o.Cinsiyet = 'E';
                }
                else
                    o.Cinsiyet = 'K';

                yas = FakeData.NumberData.GetNumber(18, 28);
                o.DogumTarihi = DateTime.Now.AddYears(yas * -1);

                o.Id = i;
                
                o.Ilce = FakeData.PlaceData.GetCounty();
                
                o.KapiNo = FakeData.NumberData.GetNumber(1, 100);
                
                o.Soyad = FakeData.NameData.GetSurname();

                o.Sehir = FakeData.PlaceData.GetCity();

                o.Maas = FakeData.NumberData.GetNumber(750, 1000);

                o_list.Add(o);
            }
        }

        private static void Yazdir(List<Ogrenci> o_list)
        {
            Console.Clear();
            Console.WriteLine("  Id           Ad          Soyad          Cinsiyet                   Doğum Tarihi            Maaş");
            Console.WriteLine("___________________________________________________________________________________________________");
            foreach (Ogrenci item in o_list)
            {
                Console.WriteLine("   " + item.Id + "           "
                                        + item.Ad + "           "
                                        + item.Soyad + "           "
                                        + item.Cinsiyet + "           "
                                        + item.DogumTarihi + "           "
                                        + item.Maas);
            }
            ToplamYaz(o_list);
            //ToplamYaz2(o_list);
        }

        private static void ToplamYaz(List<Ogrenci> o_list)
        {
            //1.Yol
            int kisiSayisi = 0;
            int erkekSayisi = 0;
            int kadinSayisi = 0;
            int maasToplam = 0;
            int erkekMaasToplam = 0;
            int kadinMaasToplam = 0;
            foreach (var item in o_list)
            {
                kisiSayisi += 1;
                maasToplam += item.Maas;
                if (item.Cinsiyet == 'E')
                {
                    erkekSayisi++;
                    erkekMaasToplam += item.Maas;
                }
                else
                {
                    kadinSayisi++;
                    kadinMaasToplam += item.Maas;
                }
            }
            Console.WriteLine("\n" + "Toplam:");
            Console.WriteLine("Erkek Sayısı: " + erkekSayisi);
            Console.WriteLine("Kadın Sayısı: " + kadinSayisi);
            Console.WriteLine("Toplam Erkek Maaş: " + erkekMaasToplam);
            Console.WriteLine("Toplam Kadın Maaş: " + kadinMaasToplam);
            Console.WriteLine("Toplam Maaş: " + maasToplam + "\n");
        }

        private static void ToplamYaz2(List<Ogrenci> o_list)
        {
            //2.Yol
            int kisiSayisi = 0;
            int erkekSayisi = 0;
            int kadinSayisi = 0;
            int maasToplam = 0;
            int erkekMaasToplam = 0;
            int kadinMaasToplam = 0;

            kisiSayisi = o_list.Count;
            erkekSayisi = o_list.Where(x => x.Cinsiyet == 'E').Count();
            kadinSayisi = o_list.Where(x => x.Cinsiyet == 'K').Count();
            maasToplam = o_list.Sum(x => x.Maas);
            erkekMaasToplam = o_list.Where(x => x.Cinsiyet == 'E').Sum(x => x.Maas);
            kadinMaasToplam = o_list.Where(x => x.Cinsiyet == 'K').Sum(x => x.Maas);
            Console.WriteLine("\n" + "Toplam:");
            Console.WriteLine("Erkek Sayısı: " + erkekSayisi);
            //YA DA => Console.WriteLine("Erkek Sayısı: " + o_list.Where(x => x.Cinsiyet == 'E').Count());
            Console.WriteLine("Kadın Sayısı: " + kadinSayisi);
            //YA DA => Console.WriteLine("Kadın Sayısı: " + o_list.Where(x => x.Cinsiyet == 'K').Count());
            Console.WriteLine("\n" + "~Ortalamalar~" + "\n");
            Console.WriteLine("Ortalama Kadın Maaş: " + o_list.Where(x => x.Cinsiyet == 'K').Average(x => x.Maas) + "\n");
            Console.WriteLine("Ortalama Erkek Maaş: " + o_list.Where(x => x.Cinsiyet == 'E').Average(x => x.Maas) + "\n");
        }

        private static Ogrenci OgrenciIdSec()
        {
            Console.Write("Öğrenci Id?   ");
            int secilenId = Convert.ToInt32(Console.ReadLine());
            Ogrenci secilenOgrenci = o_list.Find(x => x.Id == secilenId);

            return secilenOgrenci;
            //return o_list.Find(x => x.Id == secilenId);
        }

        private static Ogrenci YeniVeriler(Ogrenci ogr)
        {
            string Isim, Soyisim, Seh, Ilc, Cad;
            int KNo, m;
            char Cins;
            DateTime DogumT;

            Console.Write("Ad = ");
            Isim = Console.ReadLine();
            Console.Write("Soyad = ");
            Soyisim = Console.ReadLine();
            Console.Write("Cinsiyet (E / K) = ");
            Cins = Convert.ToChar(Console.ReadLine());
            Console.Write("Doğum Tarihi (ay/gün/yıl) = ");
            DogumT = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Sehir = ");
            Seh = Console.ReadLine();
            Console.Write("Ilce = ");
            Ilc = Console.ReadLine();
            Console.Write("Cadde = ");
            Cad = Console.ReadLine();
            Console.Write("Kapı No = ");
            KNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Maas = ");
            m = Convert.ToInt32(Console.ReadLine());

            ogr.Ad = Isim;
            ogr.Soyad = Soyisim;
            ogr.Cinsiyet = Cins;
            ogr.DogumTarihi = DogumT;
            ogr.Sehir = Seh;
            ogr.Ilce = Ilc;
            ogr.Cadde = Cad;
            ogr.KapiNo = KNo;
            ogr.Maas = m;

            return ogr;
        }
    }
}
