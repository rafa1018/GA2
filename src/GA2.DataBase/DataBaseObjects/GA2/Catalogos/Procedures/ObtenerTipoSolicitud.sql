------------------------------------------
--auhtor Erwin Pantoja España
--descripcion: Procedimiento para listar los tipos de solicitud
--date: 23/09/2021
------------------------------------------
IF OBJECT_ID('ObtenerTipoSolicitud') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerTipoSolicitud
END
GO
CREATE PROCEDURE ObtenerTipoSolicitud
	@TPA_ID		INT
AS
BEGIN
	SELECT PCS_ID, UPPER(PCS_NOMBRE) AS PCS_NOMBRE, PCS_ESTADO FROM PSC_PROCESO WHERE TPA_ID = @TPA_ID
END

