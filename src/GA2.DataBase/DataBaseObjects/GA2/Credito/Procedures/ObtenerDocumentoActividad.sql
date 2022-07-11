USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDocumentoActividad]    Script Date: 7/07/2021 12:44:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <10/05/2021>
-- Description:	<Obtener Documento Actividad>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerDocumentoActividad]
AS
BEGIN
SELECT	
	DCA_ID
	,AFL_ID
	,TDC_ID
	,DCA_ORDEN
	,DCA_OBLIGATORIO
	,DCA_CARGA
	,DCA_VISUALIZA
	,DCA_VISUALIZA_CLIENTE
	,DCA_ESTADO
	,DCA_CREADO_POR
	,DCA_FECHA_CREACION
	,DCA_MODIFICADO_POR
	,DCA_FECHA_MODIFICACION
FROM 
	[DCA_DOCUMENTO_ACTIVIDAD]
WHERE DCA_ESTADO=1
END
