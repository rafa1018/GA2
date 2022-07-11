/*
Nombre: ObtenerCiudades
Descripcion: Obteniene ciudades que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].[ObtenerCiudades]
as
	SELECT	DPC_ID
			,DPD_ID
			,DPC_CODIGO
			,DPC_NOMBRE
	FROM DPC_CIUDAD