USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarEstadoSolicitudPorid]    Script Date: 7/07/2021 12:00:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Eliminar ESTADO SOLICITUD por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarEstadoSolicitudPorid]
	-- Add the parameters for the stored procedure here
	@ESS_ID int
AS
BEGIN

UPDATE [GA2].[dbo].[ESS_ESTADO_SOLICITUD]
	SET
    ESS_ESTADO=0         
WHERE 
	ESS_ID=@ESS_ID
SELECT
	ESS_ID
	,ESS_DESCRIPCION
	,ESS_SIGLA  
	,ESS_ESTADO
	,ESS_CREADO_POR
	,ESS_FECHA_CREACION
	,ESS_MODIFICADO_POR
	,ESS_FECHA_MODIFICACION
FROM
	[GA2].[dbo].[ESS_ESTADO_SOLICITUD]
WHERE			
	ESS_ID=@ESS_ID
END