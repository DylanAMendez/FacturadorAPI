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

--SP2: Crear un SP igual al anterior pero que muestre todos los datos de la 
--cabecera de las facturas y el detalle de las mismas.

ALTER PROCEDURE FacturasCabeceraYDetalle

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

		SELECT*,

	(
	SELECT Fact_ID FROM Factura_Detalle
	WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)
	) as Fact_ID,

	(
	SELECT FC_DTL_ID FROM Factura_Detalle
	WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)
	) as FC_DTL_ID,

	(
	SELECT [Fecha Alta] FROM Factura_Detalle
	WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)
	) as FechaAlta,

	(
	SELECT ART_ID FROM Factura_Detalle
	WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)
	) as ART_ID,

	(
	SELECT Cant FROM Factura_Detalle
	WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)
	) as Cant,

	(
	SELECT Moto FROM Factura_Detalle
	WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)
	) as Moto

	FROM Factura_Cabecera
	WHERE Cli_ID = @IDCliente
	AND
	[Fecha Alta] >= @FechaDesde AND [Fecha Alta] <= [Fecha Alta]
	

END
GO

--EXEC FacturasCabeceraYDetalle '2023-06-16', '2023-07-20', 1015

	--SELECT * FROM Factura_Cabecera
	--WHERE Factura_Cabecera.Cli_ID = @IDCliente

	--AND

	--[Fecha Alta] >= @FechaDesde and [Fecha Alta] <= @FechaHasta

	--SELECT * FROM Factura_Detalle
	--WHERE Factura_Detalle.Fact_ID = (SELECT top 1 Factura_Cabecera.FC_ID FROM Factura_Cabecera WHERE Cli_ID = @IDCliente)