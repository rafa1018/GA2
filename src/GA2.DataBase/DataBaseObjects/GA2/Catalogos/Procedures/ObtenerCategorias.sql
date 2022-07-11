/*
Nombre: ObtenerCategorias
Descripcion: Obteniene categorias que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].ObtenerCategorias
as
	SELECT CTG_ID
			,CTG_DESCRIPCION
	FROM CTG_CATEGORIA
