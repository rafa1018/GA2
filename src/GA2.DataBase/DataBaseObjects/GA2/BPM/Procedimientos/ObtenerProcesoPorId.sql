-- =============================================
-- Author:		Oscar Julian Rojas
-- Fecha: 09/08/2021
-- Descripcion:	Obtener Proceso Por Id
-- =============================================
create PROCEDURE ObtenerProcesoPorId
	
	@PCS_ID uniqueidentifier
AS
BEGIN
	
	
	SELECT PCS_ID, PCS_NOMBRE, PCS_DESCRIPCION, PSC_VERSION, PCS_ESTADO, PSC_CREATEDOPOR, PSC_FECHACREACION, PSC_MODIFICADOPOR, PSC_FECHAMODIFICACION
	FROM PSC_PROCESO WHERE PCS_ID=@PCS_ID
 	
END;
