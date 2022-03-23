USE [demo_product]
GO
/****** Object:  User [bhavesh]    Script Date: 29-06-2021 17:53:01 ******/
CREATE USER [bhavesh] FOR LOGIN [bhavesh] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [hetal]    Script Date: 29-06-2021 17:53:01 ******/
CREATE USER [hetal] FOR LOGIN [hetal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [jigar]    Script Date: 29-06-2021 17:53:01 ******/
CREATE USER [jigar] FOR LOGIN [jigar] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [khyati]    Script Date: 29-06-2021 17:53:01 ******/
CREATE USER [khyati] FOR LOGIN [khyati] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [parimal]    Script Date: 29-06-2021 17:53:01 ******/
CREATE USER [parimal] FOR LOGIN [parimal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [vivek]    Script Date: 29-06-2021 17:53:01 ******/
CREATE USER [vivek] FOR LOGIN [vivek] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [hetal]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [hetal]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [hetal]
GO
ALTER ROLE [db_datareader] ADD MEMBER [hetal]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [hetal]
GO
ALTER ROLE [db_owner] ADD MEMBER [jigar]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [jigar]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [jigar]
GO
ALTER ROLE [db_datareader] ADD MEMBER [jigar]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [jigar]
GO
ALTER ROLE [db_owner] ADD MEMBER [parimal]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [parimal]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [parimal]
GO
ALTER ROLE [db_datareader] ADD MEMBER [parimal]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [parimal]
GO
ALTER ROLE [db_owner] ADD MEMBER [vivek]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [vivek]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [vivek]
GO
ALTER ROLE [db_datareader] ADD MEMBER [vivek]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [vivek]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 29-06-2021 17:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
 CONSTRAINT [pk_CategoryId] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryProductRelations]    Script Date: 29-06-2021 17:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProductRelations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category1_ID] [int] NOT NULL,
	[Category2_ID] [int] NOT NULL,
 CONSTRAINT [PK__Category__3214EC27CCACAB32] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 29-06-2021 17:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [pk_ProductId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Name]) VALUES (1, N'Furniture')
INSERT [dbo].[Category] ([CategoryId], [Name]) VALUES (2, N'Games')
INSERT [dbo].[Category] ([CategoryId], [Name]) VALUES (3, N'HouseHold')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryProductRelations] ON 

INSERT [dbo].[CategoryProductRelations] ([ID], [Category1_ID], [Category2_ID]) VALUES (1, 1, 3)
INSERT [dbo].[CategoryProductRelations] ([ID], [Category1_ID], [Category2_ID]) VALUES (2, 3, 2)
SET IDENTITY_INSERT [dbo].[CategoryProductRelations] OFF
GO
ALTER TABLE [dbo].[CategoryProductRelations]  WITH CHECK ADD  CONSTRAINT [FK_CategoryID1] FOREIGN KEY([Category1_ID])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[CategoryProductRelations] CHECK CONSTRAINT [FK_CategoryID1]
GO
ALTER TABLE [dbo].[CategoryProductRelations]  WITH CHECK ADD  CONSTRAINT [FK_CategoryID2] FOREIGN KEY([Category2_ID])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[CategoryProductRelations] CHECK CONSTRAINT [FK_CategoryID2]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
/****** Object:  StoredProcedure [dbo].[SP_Category_DeleteByID]    Script Date: 29-06-2021 17:53:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Category_DeleteByID]

	-- Add the parameters for the stored procedure here
	 @CatID1 int ,
	 @Res int Out
	 

 AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from product where CategoryId=@CatID1;
	return @Res;
END
GO
