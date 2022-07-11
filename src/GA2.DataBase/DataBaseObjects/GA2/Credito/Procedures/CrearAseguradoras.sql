USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearAseguradoras]    Script Date: 6/07/2021 11:16:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian gonzalez>
-- Create date: <23/04/2021>
-- Description:	<SP para la creación de Aseguradoras>
-- =============================================
CREATE PROCEDURE [dbo].[CrearAseguradoras]

	 
	@ASE_RAZON_SOCIAL varchar(100)
	,@ASE_SITIO_WEB varchar(100)
	,@ASE_ESTADO int
	,@ASE_CREADO_POR uniqueidentifier
	,@ASE_FECHA_CREACION datetime
	,@ASE_ACTUALIZADO_POR uniqueidentifier
	,@ASE_FECHA_ACTUALIZA datetime
AS 
BEGIN
INSERT INTO [GA2].[dbo].[ASE_ASEGURADORAS]
(					 
	ASE_RAZON_SOCIAL
	,ASE_SITIO_WEB 
	,ASE_ESTADO 
	,ASE_CREADO_POR
	,ASE_FECHA_CREACION
	,ASE_ACTUALIZADO_POR
	,ASE_FECHA_ACTUALIZA
) 
VALUES
(    					 
	@ASE_RAZON_SOCIAL
	,@ASE_SITIO_WEB 
	,@ASE_ESTADO 
	,@ASE_CREADO_POR
	,@ASE_FECHA_CREACION
	,@ASE_ACTUALIZADO_POR
	,@ASE_FECHA_ACTUALIZA
)
SELECT 	TOP(1)
	ASE_RAZON_SOCIAL
	,ASE_SITIO_WEB 
	,ASE_ESTADO 
	,ASE_CREADO_POR
	,ASE_FECHA_CREACION
	,ASE_ACTUALIZADO_POR
	,ASE_FECHA_ACTUALIZA
FROM
	[GA2].[dbo].[ASE_ASEGURADORAS]
ORDER BY ASE_ID DESC
END


