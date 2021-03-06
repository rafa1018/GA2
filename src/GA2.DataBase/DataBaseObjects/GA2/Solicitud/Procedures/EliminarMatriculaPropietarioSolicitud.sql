IF OBJECT_ID('EliminarMatriculaPropietarioSolicitud', 'P') > 0
BEGIN
	DROP PROCEDURE EliminarMatriculaPropietarioSolicitud
END
GO
CREATE PROCEDURE EliminarMatriculaPropietarioSolicitud
	@SOL_ID_FK				UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM PMA_PROPIETARIO_MATRICULA
	WHERE MAI_ID IN (SELECT MAI_ID FROM MAI_MATRICULA_INMOBILIARIA WHERE SOL_ID_FK = @SOL_ID_FK)
END