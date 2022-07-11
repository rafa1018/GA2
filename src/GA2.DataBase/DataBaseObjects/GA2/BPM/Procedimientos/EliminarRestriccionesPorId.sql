-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Eliminar Restricciones  Por Id
-- =============================================
CREATE PROCEDURE EliminarRestriccionesPorId
	  @RTC_ID uniqueidentifier
AS
BEGIN
		
DELETE	FROM RTC_RESTRINCIONES WHERE RTC_ID=@RTC_ID

END;


 