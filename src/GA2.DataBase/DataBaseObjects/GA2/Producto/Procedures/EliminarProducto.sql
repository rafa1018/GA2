/*
Nombre: EliminarProducto
Descripcion: Elimina el producto por el id
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].[EliminarProducto]
--Add the parameters for the stored procedure here
	@PRD_NUMERO_CREDITO int,
@PRD_ESTADO varchar (50),
	@PRD_FECHA_ESTADO date
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE PRD_PRODUCTO
	SET    PRD_ESTADO=@PRD_ESTADO
           , PRD_FECHA_ESTADO = @PRD_FECHA_ESTADO
           
	WHERE PRD_NUMERO_CREDITO=@PRD_NUMERO_CREDITO;

SELECT* FROM PRD_PRODUCTO WHERE PRD_NUMERO_CREDITO=@PRD_NUMERO_CREDITO;
END
