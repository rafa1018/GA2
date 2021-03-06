IF OBJECT_ID ('AprobarSolicitudTarea', 'P') > 0
BEGIN
	DROP PROCEDURE AprobarSolicitudTarea
END
GO
CREATE PROCEDURE AprobarSolicitudTarea 
	@SLT_ID							UNIQUEIDENTIFIER,
	@SLT_ESTADO_SOLICITUD			INT,
	@SLT_ESTADO_SOLICITUD_NUEVO		INT
AS
BEGIN
	DECLARE
		@TAREA_SIGUIENTE		UNIQUEIDENTIFIER

	SELECT @TAREA_SIGUIENTE = TRA_TAREA2.TRA_ID 
	FROM SOL_SOLICITUD
		INNER JOIN TPS_TIPO_SUBMODALIDAD ON SOL_SOLICITUD.TPS_SUB_ID = TPS_TIPO_SUBMODALIDAD.TPS_SUB_ID
		INNER JOIN TIM_TIPO_MODALIDAD ON TPS_TIPO_SUBMODALIDAD.TIM_ID = TIM_TIPO_MODALIDAD.TIM_ID
		INNER JOIN PSC_PROCESO ON TIM_TIPO_MODALIDAD.PCS_ID = PSC_PROCESO.PCS_ID
		INNER JOIN TRA_TAREA ON PSC_PROCESO.PCS_ID = TRA_TAREA.PCS_ID
		INNER JOIN SLT_SOLICITUD_TAREA ON SOL_SOLICITUD.SOL_ID = SLT_SOLICITUD_TAREA.SOL_ID AND SLT_SOLICITUD_TAREA.TRA_ID = TRA_TAREA.TRA_ID
		INNER JOIN TRA_TAREA AS TRA_TAREA2 ON TRA_TAREA2.PCS_ID = TRA_TAREA.PCS_ID AND TRA_TAREA2.TRA_ORDEN = TRA_TAREA.TRA_ORDEN + 1
	WHERE SLT_SOLICITUD_TAREA.SLT_ID = @SLT_ID

	UPDATE SLT_SOLICITUD_TAREA
	SET SLT_ESTADO_SOLICITUD = @SLT_ESTADO_SOLICITUD
	WHERE SLT_ID = @SLT_ID

	INSERT INTO SLT_SOLICITUD_TAREA (
		SLT_ID, 
		SOL_ID, 
		TRA_ID, 
		SLT_ESTADO_SOLICITUD, 
		SLT_OBSERVACION, 
		SLT_ESTADO, 
		SLT_CREATEDOPOR, 
		SLT_FECHACREACION, 
		SLT_MODIFICADOPOR, 
		SLT_FECHAMODIFICACION
	)
	SELECT 
		NEWID(),
		SOL_ID,
		@TAREA_SIGUIENTE,
		@SLT_ESTADO_SOLICITUD_NUEVO,
		'', 
		SLT_ESTADO, 
		SLT_CREATEDOPOR, 
		GETDATE(), 
		SLT_MODIFICADOPOR, 
		SLT_FECHAMODIFICACION
	FROM SLT_SOLICITUD_TAREA WHERE SLT_ID = @SLT_ID

END