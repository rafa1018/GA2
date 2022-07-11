/*
Nombre: ObtenerDepartamentos
Descripcion: Obteniene departamentos que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].ObtenerDepartamentos
as
	SELECT DPD_ID
			,			DPP_ID
			,			DPD_CODIGO
			,			DPD_NOMBRE
			,			REG_ID
	FROM DPD_DEPARTAMENTO
