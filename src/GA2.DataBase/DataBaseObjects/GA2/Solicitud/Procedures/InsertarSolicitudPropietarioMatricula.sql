﻿IF OBJECT_ID('InsertarSolicitudPropietarioMatricula', 'P')>0
BEGIN
	DROP PROCEDURE InsertarSolicitudPropietarioMatricula
END
GO
CREATE PROCEDURE InsertarSolicitudPropietarioMatricula
	@PRP_ID				UNIQUEIDENTIFIER,
	@MAI_ID				UNIQUEIDENTIFIER,
	@PMA_CREATEDOPOR	UNIQUEIDENTIFIER
AS
BEGIN

	--DECLARE @ID			AS UNIQUEIDENTIFIER
	--SET @ID = NEWID()
	
	INSERT INTO PMA_PROPIETARIO_MATRICULA
	(
		PRP_ID,
		MAI_ID,
		PMA_ESTADO,
		PMA_CREATEDOPOR,
		PMA_FECHACREACION
	) 
	VALUES (
		@PRP_ID,
		@MAI_ID,
		1,
		@PMA_CREATEDOPOR,
		GETDATE()
	)

	SELECT
		@PRP_ID AS PRP_ID,
		@MAI_ID AS MAI_ID,
		@PMA_CREATEDOPOR AS PMA_CREATEDOPOR
	FROM PMA_PROPIETARIO_MATRICULA --WHERE PRP_ID = @ID
END