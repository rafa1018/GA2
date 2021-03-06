CREATE OR ALTER PROCEDURE [dbo].[EditarFechaReporteCronograma](
	@CRO_ID				INT,
	@CRO_FECHA_REPORTE	DATE,
	@FRT_ID				INT,
	@MDE_ID				INT
)
AS 
BEGIN
	UPDATE CRO_CRONOGRAMANOVEDAD
	SET CRO_FECHA_REPORTE = @CRO_FECHA_REPORTE,
		FRT_ID = @FRT_ID,
		MDE_ID = @MDE_ID
	WHERE CRO_ID = @CRO_ID

	EXEC ObtenerUnidadesEjecutorasCronograma
END
