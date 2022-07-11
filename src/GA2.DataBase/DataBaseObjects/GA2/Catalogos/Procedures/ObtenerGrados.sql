/*
Nombre: ObtenerGrados
Descripcion: Obteniene grados que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].[ObtenerGrados]
as
	SELECT GRD_ID
,GRD_DESCRIPCION
,CTG_ID
,GRD_ESPECIAL
,GRD_CODIGO
,GRD_SIGLA
,FRZ_ID
,GRD_CIVIL
,GRD_ACTIVO
,GRD_FACTOR_SBS
	FROM GRD_GRADO
	WHERE GRD_ACTIVO = 1