/*
Nombre: ObtenerTiposIdentificacion
Descripcion: Obtiene tipos de identificacion que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

CREATE PROC [dbo].[ObtenerTiposIdentificacion]
AS
	SELECT	TID_ID
			,TID_CODIGO
			,TID_DESCRIPCION
			,TID_EMPRESARIAL
			,TID_ACTIVO
			,TID_ERP
			,TID_AUDITORIA
			,TID_EMBARGO
	FROM TID_TIPO_IDENTIFICACION
