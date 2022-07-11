USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerColorGrillaPorId]    Script Date: 6/07/2021 11:51:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener consecutivo por id>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerColorGrillaPorId]
	-- Add the parameters for the stored procedure here
			@CLG_ID int            
AS
BEGIN
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
			CLG_ID=@CLG_ID
	
END
