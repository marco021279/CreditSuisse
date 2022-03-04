
USE [MWERP]
GO

/****** Object:  Table [dbo].[CustomerPhysicalPerson]    Script Date: 21/02/2022 08:54:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerPhysicalPerson](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Rg] [nvarchar](20) NULL,
	[RgIssuingBody] [nvarchar](10) NULL,
	[RgShippingDate] [datetime2] NULL,
	[RgState] [char](2) NULL,
	[Gender] [char](1) NULL,
	[BirthDate] [datetime2] NULL,
	[Phone] [nvarchar](20) NULL,
	[CellPhone] [nvarchar](20) NULL,
	[Email] [nvarchar](250) NULL,
	[Site] [nvarchar](250) NULL,
	[CreditLimit] [decimal] (13, 2)	NULL,
	[RegistrationUser] [nvarchar](100) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerPhysicalPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CustomerPhysicalPerson]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPhysicalPerson_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CustomerPhysicalPerson] CHECK CONSTRAINT [FK_CustomerPhysicalPerson_Customer_CustomerId]
GO




