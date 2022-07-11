-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Obtener Restricciones  Por Id
-- =============================================
CREATE PROCEDURE ObtenerRestriccionesPorId
	  @RTC_ID uniqueidentifier
AS
BEGIN
		
	SELECT RTC_ID, TRA_ID, RTC_NOMBRE, TRA_ID_RESTRICCION, TRA_CREATEDOPOR, TRA_FECHACREACION, TRA_MODIFICADOPOR, TRA_FECHAMODIFICACION
	FROM RTC_RESTRINCIONES WHERE RTC_ID=@RTC_ID

END;


 