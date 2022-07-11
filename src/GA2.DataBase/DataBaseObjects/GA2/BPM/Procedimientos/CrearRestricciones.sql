-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Crear Restricciones 
-- =============================================
CREATE PROCEDURE CrearRestricciones
	  @TRA_ID uniqueidentifier,
      @RTC_ID uniqueidentifier,
      @RTC_NOMBRE nvarchar,
      @TRA_ID_RESTRICCION uniqueidentifier,
      @RTC_CREATEDOPOR uniqueidentifier,
      @RTC_FECHACREACION datetime
AS
BEGIN
	
	INSERT INTO RTC_RESTRINCIONES
	(RTC_ID, 
	TRA_ID, 
	RTC_NOMBRE, 
	TRA_ID_RESTRICCION, 
	TRA_CREATEDOPOR, 
	TRA_FECHACREACION)
VALUES(@RTC_ID, 
	@TRA_ID, 
	@RTC_NOMBRE, 
	@TRA_ID_RESTRICCION, 
	@RTC_CREATEDOPOR, 
	@RTC_FECHACREACION)
	
	SELECT RTC_ID, TRA_ID, RTC_NOMBRE, TRA_ID_RESTRICCION, TRA_CREATEDOPOR, TRA_FECHACREACION, TRA_MODIFICADOPOR, TRA_FECHAMODIFICACION
	FROM RTC_RESTRINCIONES WHERE RTC_ID=@RTC_ID

END;


 