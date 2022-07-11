USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEstadoSolicitud]    Script Date: 7/07/2021 12:01:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener EstadoSolicitud>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEstadoSolicitud]
	-- Add the parameters for the stored procedure here
AS
SELECT	
	ESS_ID
	,ESS_DESCRIPCION
	,ESS_SIGLA  
	,ESS_ESTADO
	,ESS_CREADO_POR
	,ESS_FECHA_CREACION
	,ESS_MODIFICADO_POR
	,ESS_FECHA_MODIFICACION
FROM 
	[GA2].[dbo].[ESS_ESTADO_SOLICITUD]
WHERE			
	ESS_ESTADO=1
ORDER BY
	ESS_ID DESC

