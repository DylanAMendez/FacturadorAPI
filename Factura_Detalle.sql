USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Factura_Detalle]    Script Date: 14/6/2025 10:35:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura_Detalle](
	[Fact_ID] [int] NOT NULL,
	[FC_DTL_ID] [int] NOT NULL,
	[Fecha Alta] [date] NOT NULL,
	[ART_ID] [varchar](50) NOT NULL,
	[Cant] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Moto] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO


