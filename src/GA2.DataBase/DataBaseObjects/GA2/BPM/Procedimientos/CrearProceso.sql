﻿-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Crear Proceso
-- =============================================
create PROCEDURE CrearProceso
	
	@PCS_ID uniqueidentifier, 
	@PCS_NOMBRE nvarchar, 
	@PCS_DESCRIPCION nvarchar, 
	@PSC_VERSION nvarchar, 
	@PCS_ESTADO bit, 
	@PSC_CREATEDOPOR uniqueidentifier, 
	@PSC_FECHACREACION datetime
AS
BEGIN
	
	INSERT INTO PSC_PROCESO(
	PCS_ID, 
	PCS_NOMBRE, 
	PCS_DESCRIPCION, 
	PSC_VERSION, 
	PCS_ESTADO, 
	PSC_CREATEDOPOR, 
	PSC_FECHACREACION)
VALUES(@PCS_ID, 
	@PCS_NOMBRE, 
	@PCS_DESCRIPCION, 
	@PSC_VERSION, 
	@PCS_ESTADO, 
	@PSC_CREATEDOPOR, 
	@PSC_FECHACREACION)
	
	SELECT PCS_ID, PCS_NOMBRE, PCS_DESCRIPCION, PSC_VERSION, PCS_ESTADO, PSC_CREATEDOPOR, PSC_FECHACREACION, PSC_MODIFICADOPOR, PSC_FECHAMODIFICACION
	FROM PSC_PROCESO WHERE PCS_ID=@PCS_ID
 	
END;