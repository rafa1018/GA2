﻿/*
Nombre: ObtenerPlazo
Descripcion: Obtiene el plazo
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROC[dbo].ObtenerPlazo
AS 
	SELECT PLAZ_ID,
	PLAZ_YEAR_MIN,
	PLAZ_MONTH_MIN,
	PLAZ_YEAR_MAX,
	PLAZ_MONTH_MAX,
	PLAZ_FECHA_MODIFICACION,
	PLAZ_MODIFICADO_POR,
	PLAZ_ESTADO
	FROM GA2..PARAM_PLAZOS
	WHERE PLAZ_FECHA_MODIFICACION =
	(SELECT MAX(PLAZ_FECHA_MODIFICACION) 
	FROM GA2..PARAM_PLAZOS WHERE PLAZ_ESTADO = 1)