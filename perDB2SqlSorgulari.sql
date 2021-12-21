select * from Personel

--1.Yol: where ile

select * from Personel, Unvan where Personel.UnvanId = Unvan.UnvanId

select PersonelId, Ad, Soyad, p.UnvanId, UnvanAd, p.UlkeId, UlkeAd from Personel p, Unvan u, Ulke ul where p.UnvanId = u.UnvanId --Kartezyan çarpımı kadar getirir.

--Bu yüzden where kısmına bir ekleme daha yapıyoruz:
select PersonelId, Ad, Soyad, p.UnvanId, UnvanAd, p.UlkeId, ik.UlkeAd İkamet, UyrukId, uy.UlkeAd Uyruk from Personel p, Unvan u, Ulke ik, Ulke uy
where p.UnvanId = u.UnvanId and
      p.UlkeId = ik.UlkeId and --ik = ikamet
	  p.UyrukId = uy.UlkeId --uy = uyruk

--2.Yol: inner join ile

select pc.PersonelId, pc.Ad + ' ' + pc.Soyad Çalışan, pc.Maas, UnvanAd, ul.UlkeAd İkamet, uy.UlkeAd Uyruk, py.Ad + ' ' + py.Soyad  Yönetici from Personel pc
inner join Unvan un on pc.UnvanId = un.UnvanId
inner join Ulke ul on pc.UlkeId = ul.UlkeId
inner join Ulke uy on pc.UyrukId = uy.UlkeId
inner join Personel py on pc.PersonelId = py.YoneticiId

--inner join ve where işlev açısından aynıdır fakat where ile outer join yapamazsın!

select PersonelId, Ad, Soyad, UnvanAd from Personel p
left outer join Unvan u on u.UnvanId = p.UnvanId

select PersonelId, Ad, Soyad, UnvanAd from Personel p
full outer join Unvan u on u.UnvanId = p.UnvanId --Bazı personellerin unvanı yok, bazı unvanlara sahip personel de bulunmamaktadır.

select PersonelId, isnull (Ad, 'Belirsiz') Ad, Soyad, UnvanAd from Personel p --isnull tek tek yazılmalı
full outer join Unvan u on u.UnvanId = p.UnvanId

select pc.PersonelId, pc.Ad + ' ' + pc.Soyad Çalışan, pc.Maas, UnvanAd, ul.UlkeAd İkamet, uy.UlkeAd Uyruk, isnull (py.Ad + ' ' + py.Soyad, 'YOK') Yöneticisi from Personel pc
inner join Unvan un on pc.UnvanId = un.UnvanId
inner join Ulke ul on pc.UlkeId = ul.UlkeId
inner join Ulke uy on pc.UyrukId = uy.UlkeId
left join Personel py on pc.YoneticiId = py.PersonelId
