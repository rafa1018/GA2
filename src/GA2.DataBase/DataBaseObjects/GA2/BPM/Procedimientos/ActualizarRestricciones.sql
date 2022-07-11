-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Actualizar Restricciones 
-- =============================================
CREATE PROCEDURE ActualizarRestricciones
	  @TRA_ID uniqueidentifier,
      @RTC_ID uniqueidentifier,
      @RTC_NOMBRE nvarchar,
      @TRA_ID_RESTRICCION uniqueidentifier,
      @TRA_MODIFICADOPOR uniqueidentifier,
      @TRA_FECHAMODIFICACION datetime
AS
BEGIN
	UPDATE RTC_RESTRINCIONES
	SET TRA_ID=@TRA_ID, 
	RTC_NOMBRE=@RTC_NOMBRE, 
	TRA_ID_RESTRICCION=@TRA_ID_RESTRICCION, 
	TRA_MODIFICADOPOR=@TRA_MODIFICADOPOR, 
	TRA_FECHAMODIFICACION=@TRA_FECHAMODIFICACION
	
	WHERE RTC_ID=@RTC_ID
	
	SELECT RTC_ID, TRA_ID, RTC_NOMBRE, TRA_ID_RESTRICCION, TRA_CREATEDOPOR, TRA_FECHACREACION, TRA_MODIFICADOPOR, TRA_FECHAMODIFICACION
	FROM RTC_RESTRINCIONES WHERE RTC_ID=@RTC_ID

END;


 