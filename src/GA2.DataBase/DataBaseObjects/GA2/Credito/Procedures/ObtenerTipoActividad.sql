USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTipoActividad]    Script Date: 7/07/2021 12:06:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Obtener actividades>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerTipoActividad]

AS
BEGIN
SELECT	
	TAC_ID
	,TAC_DESCRIPCION
	,TAC_ESTADO
	,TAC_CREADO_POR
	,TAC_FECHA_CREACION
	,TAC_MODIFICADO_POR
	,TAC_FECHA_MODIFICACION
FROM 
	[GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
WHERE
	TAC_ESTADO=1
ORDER BY
	TAC_ID DESC
END
