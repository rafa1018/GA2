IF OBJECT_ID('ObtenerEntidadBancaria', 'P')>0
BEGIN
	DROP PROCEDURE ObtenerEntidadBancaria
END
GO
CREATE PROCEDURE ObtenerEntidadBancaria
AS
BEGIN
	SELECT ENT_ID, UPPER(ENT_NOMBRE_RAZON_SOCIAL) AS ENT_NOMBRE_RAZON_SOCIAL, ENT_CODIGO_BANCO, ENT_ESTADO, ENT_CREATEDOPOR, ENT_FECHACREACION,
		   ENT_MODIFICADOPOR, ENT_FECHAMODIFICACION
	FROM ENT_ENTIDAD_BANCARIA 
END