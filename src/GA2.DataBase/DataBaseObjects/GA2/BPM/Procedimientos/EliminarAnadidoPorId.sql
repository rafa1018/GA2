-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Eliminar Añadidos por id
-- =============================================
CREATE PROCEDURE EliminarAnadidoPorId
	@AND_ID uniqueidentifier
AS
BEGIN
	DELETE FROM AND_ANADIDOS WHERE AND_ID=@AND_ID
END;
