/*
Nombre: CrearTasa
Descripcion: Crea el tasa
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].CrearTasa
@ID int,
@TASAUSURAEA float,
@TASAUSURANM float,
@TASACORRIENTEEA float,
@TASACORRIENTENM float,
@FECHAMODIFICACION datetime,
@MODIFICADOPOR int,
@ESTADO bit
AS 
BEGIN
INSERT INTO GA2..PARAM_TASA(
TAS_USURA_EA,
TAS_USURA_NM,
TAS_CORRIENTE_EA,
TAS_CORRIENTE_NM,
TAS_FECHA_MODIFICACION,
TAS_MODIFICADO_POR,
TAS_ESTADO) 
VALUES(@TASAUSURAEA,
@TASAUSURANM,
@TASACORRIENTEEA,
@TASACORRIENTENM,
@FECHAMODIFICACION,
@MODIFICADOPOR,
@ESTADO)
SELECT TAS_ID,
TAS_USURA_EA,
TAS_USURA_NM,
TAS_CORRIENTE_EA,
TAS_CORRIENTE_NM,
TAS_FECHA_MODIFICACION,
TAS_MODIFICADO_POR,
TAS_ESTADO
FROM GA2..PARAM_TASA
WHERE TAS_FECHA_MODIFICACION =
(SELECT MAX(TAS_FECHA_MODIFICACION) 
FROM GA2..PARAM_TASA WHERE TAS_ESTADO = 1)
UPDATE GA2..PARAM_TASA 
SET TAS_ESTADO = 0
WHERE TAS_ID = @ID
END