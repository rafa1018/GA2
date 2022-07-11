-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 18/05/2021
-- Description:	Crea los tipos de documentos para
-- generar los archivos que se van a cargar
-- =============================================
ALTER PROCEDURE CrearDocumentoCarga
	
	@DCT_ID uniqueidentifier, 
    @TDC_ID integer,
    @DCT_NOMBRE nvarchar(30),
    @DCT_FECHA_INICIAL Datetime
AS 
BEGIN
INSERT INTO DCT_DOCUMENTO
(DCT_ID, TDC_ID, DCT_NOMBRE, DCT_FECHA_INICIAL, ESD_ID)
VALUES(@DCT_ID, @TDC_ID, @DCT_NOMBRE, @DCT_FECHA_INICIAL, 1)

SELECT DCT_ID, TDC_ID, DCT_NOMBRE, DCT_FECHA_INICIAL, ESD_ID, CED_ID, DCT_FECHA_FINAL, DCT_ID_ANULA, DCT_ALERTA
FROM DCT_DOCUMENTO where DCT_ID = @DCT_ID
 
END;