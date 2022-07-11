/*
Nombre: CrearLogOtp
Descripcion: Obtener direcciones cardinal
Elaboro: Oscar Julian Rojas Garces
Fecha: Abril 7 de 2021
*/
CREATE PROCEDURE [dbo].[ObtenerDireccionesCardinal] 

AS
BEGIN
SELECT CVL_ID, CAT_ID, CVL_CODIGO, CVL_DESCRIPCION, CVL_ACTIVO
FROM GA2.dbo.CVL_CATALOGO_VALOR WHERE CAT_ID = 62

END;
