-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 18/05/2021
-- Description:	Obtiene los documentos por tipo 
-- estado
-- =============================================
create PROCEDURE ObtenerDocumentosCarga
	
    @ESD_ID integer
   
AS 
BEGIN

SELECT DCT_ID, TDC_ID, DCT_NOMBRE,UEJ_ID, DCT_FECHA_INICIAL, ESD_ID, CED_ID, DCT_FECHA_FINAL, DCT_ID_ANULA, DCT_ALERTA
FROM DCT_DOCUMENTO where ESD_ID = @ESD_ID 
 
END;
