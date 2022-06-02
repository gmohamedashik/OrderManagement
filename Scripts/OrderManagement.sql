Create database OrderManagement;

USE [OrderManagement]
GO

/****** Object:  Table [dbo].[Vendors]    Script Date: 6/1/2022 6:44:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vendors](
	[Id] [int] NOT NULL,
	[Name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [OrderManagement]
GO

INSERT INTO [dbo].[Vendors]
           ([Id]
           ,[Name])
     VALUES
           (1, 'BMW');

INSERT INTO [dbo].[Vendors]
           ([Id]
           ,[Name])
     VALUES
           (2, 'Mercedes');
GO




/****** Object:  Table [dbo].[Orders]    Script Date: 6/1/2022 6:44:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[OrderAmount] [decimal](18, 0) NOT NULL,
	[ShopNumber] [int] NOT NULL,
	[VendorId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Vendors]
GO

