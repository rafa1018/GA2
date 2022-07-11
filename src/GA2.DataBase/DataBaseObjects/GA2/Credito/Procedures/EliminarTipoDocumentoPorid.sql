USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarTipoDocumentoPorid]    Script Date: 7/07/2021 12:09:27 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Eliminar documento por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarTipoDocumentoPorid]
	-- Add the parameters for the stored procedure here
	@TDC_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE TDC_TIPO_DOCUMENTO
SET
	TDC_ESTADO=0         
WHERE
	TDC_ID=@TDC_ID
SELECT	
	TDC_ID
	,TDC_DESCRIPCION
    ,TDC_ESTADO
    ,TDC_CREADO_POR
    ,TDC_FECHA_CREACION
    ,TDC_MODIFICADO_POR
    ,TDC_FECHA_MODIFICACION
FROM
	TDC_TIPO_DOCUMENTO
WHERE
	TDC_ID=@TDC_ID
END