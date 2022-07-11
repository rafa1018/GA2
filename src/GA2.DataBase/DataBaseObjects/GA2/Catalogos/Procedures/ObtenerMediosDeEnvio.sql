-- =============================================
-- Author:		Oscar Rojas
-- Create date: 25/05/2021
-- Description:	SP para la obtener los formatos 
-- =============================================
CREATE OR ALTER PROCEDURE ObtenerMediosDeEnvio
AS
BEGIN
	SELECT MDE_ID, MDE_DESCRIPCION
	FROM MDE_MEDIOS_DE_ENVIO;
END