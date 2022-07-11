/*
Nombre: ObtenerTipoVivienda
Descripcion: Obtiene tipos de vivienda que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE ObtenerTipoVivienda
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TIV_TIPO_VIVIENDA
END
