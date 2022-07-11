﻿/*
Nombre: ObtenerTasa
Descripcion: Obtiene el tasa
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROC[dbo].ObtenerTasa
AS 
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