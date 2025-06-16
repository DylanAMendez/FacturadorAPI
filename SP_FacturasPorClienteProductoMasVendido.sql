-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

--1. SP1: Crear un Sp llamado listado de 
--FacturasPorClienteProductoMasVendido que reciba por parametro Fecha 
--desde y Fecha Hasta y el ID de cliente y liste las facturas creadas en ese 

-- la salida debe mostrar todos los datos de la factura cabecera con el ID y Nombre del producto mas vendido para 
--cada cliente.


ALTER PROCEDURE FacturasPorClienteProductoMasVendido

	-- Add the parameters for the stored procedure here
	@FechaDesde Date,
	@FechaHasta Date,
	@IDCliente int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT *,

		(
		SELECT TOP 1 Nombre 
			FROM Articulo 
			WHERE Cli_ID = @IDCliente 
			ORDER BY Cant DESC
		) as ProductoNombre,

		(
		SELECT TOP 1 ART_ID 
			FROM Articulo 
			WHERE Cli_ID = @IDCliente 
			ORDER BY Cant DESC
		) as ProductoID

	FROM Factura_Cabecera
	WHERE Cli_ID = @IDCliente

	AND 

	[Fecha Alta] >= @FechaDesde AND [Fecha Alta] <= @FechaHasta


END
GO

--EXEC FacturasPorClienteProductoMasVendido '2023-06-16', '2023-07-20', 1015