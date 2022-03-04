USE [MWERP]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 06/10/2021 08:24:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Customer]
GO

CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[SurName] [nvarchar](250) NULL,
	[PersonType] [char](2) NOT NULL,
	[CnpjCpf] [nvarchar](15) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[RegistrationUser] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_CandidateEvaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO