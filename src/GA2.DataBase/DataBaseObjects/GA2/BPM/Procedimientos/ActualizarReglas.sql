﻿-- =============================================
--Author:		Oscar Julian Rojas
-- Fecha: 09 / 08 / 2021
-- Descripcion: Update Reglas
-- =============================================
CREATE PROCEDURE ActualizarReglas
	@RGL_ID uniqueidentifier,
	@TRA_ID uniqueidentifier,
	@RGL_NOMBRE nvarchar,
	@RGL_CUMPLEREGLA bit,
	@RGL_MODIFICADOPOR uniqueidentifier,
	@RGL_FECHAMODIFICACION datetime
AS
BEGIN
	
	UPDATE RGL_REGLAS
	SET TRA_ID=@TRA_ID,
	RGL_NOMBRE = @RGL_NOMBRE,
	RGL_CUMPLEREGLA = @RGL_CUMPLEREGLA,
	RGL_MODIFICADOPOR = @RGL_MODIFICADOPOR,
	RGL_FECHAMODIFICACION = @RGL_FECHAMODIFICACION
	WHERE RGL_ID=@RGL_ID
	
	SELECT RGL_ID, TRA_ID, RGL_NOMBRE, RGL_CUMPLEREGLA, RGL_CREATEDOPOR, RGL_FECHACREACION, RGL_MODIFICADOPOR, RGL_FECHAMODIFICACION
	FROM RGL_REGLAS WHERE RGL_ID=@RGL_ID

END;
