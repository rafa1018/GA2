CREATE OR ALTER PROCEDURE [dbo].[EliminarUnidadEjecutoraCronograma](
	@CRO_ID				INT
)
AS 
BEGIN
	DELETE FROM CRO_CRONOGRAMANOVEDAD 
	WHERE CRO_ID = @CRO_ID

	EXEC ObtenerUnidadesEjecutorasCronograma
END