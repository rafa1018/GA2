USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAseguradorasPorId]    Script Date: 6/07/2021 11:22:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener consecutivo por id>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerAseguradorasPorId]
	-- Add the parameters for the stored procedure here
	@ASE_ID int            
AS
BEGIN
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
	ASE_ID=@ASE_ID
END
