USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEstadoActividadPorId]    Script Date: 6/07/2021 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener consecutivo por id en tabla ESA_ESTADO_ACTIVIDAD>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEstadoActividadPorId]
	-- Add the parameters for the stored procedure here
	@ESA_ID int           
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
	ESA_ID=@ESA_ID
	
END
