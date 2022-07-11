USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearColorGrilla]    Script Date: 6/07/2021 11:48:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <30/04/2021>
-- Description:	<SP para la creación de ColorGrilla>
-- =============================================
CREATE  PROCEDURE [dbo].[CrearColorGrilla]
	@CLG_DESCRIPCION varchar(100) 
	,@CLG_ESTILO_COLOR varchar(20) 
	,@CLG_ESTADO int 
	,@CLG_CREADO_POR uniqueidentifier 
	,@CLG_FECHA_CREACION datetime 
	,@CLG_ACTUALIZADO_POR uniqueidentifier 
	,@CLG_FECHA_ACTUALIZA datetime 
AS 
BEGIN
INSERT INTO [GA2].[dbo].[CLG_COLOR_GRILLA]
	(
	CLG_DESCRIPCION
	,CLG_ESTILO_COLOR
	,CLG_ESTADO 
	,CLG_CREADO_POR
	,CLG_FECHA_CREACION
	,CLG_ACTUALIZADO_POR
	,CLG_FECHA_ACTUALIZA
	) 
VALUES 
	(    			 
	@CLG_DESCRIPCION
   ,@CLG_ESTILO_COLOR
   ,@CLG_ESTADO 
   ,@CLG_CREADO_POR
   ,@CLG_FECHA_CREACION
   ,@CLG_ACTUALIZADO_POR
   ,@CLG_FECHA_ACTUALIZA
	)
select TOP(1)
	 CLG_DESCRIPCION
    ,CLG_ESTILO_COLOR
	,CLG_ESTADO 
	,CLG_CREADO_POR
	,CLG_FECHA_CREACION
	,CLG_ACTUALIZADO_POR
	,CLG_FECHA_ACTUALIZA			
from 
	[GA2].[dbo].[CLG_COLOR_GRILLA]
	ORDER BY CLG_ID DESC
END


