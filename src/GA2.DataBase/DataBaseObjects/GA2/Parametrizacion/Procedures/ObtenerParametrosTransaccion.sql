/*
Nombre: ObtenerParametrosTransaccion
Descripcion: Obtiene los Parametros de la Transaccion
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE ObtenerParametrosTransaccion
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--Insert statements for procedure here

SELECT * FROM PARAM_TRANSACCION;
END
