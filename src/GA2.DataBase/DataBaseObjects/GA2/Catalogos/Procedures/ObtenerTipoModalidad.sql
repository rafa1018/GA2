------------------------------------------
--auhtor Erwin Pantoja España
--descripcion: Procedimiento para listar los tipos de modalidad
--date: 23/09/2021
------------------------------------------
IF OBJECT_ID('ObtenerTipoModalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerTipoModalidad
END
GO
CREATE PROCEDURE ObtenerTipoModalidad
	@TIS_ID		UNIQUEIDENTIFIER
AS
BEGIN
	SELECT TIM_ID, TIM_DESCRIPCION, TIM_ACTIVO, TIM_CODIGO FROM TIM_TIPO_MODALIDAD WHERE PCS_ID = @TIS_ID
	ORDER BY TIM_ORDEN ASC
END

