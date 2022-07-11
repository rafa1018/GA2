-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	crear Añadidos
-- =============================================
CREATE PROCEDURE CrearAnadido
	@AND_ID uniqueidentifier,
	@TRA_ID uniqueidentifier,
	@AND_NOMBREANADIDO nvarchar,
	@AND_FILE nvarchar,
	@AND_TIPO tinyint,
	@AND_CREATEDOPOR uniqueidentifier,
	@AND_FECHACREACION datetime
AS
BEGIN
	
	INSERT INTO AND_ANADIDOS
	(AND_ID, 
	TRA_ID, 
	AND_NOMBREANADIDO, 
	AND_FILE, AND_TIPO, 
	AND_CREATEDOPOR, 
	AND_FECHACREACION)
VALUES(
	@AND_ID, 
	@TRA_ID, 
	@AND_NOMBREANADIDO, 
	@AND_FILE, 
	@AND_TIPO, 
	@AND_CREATEDOPOR, 
	@AND_FECHACREACION)
	
	SELECT AND_ID, TRA_ID, AND_NOMBREANADIDO, AND_FILE, AND_TIPO, AND_CREATEDOPOR, AND_FECHACREACION, AND_MODIFICADOPOR, AND_FECHAMODIFICACION
	FROM AND_ANADIDOS WHERE AND_ID=@AND_ID

	
END;
