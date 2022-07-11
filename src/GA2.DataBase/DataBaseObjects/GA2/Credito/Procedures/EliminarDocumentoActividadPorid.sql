USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[EliminarDocumentoActividadPorid]    Script Date: 7/07/2021 12:43:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Cristian Gonzalez>
-- Create date: <27/04/2021>
-- Description:	<Eliminar Documento Actividad por id>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarDocumentoActividadPorid]
	@DCA_ID int  
AS
BEGIN
UPDATE [DCA_DOCUMENTO_ACTIVIDAD]
SET
	DCA_ESTADO=0
       
WHERE
	DCA_ID=@DCA_ID
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
WHERE			
	DCA_ID=@DCA_ID 
END