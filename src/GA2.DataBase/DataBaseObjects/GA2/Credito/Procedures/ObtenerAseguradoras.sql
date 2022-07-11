USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAseguradoras]    Script Date: 6/07/2021 11:21:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <20/05/2021>
-- Description:	<Obtener Aseguradoras>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerAseguradoras]
	-- Add the parameters for the stored procedure here
	         
AS
SELECT	
	ASE_ID
	,ASE_RAZON_SOCIAL
	,ASE_SITIO_WEB 
	,ASE_ESTADO 
	,ASE_CREADO_POR
	,ASE_FECHA_CREACION
	,ASE_ACTUALIZADO_POR
	,ASE_FECHA_ACTUALIZA
FROM 
	[GA2].[dbo].[ASE_ASEGURADORAS]
WHERE
	ASE_ESTADO =1

