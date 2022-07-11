-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Eliminar Reglas Por Id
-- =============================================
CREATE PROCEDURE EliminarReglasPorId
	@RGL_ID uniqueidentifier
AS
BEGIN

	DELETE 
	FROM RGL_REGLAS WHERE RGL_ID=@RGL_ID

END;
