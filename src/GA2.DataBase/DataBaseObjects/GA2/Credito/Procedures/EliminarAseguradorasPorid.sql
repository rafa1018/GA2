USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarAseguradorasPorid]    Script Date: 6/07/2021 11:20:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Eliminar Aseguradora por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarAseguradorasPorid]
	-- Add the parameters for the stored procedure here
	@ASE_ID int 
AS
BEGIN
UPDATE [ASE_ASEGURADORAS]
SET
	ASE_ESTADO=0       
WHERE
	ASE_ID=@ASE_ID
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
	[ASE_ASEGURADORAS]
WHERE			
	ASE_ID=@ASE_ID
END