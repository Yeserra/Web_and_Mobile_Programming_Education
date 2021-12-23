--create view PSales as

--select ProductId, sum(Amount) as Sales from Sales
--where Code = 'S' group by ProductId

--create view PReturn as

--select ProductId, sum(Amount) as Ret from Sales
--where Code = 'R' group by ProductId

--create view PDiscount as

--select ProductId, sum(Amount) as Discount from Sales
--where Code = 'D' group by ProductId

select s.ProductId, Sales, Discount, Ret, Sales - Discount - Ret Net from Sales s
inner join PSales p on p.ProductId = s.ProductId
inner join PReturn r on r.ProductId = s.ProductId
inner join PDiscount d on d.ProductId = s.ProductId

with

Urun(UrunId, UrunAd) as
(select ProductId, ProductName from Product),

Satis(UrunId, SatisMiktar) as
(select ProductId, sum(Amount) from Sales where Code = 'S' group by ProductId),

Iade(UrunId, IadeMiktar) as
(select ProductId, sum(Amount) from Sales where Code = 'R' group by ProductId),

Iskonto(UrunId, IskontoMiktar) as
(select ProductId, sum(Amount) from Sales where Code = 'D' group by ProductId)

select u.UrunId, UrunAd, SatisMiktar, IadeMiktar, IskontoMiktar from Urun u
inner join Satis s on s.UrunId = u.UrunId
inner join Iade i on i.UrunId = u.UrunId
inenr join Iskonto isk on isk.UrunId = u.UrunId
