USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerActividadFlujoPorId]    Script Date: 7/07/2021 12:35:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <07/05/2021>
-- Description:	<SP para la obtener de actividad Flujo por id>
-- =============================================
CREATE PROC [dbo].[ObtenerActividadFlujoPorId]
	@FLU_ID int
as
SELECT 
	 FLU_ID   
	,TAC_ID   
	,AFL_ORDEN   
	,AFL_TIEMPO   
	,AFL_ACTIVIDAD_AUTOMATICA   
	,AFL_ACTIVIDAD_PRINCIPAL   
	,AFL_PUEDE_DELEGAR   
	,AFL_CARGA_ARCHIVOS   
	,AFL_VISUALIZA_ARCHIVOS   
	,AFL_CAPTURA_DATOS_TEC   
	,AFL_CAPTURA_DATOS_JUR   
	,AFL_CAPTURA_DATOS_FIN   
	,AFL_VISUALIZA_DATOS_BAS   
	,AFL_VIISUALIZA_DATOS_GAR   
	,AFL_VISUALIZA_DATOS_FIN   
	,AFL_GENERA_PDF_RESUMEN   
	,AFL_CONSULTA_BURO   
	,AFL_ENVIO_NOTIFICACION  
	,AFL_ENVIO_NOTIFICACION_VENC  
	,AFL_ENVIA_NOTIFICACION_CLIENTE   
	,AFL_ESTADO   
	,AFL_CREADO_POR   
	,AFL_FECHA_CREACION   
	,AFL_MODIFICADO_POR  
	,AFL_FECHA_MODIFICACION  
FROM
	[AFL_ACTIVIDAD_FLUJO]
WHERE 
	AFL_ESTADO = 1 and
	FLU_ID=@FLU_ID
ORDER by 
	FLU_ID