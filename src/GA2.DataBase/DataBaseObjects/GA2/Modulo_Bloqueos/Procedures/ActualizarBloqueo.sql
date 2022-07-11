﻿/*
Nombre: ActualizarBloqueo
Descripcion: Actualizar bloqueo
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].ActualizarBloqueo
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
SET MOD_B_CODIGO = @CODIGO,
MOD_B_CONCEPTO = @CONCEPTO,
MOD_B_DIAS_MORA = @DIASMORA,
MOD_B_REVERSIBLE = @REVERSIBLE,
MOD_B_ACELERACION_DEUDA = @ACELERACIONDEUDA,
MOD_B_FECHA_MODIFICACION = @FECHAMODIFICACION,
MOD_B_MODIFICADO_POR = @MODIFICADOPOR,
MOD_B_ESTADO = @ESTADO
WHERE MOD_B_ID = @ID
END