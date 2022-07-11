﻿/*
Nombre: ObtenerLiquidacion
Descripcion: Obteniene la Liquidacion
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROC[dbo].ObtenerLiquidacion
AS 
	SELECT LIQ_ID,
	LIQ_FECHA_CORTE,
	LIQ_FECHA_PAGO,
	LIQ_FECHA_MODIFICACION,
	LIQ_MODIFICADO_POR,
	LIQ_ESTADO
	FROM GA2..PARAM_LIQUIDACION
	WHERE LIQ_FECHA_MODIFICACION =
	(SELECT MAX(LIQ_FECHA_MODIFICACION) 
	FROM GA2..PARAM_LIQUIDACION WHERE LIQ_ESTADO = 1)