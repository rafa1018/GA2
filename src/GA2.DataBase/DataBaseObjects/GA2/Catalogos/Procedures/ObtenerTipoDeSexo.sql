/*
Nombre: ObtenerTipoDeSexo
Descripcion: Obteniene tipos de sexo que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].[ObtenerTipoDeSexo]
as
	SELECT CVL_CODIGO, CVL_DESCRIPCION
	FROM CVL_CATALOGO_VALOR
	WHERE CAT_ID = 1
	Order by CVL_DESCRIPCION
