-- =============================================
--Author:		Oscar Julian Rojas
-- Fecha: 09 / 08 / 2021
-- Descripcion: Eliminar Proceso Por Id
-- =============================================
create PROCEDURE EliminarProcesoPorId
	
	@PCS_ID uniqueidentifier
AS
BEGIN
	DELETE FROM PSC_PROCESO WHERE PCS_ID=@PCS_ID
END;
