/*
Nombre: ObtenerActividadesEconomicas
Descripcion: Obteniene actividades economicas que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].ObtenerCatalogos
as
	SELECT	CTL_ID
			,CTL_NOMBRE
			,CTL_DESCRIPCION
			,CTL_EXPRESION
			,CTL_EDITABLE 
	FROM CTL_CATALOGO
