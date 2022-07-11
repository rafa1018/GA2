-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Obtener Tareas por proceso id
-- =============================================
if object_id('ObtenerTareasPorProcesoId', 'P') > 0
begin
	drop procedure ObtenerTareasPorProcesoId
end
go
create PROCEDURE ObtenerTareasPorProcesoId
	
	@PCS_ID uniqueidentifier
	
AS
BEGIN
	
		
	SELECT TRA_ID, PCS_ID, TRA_NOMBRE, TRA_FECHAINICIO, TRA_FECHAFIN, TRA_TAREA_CIERRE, TRA_ACTIVA, 
		RL_ID_RESPONSABLE, TRA_CREATEDOPOR, TRA_FECHACREACION, TRA_MODIFICADOPOR, TRA_FECHAMODIFICACION, TRA_ORDEN
	FROM TRA_TAREA WHERE PCS_ID=@PCS_ID

	
END;
