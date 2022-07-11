/*
Nombre: ObtenerFuerzas
Descripcion: Obteniene fuerzas que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].ObtenerFuerzas
as
	SELECT FRZ_ID
,FRZ_CODIGO
,FRZ_DESCRIPCION
,FRZ_DIGITO
,FRZ_SOLDADO
	FROM FRZ_FUERZA
