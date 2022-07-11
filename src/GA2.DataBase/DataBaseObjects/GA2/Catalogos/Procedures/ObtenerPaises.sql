/*
Nombre: ObtenerPaises
Descripcion: Obteniene paises que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE OR ALTER PROCEDURE [dbo].ObtenerPaises
as
	SELECT DPP_ID
,DPP_CODIGO
,DPP_NOMBRE
	FROM DPP_PAIS
