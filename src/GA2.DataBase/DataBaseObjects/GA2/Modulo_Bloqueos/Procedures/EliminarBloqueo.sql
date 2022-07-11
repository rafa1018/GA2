/*
Nombre: EliminarBloqueo
Descripcion: Elimina bloqueo
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].EliminarBloqueo
@ID int,
@CODIGO int,
@CONCEPTO nvarchar(25),
@DIASMORA nvarchar(25),
@REVERSIBLE bit,
@ACELERACIONDEUDA bit,
@FECHAMODIFICACION datetime,
@MODIFICADOPOR int,
@ESTADO bit
AS 
BEGIN
UPDATE GA2..MOD_BLOQUEOS
SET 
MOD_B_ESTADO = 0
WHERE MOD_B_ID = @ID
END