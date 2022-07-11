/*
Nombre: EliminarLegalTasa
Descripcion: Eliminar el legal tasa
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].EliminarLegalTasa
@ID int,
@TASAFRECH float,
@VIGENCIATASAFRECH datetime,
@FECHAMODIFICACION datetime,
@MODIFICADOPOR int,
@ESTADO bit
AS 
BEGIN
UPDATE GA2..PARAM_LEGAL_TASA
SET 
LEG_T_ESTADO = 0
WHERE LEG_T_ID = @ID
END
