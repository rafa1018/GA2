/*
Nombre: EliminarEstado
Descripcion: Elimina el estado por el ID
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].EliminarEstado
@ID int,
@CODIGO int,
@CONCEPTO nvarchar(25),
@DIASMORAACTIVAESTADO nvarchar(25),
@SALDODEUDA nvarchar(25),
@FECHAMODIFICACION datetime,
@MODIFICADOPOR int,
@ESTADO bit
AS 
BEGIN
UPDATE GA2..MOD_ESTADO
SET 
EST_ESTADO = 0
WHERE EST_ID = @ID
END
