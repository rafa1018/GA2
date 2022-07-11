-- =============================================
-- Author:		Oscar Julian Rojas
-- Create date: 06/05/2021
-- Description:	SP para crear el registro de guardado del blostorage
-- =============================================
CREATE PROCEDURE GuardarBlobStorage
	@CONTAINERNAME nvarchar(200),
	@BLOBNAME nvarchar(200),
	@MODULO nvarchar(20),
	@CREADOPOR uniqueidentifier,
	@FECHACREACION datetime
AS 
BEGIN
DECLARE @ID uniqueidentifier = newid()

INSERT INTO GA2.dbo.BLB_BLOBSTORAGE
(ID, CONTAINERNAME, BLOBNAME,MODULO, CREADOPOR, FECHACREACION, ESTADO)
VALUES(@ID, @CONTAINERNAME, @BLOBNAME,@MODULO, @CREADOPOR, @FECHACREACION, 1)

SELECT ID, CONTAINERNAME, BLOBNAME, MODIFICADOPOR,MODULO, FECHAMODIFICACION, CREADOPOR, FECHACREACION, ESTADO
FROM BLB_BLOBSTORAGE WHERE ID = @ID

END;