USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarColorGrilla]    Script Date: 6/07/2021 11:47:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <30/04/2021>
-- Description:	<Sp para la actualziacion de datos en la tabla ColorGrilla>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarColorGrilla]
	-- Add the parameters for the stored procedure here
	@CLG_ID int 
	,@CLG_DESCRIPCION varchar(100) 
	,@CLG_ESTILO_COLOR varchar(20) 
	,@CLG_ESTADO int 
	,@CLG_CREADO_POR uniqueidentifier 
	,@CLG_FECHA_CREACION datetime 
	,@CLG_ACTUALIZADO_POR uniqueidentifier 
	,@CLG_FECHA_ACTUALIZA datetime 
AS
BEGIN
UPDATE [CLG_COLOR_GRILLA]
SET  
	CLG_DESCRIPCION=@CLG_DESCRIPCION 
	,CLG_ESTILO_COLOR=@CLG_ESTILO_COLOR
	,CLG_ESTADO =@CLG_ESTADO 
	,CLG_CREADO_POR =@CLG_CREADO_POR 
	,CLG_FECHA_CREACION=@CLG_FECHA_CREACION
	,CLG_ACTUALIZADO_POR=@CLG_ACTUALIZADO_POR
	,CLG_FECHA_ACTUALIZA=@CLG_FECHA_ACTUALIZA
WHERE CLG_ID=@CLG_ID  
SELECT
	CLG_DESCRIPCION
	,CLG_ESTILO_COLOR
	,CLG_ESTADO 
	,CLG_CREADO_POR
	,CLG_FECHA_CREACION
	,CLG_ACTUALIZADO_POR
	,CLG_FECHA_ACTUALIZA
FROM 
	[CLG_COLOR_GRILLA]
WHERE
	CLG_ID=@CLG_ID  
END
