--Programmability -> Stored Procedures -> SağTık -> Stored Procedure...


--===========================================================HESAP_ACMA=================================================================================

USE [Banka]
GO
/****** Object:  StoredProcedure [dbo].[HesapAcma]    Script Date: 23.12.2021 22:14:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[HesapAcma] ---------------------------------> Önce ALTER yerine CREATE yazıp bir kere Execute ederek HesapAcma oluşturulur.
	-- Add the parameters for the stored procedure here
	@Unvan Nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Musteri(Unvan,Bakiye)
	Values(@Unvan,0)
END


--===============================================================PARA_CEKME==============================================================================


USE [Banka]
GO
/****** Object:  StoredProcedure [dbo].[ParaCekme]    Script Date: 23.12.2021 22:27:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ParaCekme] ---------------------------------------> Önce CREATE!
	-- Add the parameters for the stored procedure here
	@MusteriId int,
	@Tutar decimal(18,2)
	
AS
declare @Bakiye decimal(18,2)
set @Bakiye=(select Bakiye from Musteri where MusteriId=@MusteriId)
	SET NOCOUNT ON;

IF @Tutar>@Bakiye
BEGIN
	print 'Bakiye yetersiz'

END

ELSE
BEGIN
	Update Musteri set Bakiye = Bakiye-@Tutar
	where @MusteriId=MusteriId

	insert into Hareket(Tarih,Tutar,MusteriId)
	Values (GETDATE(),@Tutar*-1,@MusteriId)
END

--SQL'de değişken tanımlamaları DECLARE deyimiyle yapılır.


--===========================================================PARA_YATIRMA===========================================================================




USE [Banka]
GO
/****** Object:  StoredProcedure [dbo].[ParaYatirma]    Script Date: 23.12.2021 22:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ParaYatirma]
	-- Add the parameters for the stored procedure here
	@MusteriId int,
	@Tutar decimal(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from (SET COUNT ON, fazladan sonuç kümelerinin SELECT
	-- interfering with SELECT statements.                     ifadelerine müdahale etmesini önlemek için eklendi)
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Musteri set Bakiye = Bakiye+@Tutar
	where @MusteriId=MusteriId

	insert into Hareket(Tarih,Tutar,MusteriId)
	Values (GETDATE(),@Tutar,@MusteriId)

END

--İşlemler oluşturulduktan sonra ve create yerine alter yazıldıktan sonra çalıştırmak için:
--işlem üzerine -> SağTık -> Execute Stored Procedure... -> values kısmına değerler yazılır.



--============================================================================PARA_CEKMET========================================================================



USE [BankaDB]
GO
/****** Object:  StoredProcedure [dbo].[ParaCekmeT]    Script Date: 24.12.2021 20:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ParaCekmeT]
	-- Add the parameters for the stored procedure here
	@MusteriId int,
	@Tutar decimal(18,2)
AS
BEGIN
	declare @Bakiye decimal(18, 2)
	select @Bakiye = Bakiye from Musteri where MusteriId = @MusteriId
SET NOCOUNT ON;

BEGIN TRANSACTION
	BEGIN TRY

	if @Tutar <= @Bakiye
	BEGIN
	update Musteri set Bakiye = Bakiye - @Tutar where MusteriId = @MusteriId
	insert into Hareket (Tarih, Tutar, MusteriId) values ('akşdg', @Tutar * -1, @MusteriId) --Tarih değeri hatalı girildi ki suni bir aksaklık oluşturuldu.
	END

	else
	BEGIN
	print('Yetersiz Bakiye')
	END

COMMIT TRAN

	END TRY

	BEGIN CATCH

	rollback tran
	print('Bir Hata Oluştu!')
	print('İşlem geri alındı!')

	END CATCH

END



--======================================================================PARA_YATIRMAT==============================================================================



USE [BankaDB]
GO
/****** Object:  StoredProcedure [dbo].[ParaYatirmaT]    Script Date: 24.12.2021 20:09:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ParaYatirmaT]
	-- Add the parameters for the stored procedure here
	@MusteriId int,
	@Tutar decimal(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRANSACTION
	BEGIN TRY

    -- Insert statements for procedure here
	update Musteri set Bakiye = Bakiye + @Tutar where MusteriId = @MusteriId

	insert into Hareket (Tarih, Tutar, MusteriId) values('dafjiıs', @Tutar, @MusteriId)

	COMMIT TRAN

	END TRY

	BEGIN CATCH

	rollback tran
	print('Bir Hata Oluştu!')
	print('İşlem geri alındı!')

	END CATCH
END




























