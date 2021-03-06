/*
Nombre: CrearLegalTasa
Descripcion: Crea el legal tasa
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE[dbo].CrearLegalTasa
@ID int,
@TASAFRECH float,
@VIGENCIATASAFRECH datetime,
@FECHAMODIFICACION datetime,
@MODIFICADOPOR int,
@ESTADO bit
AS 
BEGIN
INSERT INTO GA2..PARAM_LEGAL_TASA
(LEG_T_TASA_FRECH,
LEG_T_VIGENCIA_TASA_FRECH,
LEG_T_FECHA_MODIFICACION,
LEG_T_MODIFICADO_POR,
LEG_T_ESTADO) 
VALUES(@TASAFRECH,
@VIGENCIATASAFRECH,
@FECHAMODIFICACION,
@MODIFICADOPOR,
@ESTADO)
END
