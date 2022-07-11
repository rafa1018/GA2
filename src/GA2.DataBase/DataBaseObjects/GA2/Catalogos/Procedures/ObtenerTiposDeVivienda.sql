/*
Nombre: ObtenerTiposDeVivienda
Descripcion: Obteniene tipos de vivienda que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].ObtenerTiposDeVivienda
as
	SELECT TVV_ID
,TVV_DESCRIPCION
,TVV_PROMOCIONADA
,TVV_ACTIVA
	FROM TVV_TIPO_VIVIENDA