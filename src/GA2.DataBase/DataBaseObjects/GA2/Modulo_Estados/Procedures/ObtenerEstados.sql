/*
Nombre: ObtenerEstados
Descripcion: Obteniene los estados existentes que esten habilitados
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROC[dbo].ObtenerEstados
as
	SELECT EST_ID,
	EST_CODIGO,
	EST_CONCEPTO,
	EST_DIAS_MORA_ACTIVA_ESTADO,
	EST_SALDO_DEUDA,
	EST_FECHA_MODIFICACION,
	EST_MODIFICADO_POR,
	EST_ESTADO
	FROM MOD_ESTADO
	WHERE EST_ESTADO = 1