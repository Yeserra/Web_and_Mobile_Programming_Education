USE [BankaDB]
GO
/****** Object:  Trigger [dbo].[Ekle]    Script Date: 24.12.2021 21:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[Ekle]
   ON  [dbo].[Musteri]
   AFTER INSERT
AS 
BEGIN

declare @Y_KKN int
declare @MusteriId int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	select @MusteriId = MusteriId, @Y_KKN = KKN from inserted

	insert into LogTable(MusteriId, Y_KKN, Tarih, Yonetici, Islem)
	values (@MusteriId, @Y_KKN, getdate(), CURRENT_USER, 'Yeni Müşteri Kaydı')

END




--==============================================================================================================================================================




USE [BankaDB]
GO
/****** Object:  Trigger [dbo].[Sil]    Script Date: 24.12.2021 21:59:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[Sil]
   ON  [dbo].[Musteri]
   AFTER DELETE
AS 
declare @MusteriId int
declare @E_KKN int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select @MusteriId = MusteriId, @E_KKN = KKN from deleted

	insert into LogTable(MusteriId, E_KKN, Tarih, Yonetici, Islem)
	values(@MusteriId, @E_KKN, getdate(), CURRENT_USER, 'Müşteri kaydı silindi')

END



--===========================================================================================================================================================




USE [BankaDB]
GO
/****** Object:  Trigger [dbo].[Guncel]    Script Date: 24.12.2021 21:59:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[Guncel]
   ON  [dbo].[Musteri]
   AFTER UPDATE
AS 
BEGIN
declare @MusteriId int
declare @E_KKN int
declare @Y_KKN int

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select @MusteriId = MusteriId, @E_KKN = KKN from deleted
	select @Y_KKN = KKN from inserted

	insert into LogTable(MusteriId, E_KKN, Y_KKN, Tarih, Yonetici, Islem)
	values(@MusteriId, @E_KKN, @Y_KKN, getdate(), CURRENT_USER, 'Müşteri Kaydı Güncellendi')

END



