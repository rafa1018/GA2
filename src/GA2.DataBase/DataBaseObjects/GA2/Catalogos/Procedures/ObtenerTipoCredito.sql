/*
Nombre: ObtenerTipoCredito
Descripcion: Obtiene tipos de credito que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE ObtenerTipoCredito
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TCR_TIPO_CREDITO;
END
