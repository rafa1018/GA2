USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTipoDocumentoPorId]    Script Date: 7/07/2021 12:10:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <29/04/2021>
-- Description:	<Obtener Tipo Documento por id>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerTipoDocumentoPorId]
	-- Add the parameters for the stored procedure here
	@TDC_ID int
           
AS
BEGIN
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
	TDC_ID=@TDC_ID and
	TDC_ESTADO=1
END
