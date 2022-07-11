USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerColorGrilla]    Script Date: 6/07/2021 11:50:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Obtener Color Grilla>
-- =============================================
CREATE  PROCEDURE [dbo].[ObtenerColorGrilla]
AS
SELECT
	CLG_ID
	,CLG_DESCRIPCION
	,CLG_ESTILO_COLOR
	,CLG_ESTADO 
	,CLG_CREADO_POR
	,CLG_FECHA_CREACION
	,CLG_ACTUALIZADO_POR
	,CLG_FECHA_ACTUALIZA
FROM 
	[GA2].[dbo].[CLG_COLOR_GRILLA]
WHERE	
	CLG_ESTADO =1
ORDER BY
	CLG_ID DESC

