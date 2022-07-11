USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerFlujoTipoCreditoPorId]    Script Date: 7/07/2021 12:25:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <10/05/2021>
-- Description:	<SP para la obtener de ObtenerFlujoTipoCredito por id>
-- =============================================
CREATE PROC [dbo].[ObtenerFlujoTipoCreditoPorId]
@FTC_ID int 
as
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
	FTC_ESTADO = 1 and FTC_ID=@FTC_ID
ORDER by 
	FTC_ID DESC
