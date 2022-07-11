USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearTipoActividad]    Script Date: 7/07/2021 12:04:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <04/05/2021>
-- Description:	<SP para la creación de TAC_TIPO_ACTIVIDAD>
-- =============================================
CREATE PROCEDURE [dbo].[CrearTipoActividad]

	@TAC_DESCRIPCION varchar(70)  
	,@TAC_ESTADO int  
	,@TAC_CREADO_POR uniqueidentifier  
	,@TAC_FECHA_CREACION datetime  
	,@TAC_MODIFICADO_POR uniqueidentifier 
	,@TAC_FECHA_MODIFICACION datetime 
AS 
BEGIN
INSERT INTO [GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
(					 
	TAC_DESCRIPCION  
	,TAC_ESTADO 
	,TAC_CREADO_POR
	,TAC_FECHA_CREACION
	,TAC_MODIFICADO_POR
	,TAC_FECHA_MODIFICACION
) 
VALUES
(    					 
	@TAC_DESCRIPCION 
	,@TAC_ESTADO
	,@TAC_CREADO_POR
	,@TAC_FECHA_CREACION
	,@TAC_MODIFICADO_POR
	,@TAC_FECHA_MODIFICACION
)
SELECT 	TOP(1)
	TAC_DESCRIPCION
	,TAC_ESTADO
	,TAC_CREADO_POR
	,TAC_FECHA_CREACION
	,TAC_MODIFICADO_POR
	,TAC_FECHA_MODIFICACION
FROM
	[GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
ORDER BY TAC_ID DESC
END


