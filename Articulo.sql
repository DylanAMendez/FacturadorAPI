USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Articulo]    Script Date: 16/6/2025 19:07:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulo](
	[Articulo_ID] [int] IDENTITY(1,1) NOT NULL,
	[ART_ID] [varchar](50) NOT NULL,
	[Cant] [decimal](18, 0) NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Moto] [decimal](18, 0) NOT NULL,
	[Cli_ID] [int] NULL,
	[Nombre] [text] NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[Articulo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


