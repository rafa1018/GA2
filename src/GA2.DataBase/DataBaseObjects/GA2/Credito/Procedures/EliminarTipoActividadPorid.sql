USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarTipoActividadPorid]    Script Date: 7/07/2021 12:05:18 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <04/05/2021>
-- Description:	<Eliminar Aseguradora por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarTipoActividadPorid]
	-- Add the parameters for the stored procedure here
	@TAC_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
SET
	TAC_ESTADO=0         
WHERE
	TAC_ID=@TAC_ID
SELECT
	TAC_ID
	,TAC_DESCRIPCION
	,TAC_ESTADO
	,TAC_CREADO_POR
	,TAC_FECHA_CREACION
	,TAC_MODIFICADO_POR
	,TAC_FECHA_MODIFICACION
FROM
	[GA2].[dbo].[TAC_TIPO_ACTIVIDAD]
WHERE			
	TAC_ID=@TAC_ID
END