USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 14/6/2025 10:12:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Cli_ID] [int] IDENTITY(1000,1) NOT NULL,
	[Razon Social] [varchar](255) NOT NULL,
	[CUIT] [varchar](50) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Deshabilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cli_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


