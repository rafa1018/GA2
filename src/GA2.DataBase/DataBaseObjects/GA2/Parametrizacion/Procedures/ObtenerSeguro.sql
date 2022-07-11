﻿/*
Nombre: ObtenerSeguro
Descripcion: Obtiene el seguro
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROC[dbo].ObtenerSeguro
AS 
	SELECT SEG_ID,
	SEG_VIDA,
	SEG_TODO_RIESGO,
	SEG_FECHA_MODIFICACION,
	SEG_MODIFICADO_POR,
	SEG_ESTADO
	FROM GA2..PARAM_SEGURO
	WHERE SEG_FECHA_MODIFICACION =
	(SELECT MAX(SEG_FECHA_MODIFICACION) 
	FROM GA2..PARAM_SEGURO WHERE SEG_ESTADO = 1)