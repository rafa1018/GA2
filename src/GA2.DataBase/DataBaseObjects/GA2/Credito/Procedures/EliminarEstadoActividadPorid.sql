USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarEstadoActividadPorid]    Script Date: 6/07/2021 11:55:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Eliminar Estado Actividad por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarEstadoActividadPorid]
	-- Add the parameters for the stored procedure here
	@ESA_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE
	[dbo].[ESA_ESTADO_ACTIVIDAD]
SET
    ESA_ESTADO=0       
WHERE
	ESA_ID=@ESA_ID
SELECT
	ESA_ID
	,ESA_DESCRIPCION
	,ESA_ESTADO
	,ESA_CREADO_POR
	,ESA_FECHA_CREACION
	,ESA_MODIFICADO_POR
	,ESA_FECHA_MODIFICACION
FROM
	[GA2].[dbo].[ESA_ESTADO_ACTIVIDAD]
WHERE			
	ESA_ID=@ESA_ID
END