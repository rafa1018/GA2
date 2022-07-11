/*
Nombre: ObtenerLegalTasa
Descripcion: Obtiene el legal tasa
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROC [dbo].ObtenerLegalTasa
as
	SELECT LEG_T_ID,
	LEG_T_TASA_FRECH,
	LEG_T_VIGENCIA_TASA_FRECH,
	LEG_T_FECHA_MODIFICACION,
	LEG_T_MODIFICADO_POR,
	LEG_T_ESTADO
	FROM PARAM_LEGAL_TASA
	WHERE LEG_T_ESTADO = 1
