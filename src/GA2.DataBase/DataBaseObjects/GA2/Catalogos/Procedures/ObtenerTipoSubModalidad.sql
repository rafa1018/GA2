------------------------------------------
--auhtor Erwin Pantoja España
--descripcion: Procedimiento para listar los tipos de submodalidad
--date: 23/09/2021
------------------------------------------
IF OBJECT_ID('ObtenerTipoSubModalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerTipoSubModalidad
END
GO
CREATE PROCEDURE ObtenerTipoSubModalidad
	@TIM_ID		UNIQUEIDENTIFIER
AS
BEGIN
	SELECT TPS_SUB_ID, TPS_SUB_DESCRIPCION, TPS_SUB_ACTIVO FROM TPS_TIPO_SUBMODALIDAD WHERE TIM_ID = @TIM_ID
	ORDER BY TPS_SUB_ORDEN ASC
END

