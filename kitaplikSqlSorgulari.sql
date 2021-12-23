select * from Kitaplar

--1.Yol: where ile

select * from Kitaplar, Yayinevleri where Kitaplar.YayineviId = Yayinevleri.YayineviId

select KitapId, KitapAd, Yazar, k.YayineviId, YayineviAd, k.OrjinalDil, DilAd from Kitaplar k, Yayinevleri y, Diller d
where k.YayineviId = y.YayineviId --Kartezyan çarpımı kadar getirir.

--Bu yüzden where kısmına bir ekleme daha yapıyoruz:
select KitapId,
	   KitapAd + ' - ' + Yazar [Kitap Adı / Yazar],
	   k.YayineviId,
	   YayineviAd,
	   k.OrjinalDil,
	   orj.DilAd,
	   CevrildigiDil,
	   trans.DilAd
from Kitaplar k, Yayinevleri y, Diller orj, Diller trans
where k.YayineviId = y.YayineviId and
	  k.OrjinalDil = orj.DilId and --orj = orjinal
	  k.CevrildigiDil = trans.DilId --trans = translate

--2.Yol: inner join ile

select k.KitapId,
	   k.KitapAd + ' - ' + k.Yazar [Kitap Adı / Yazar],
	   k.SayfaSayisi,
	   YayineviAd,
	   orj.DilAd OrjinalDil,
	   trans.DilAd ÇevrildiğiDil,
	   d.KitapAd + ' - ' + d.Yazar [Kitap Adı / Yazar]
from Kitaplar k
inner join Yayinevleri y on k.YayineviId = y.YayineviId
inner join Diller orj on k.OrjinalDil = orj.DilId
inner join Diller trans on k.CevrildigiDil = trans.DilId
inner join Kitaplar d on k.KitapId = d.DevamSerisi

--inner join ve where işlev açısından aynıdır fakat where ile outer join yapamazsın!

select KitapId, KitapAd, Yazar, YayineviAd from Kitaplar k
left outer join Yayinevleri y on y.YayineviId = k.YayineviId

select k.KitapId, k.KitapAd, k.Yazar, k.DevamSerisi from Kitaplar k
full outer join Kitaplar d on k.KitapId = d.DevamSerisi --Bazı kitapların devam serisi bulunmamaktadır.

select KitapId, isnull (KitapAd, 'YOK') KitapAd, Yazar, YayineviAd from Kitaplar k --isnull tek tek yazılmalı
full outer join Yayinevleri y on y.YayineviId = k.YayineviId

select k.KitapId,
	   k.KitapAd + ' - ' + k.Yazar [Kitap Adı / Yazar],
	   k.SayfaSayisi,
	   YayineviAd,
	   orj.DilAd OrjinalDil,
	   trans.DilAd ÇevrildiğiDil,
	   isnull (d.KitapAd + ' - ' + d.Yazar, 'YOK') DevamSerisi
from Kitaplar k
inner join Yayinevleri y on k.YayineviId = y.YayineviId
inner join Diller orj on k.OrjinalDil = orj.DilId
inner join Diller trans on k.CevrildigiDil = trans.DilId
left join Kitaplar d on k.DevamSerisi = d.KitapId
