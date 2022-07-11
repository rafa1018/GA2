-- =============================================
--Author:		Oscar Julian Rojas
-- Fecha: 09 / 08 / 2021
-- Descripcion: Eliminar Tarea por id
-- =============================================
create PROCEDURE EliminarTareaPorId
	
	@TRA_ID uniqueidentifier
	
AS
BEGIN
		
	DELETE 
	FROM TRA_TAREA WHERE TRA_ID=@TRA_ID
	
END;
