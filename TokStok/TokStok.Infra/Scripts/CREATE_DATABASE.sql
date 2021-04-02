CREATE DATABASE TOKSTOKTESTE
GO

USE [TOKSTOKTESTE]
GO

/****** Object:  Table [dbo].[Especificadores]    Script Date: 01/04/2021 20:29:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Especificadores]') AND type in (N'U'))
DROP TABLE [dbo].[Especificadores]
GO

/****** Object:  Table [dbo].[Especificadores]    Script Date: 01/04/2021 20:29:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Especificadores](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[CPF] [char](11) NOT NULL,
	[TipoDocumentoClasse] [varchar](10) NOT NULL,
	[NumeroDocumentoClasse] [varchar](15) NOT NULL,
	[EspecificadorAtivo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


