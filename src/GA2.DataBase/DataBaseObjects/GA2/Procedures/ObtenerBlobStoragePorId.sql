-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 06/05/2021
-- Description:	SP obtener los blob por id
-- =============================================
CREATE PROCEDURE ObtenerBlobStoragePorId
	@ID uniqueidentifier
AS 
BEGIN

SELECT ID, CONTAINERNAME, BLOBNAME, MODIFICADOPOR,MODULO, FECHAMODIFICACION, CREADOPOR, FECHACREACION, ESTADO
FROM BLB_BLOBSTORAGE WHERE ID = @ID

END;

