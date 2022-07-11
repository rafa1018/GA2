-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 18/05/2021
-- Description:	Actualiza los tipos de documentos cargados
-- =============================================
create PROCEDURE ActualizarDocumentoCarga
	@DCT_ID uniqueidentifier, 
    @ESD_ID integer,
    @DCT_NOMBRE nvarchar(30),
    @DCT_FECHA_FINAL Datetime,
    @DCT_MODIFICADOPOR UNIQUEIDENTIFIER, 
    @DCT_FECHAMODIFICACION  DATETIME
AS 
BEGIN
	UPDATE DCT_DOCUMENTO
	SET 
	ESD_ID=@ESD_ID, 
	CED_ID=0, 
	DCT_FECHA_FINAL=@DCT_FECHA_FINAL, 
	DCT_ID_ANULA=0, 
	DCT_ALERTA='',  
	DCT_FECHAMODIFICACION='', 
	DCT_MODIFICADOPOR=''
WHERE DCT_ID= @DCT_ID;

	

SELECT DCT_ID, TDC_ID, DCT_NOMBRE, DCT_FECHA_INICIAL, ESD_ID, CED_ID, DCT_FECHA_FINAL, DCT_ID_ANULA, DCT_ALERTA
FROM DCT_DOCUMENTO where DCT_ID = @DCT_ID
 
END;
