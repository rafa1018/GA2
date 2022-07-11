
IF OBJECT_ID('ObtenerValoresCatalogos') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerValoresCatalogos
END
GO
/*
Nombre: ObtenerValoresCatalogos
Descripcion: Obtiene todo el catalogo
Elaboro: Erwin Pantoja España
Fecha: Octubre 04 de 2021
*/
CREATE PROCEDURE ObtenerValoresCatalogos
AS
BEGIN
		SELECT CVL_ID, CAT_ID, CVL_CODIGO, CVL_DESCRIPCION, CVL_ACTIVO FROM CVL_CATALOGO_VALOR
END
