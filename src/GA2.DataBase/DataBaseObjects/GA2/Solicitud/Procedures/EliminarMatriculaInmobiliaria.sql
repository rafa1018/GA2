
IF OBJECT_ID('EliminarMatriculaInmobiliaria', 'P') > 0
BEGIN
	DROP PROCEDURE EliminarMatriculaInmobiliaria
END
GO
CREATE PROCEDURE EliminarMatriculaInmobiliaria
	@SOL_ID_FK				UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM MAI_MATRICULA_INMOBILIARIA  WHERE SOL_ID_FK = @SOL_ID_FK
END