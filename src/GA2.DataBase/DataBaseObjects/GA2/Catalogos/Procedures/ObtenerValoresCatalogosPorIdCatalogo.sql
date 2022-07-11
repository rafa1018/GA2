IF OBJECT_ID('ObtenerValoresCatalogosPorIdCatalogo', 'P') > 0
BEGIN
	DROP PROCEDURE ObtenerValoresCatalogosPorIdCatalogo
END
GO
/*
Nombre: ObtenerValoresCatalogos
Descripcion: Obtiene todo el catalogo
Elaboro: Erwin Pantoja España
Fecha: Octubre 04 de 2021
*/
CREATE PROCEDURE [dbo].ObtenerValoresCatalogosPorIdCatalogo
	@CAT_ID			INT
AS
BEGIN
	SELECT CVL_ID, CAT_ID, CVL_CODIGO, CVL_DESCRIPCION, CVL_ACTIVO FROM CVL_CATALOGO_VALOR
	WHERE CAT_ID = @CAT_ID
END
