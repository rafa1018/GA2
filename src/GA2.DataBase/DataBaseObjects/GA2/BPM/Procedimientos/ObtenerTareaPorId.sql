-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Obtener  Tarea por id
-- =============================================
create PROCEDURE ObtenerTareaPorId
	@TRA_ID uniqueidentifier
	
AS
BEGIN
		
	SELECT TRA_ID, PCS_ID, TRA_NOMBRE, TRA_FECHAINICIO, TRA_FECHAFIN, TRA_TAREA_CIERRE, TRA_ACTIVA, RL_ID_RESPONSABLE, TRA_CREATEDOPOR, TRA_FECHACREACION, TRA_MODIFICADOPOR, TRA_FECHAMODIFICACION
	FROM TRA_TAREA WHERE TRA_ID=@TRA_ID

	
END;
