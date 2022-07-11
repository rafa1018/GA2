------------------------------------------
--auhtor Erwin Pantoja España
--descripcion: Procedimiento para listar los tipos de cuenta
--date: 23/09/2021
------------------------------------------
IF OBJECT_ID('ObtenerTipoCuenta') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerTipoCuenta
END
GO
CREATE PROCEDURE ObtenerTipoCuenta
AS
BEGIN
	select TCT_ID, TCT_DESCRIPCION, TCT_PREFIJO, CAT_TIPO_GENERAL_CUENTA, TCT_APLICAN_INTERESES, TCT_APLICAN_RENDIMIENTOS, TCT_APLICAN_CUOTAS
	TCT_ACTIVA ,TCT_CENTRO_COSTO from TCT_TIPO_CUENTA
END


