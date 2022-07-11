/*
Nombre: ObtenerEstadosCiviles
Descripcion: Obteniene estados civiles que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE proc [dbo].[ObtenerEstadosCiviles]
as
begin
	SELECT CVL_CODIGO, CVL_DESCRIPCION 
	  FROM CVL_CATALOGO_VALOR 
	 WHERE CAT_ID = 2
	ORDER BY CVL_DESCRIPCION
end