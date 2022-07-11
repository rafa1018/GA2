-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 06/05/2021
-- Description:	SP eliminar los blob por id
-- =============================================
CREATE PROCEDURE EliminarBlobStoragePorId
	@ID uniqueidentifier
AS 
BEGIN

DELETE FROM BLB_BLOBSTORAGE
WHERE ID = @ID
END;

