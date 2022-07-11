USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEstadoActividad]    Script Date: 6/07/2021 11:55:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Obtiene estados de actividades que existen>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEstadoActividad]	
AS
BEGIN
	SELECT	
	 ESA_ID
	,ESA_DESCRIPCION
	,ESA_ESTADO
	,ESA_CREADO_POR
	,ESA_FECHA_CREACION
	,ESA_MODIFICADO_POR
	,ESA_FECHA_MODIFICACION
FROM 
	[GA2].[dbo].[ESA_ESTADO_ACTIVIDAD]
WHERE			
	ESA_ESTADO=1
ORDER BY 
	ESA_ID DESC
END
