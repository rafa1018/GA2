/*
Nombre: ObtenerProductoById
Descripcion: Obtiene el producto por el id
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].[ObtenerProductoByID]
--Add the parameters for the stored procedure here
	@PRD_NUMERO_CREDITO int
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT* FROM PRD_PRODUCTO WHERE PRD_NUMERO_CREDITO=@PRD_NUMERO_CREDITO;
END
