﻿IF OBJECT_ID('CrearSolicitud', 'P') > 0
BEGIN 
	DROP PROCEDURE CrearSolicitud
END
GO
CREATE PROCEDURE CrearSolicitud
	@CTA_ID						INT NULL,
	@TPS_SUB_ID					UNIQUEIDENTIFIER,
	@CLI_ID						INT,
	@SOL_CREATEDOPOR			UNIQUEIDENTIFIER,
	@TRA_ID						UNIQUEIDENTIFIER,
	@SOL_ESTADO_SOLICITUD		INT,
	@STL_ESTADO_SOLICITUD		INT
AS
BEGIN
	DECLARE @ID						AS	UNIQUEIDENTIFIER
	DECLARE @SLT_ID					AS	UNIQUEIDENTIFIER
	DECLARE	@FECHA_CREACION			AS	DATETIME

	SET @ID = NEWID()
	SET @SLT_ID = NEWID()
	SET @FECHA_CREACION = GETDATE()

	

	INSERT INTO SOL_SOLICITUD (
		SOL_ID,
		CTA_ID,
		TPS_SUB_ID,
		CLI_ID,
		SOL_FECHA_SOLICITUD,
		SOL_ESTADO_SOLICITUD,
		SOL_OBSERVACION,
		SOL_ESTADO,
		SOL_CREATEDOPOR,
		SOL_FECHACREACION,
		SOL_MODIFICADOPOR,
		SOL_FECHAMODIFICACION,
		SOL_VALOR_A_RETIRAR
	)
	VALUES (
		@ID,
		@CTA_ID,
		@TPS_SUB_ID,
		@CLI_ID,
		@FECHA_CREACION,
		@SOL_ESTADO_SOLICITUD,
		'',
		1,
		@SOL_CREATEDOPOR,
		@FECHA_CREACION,
		NULL,
		NULL,
		0
	)

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
	VALUES (
		@SLT_ID,
		@ID,
		@TRA_ID,
		@STL_ESTADO_SOLICITUD,
		'',
		1,
		@SOL_CREATEDOPOR,
		@FECHA_CREACION,
		NULL,
		NULL
	)

	SELECT  
		SOL_ID,
		CTA_ID,
		SOL_SOLICITUD.TPS_SUB_ID,
		CLI_ID,
		SOL_FECHA_SOLICITUD,
		SOL_ESTADO,
		@SLT_ID AS SLT_ID,
		TPS_TIPO_SUBMODALIDAD.TPS_SUB_DESCRIPCION,
		TIM_TIPO_MODALIDAD.TIM_DESCRIPCION,
		UPPER(PSC_PROCESO.PCS_DESCRIPCION) AS PCS_DESCRIPCION,
		SOL_VALOR_A_RETIRAR
	FROM SOL_SOLICITUD 
	INNER JOIN TPS_TIPO_SUBMODALIDAD
		ON SOL_SOLICITUD.TPS_SUB_ID = TPS_TIPO_SUBMODALIDAD.TPS_SUB_ID
	INNER JOIN TIM_TIPO_MODALIDAD
		ON TPS_TIPO_SUBMODALIDAD.TIM_ID = TIM_TIPO_MODALIDAD.TIM_ID
	INNER JOIN PSC_PROCESO
		ON TIM_TIPO_MODALIDAD.PCS_ID = PSC_PROCESO.PCS_ID
	WHERE SOL_ID = @ID
END
