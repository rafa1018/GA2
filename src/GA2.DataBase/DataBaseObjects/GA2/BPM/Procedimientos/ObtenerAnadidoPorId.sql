-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Obtener Añadidos por id
-- =============================================
CREATE PROCEDURE ObtenerAnadidoPorId
	@AND_ID uniqueidentifier

AS
BEGIN
	
	SELECT AND_ID, TRA_ID, AND_NOMBREANADIDO, AND_FILE, AND_TIPO, AND_CREATEDOPOR, AND_FECHACREACION, AND_MODIFICADOPOR, AND_FECHAMODIFICACION
	FROM AND_ANADIDOS WHERE AND_ID=@AND_ID

END;
