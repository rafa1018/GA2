﻿-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Actualizar Proceso
-- =============================================
create PROCEDURE ActualizarProceso
	
	@PCS_ID uniqueidentifier, 
	@PCS_NOMBRE nvarchar, 
	@PCS_DESCRIPCION nvarchar, 
	@PSC_VERSION nvarchar, 
	@PCS_ESTADO bit, 
	@PSC_MODIFICADOPOR uniqueidentifier, 
	@PSC_FECHAMODIFICACION datetime
AS
BEGIN
	
	UPDATE GA2.dbo.PSC_PROCESO
SET 
PCS_NOMBRE=@PCS_NOMBRE, 
PCS_DESCRIPCION=@PCS_DESCRIPCION, 
PSC_VERSION=@PSC_VERSION, 
PCS_ESTADO=@PCS_ESTADO, 
PSC_MODIFICADOPOR=@PSC_MODIFICADOPOR, 
PSC_FECHAMODIFICACION=@PSC_FECHAMODIFICACION
WHERE PCS_ID=@PCS_ID

	
	SELECT PCS_ID, PCS_NOMBRE, PCS_DESCRIPCION, PSC_VERSION, PCS_ESTADO, PSC_CREATEDOPOR, PSC_FECHACREACION, PSC_MODIFICADOPOR, PSC_FECHAMODIFICACION
	FROM PSC_PROCESO WHERE PCS_ID=@PCS_ID
 	
END;