USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTipoDocumento]    Script Date: 7/07/2021 12:09:54 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <07/05/2021>
-- Description:	<Obtener Tipo de documento>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerTipoDocumento]
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
	TDC_ESTADO=1
ORDER BY
	TDC_ID DESC
END
