USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Factura_Cabecera]    Script Date: 14/6/2025 10:21:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura_Cabecera](
	[FC_ID] [int] IDENTITY(2000,1) NOT NULL,
	[Fecha 
Alta] [date] NOT NULL,
	[Cli_ID] [varchar](50) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Factura_Cabecera] PRIMARY KEY CLUSTERED 
(
	[FC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


