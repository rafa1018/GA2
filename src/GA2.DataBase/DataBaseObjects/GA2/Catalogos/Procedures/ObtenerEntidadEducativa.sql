﻿IF OBJECT_ID('ObtenerEntidadEducativa', 'P') > 0
BEGIN
	DROP PROCEDURE ObtenerEntidadEducativa
END
GO
CREATE PROCEDURE ObtenerEntidadEducativa
AS
BEGIN
	SELECT ENE_ID, ENE_NIT, UPPER(ENE_NOMBRE_RAZON_SOCIAL) AS ENE_NOMBRE_RAZON_SOCIAL
	FROM ENE_ENTIDAD_EDUCATIVA
END