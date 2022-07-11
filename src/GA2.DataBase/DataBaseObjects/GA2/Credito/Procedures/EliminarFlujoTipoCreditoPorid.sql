USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarFlujoTipoCreditoPorid]    Script Date: 7/07/2021 12:24:13 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Eliminar Credito por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarFlujoTipoCreditoPorid]
	@FTC_ID int 
AS
BEGIN
SET NOCOUNT ON;
UPDATE 
	[FTC_FLUJO_TIPO_CREDITO]
SET
	FTC_ESTADO=0         
WHERE
	FTC_ID=@FTC_ID
SELECT
	FTC_ID
	,FLU_ID
	,TCR_ID
	,FTC_ESTADO
	,FTC_CREADO_POR
	,FTC_FECHA_CREACION
	,FTC_MODIFICADO_POR
	,FTC_FECHA_MODIFICACION 
FROM
	[FTC_FLUJO_TIPO_CREDITO]
WHERE			
	FTC_ID=@FTC_ID
END