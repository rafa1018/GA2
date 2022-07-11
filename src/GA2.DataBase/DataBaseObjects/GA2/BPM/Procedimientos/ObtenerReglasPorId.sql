-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Obtener Reglas Por Id
-- =============================================
CREATE PROCEDURE ObtenerReglasPorId
	@RGL_ID uniqueidentifier
AS
BEGIN

	SELECT RGL_ID, TRA_ID, RGL_NOMBRE, RGL_CUMPLEREGLA, RGL_CREATEDOPOR, RGL_FECHACREACION, RGL_MODIFICADOPOR, RGL_FECHAMODIFICACION
	FROM RGL_REGLAS WHERE RGL_ID=@RGL_ID

END;
