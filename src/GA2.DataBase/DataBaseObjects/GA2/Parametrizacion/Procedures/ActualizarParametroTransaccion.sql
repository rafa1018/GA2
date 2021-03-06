/*
Nombre: ActualizarParametroTransaccion
Descripcion: Actualiza los Parametros de la Transaccion
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 7 de 2021
*/
CREATE PROCEDURE ActualizarParametroTransaccion
	-- Add the parameters for the stored procedure here
	@PARAM_TRANS_ID int,
	@PARAM_TRANS_CONCEPTO varchar(50),
	@PARAM_TRANS_CODIGO int,
	@PARAM_TRANS_PROCESO varchar(50),
	@PARAM_TRANS_CREADO_POR UNIQUEIDENTIFIER,
	@PARAM_TRANS_FECHA_CREACION datetime,
	@PARAM_TRANS_MODIFICADO_POR UNIQUEIDENTIFIER,
	@PARAM_TRANS_FECHA_MODIFICACION datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--Insert statements for procedure here

UPDATE PARAM_TRANSACCION

SET

PARAM_TRANS_CONCEPTO = @PARAM_TRANS_CONCEPTO,
PARAM_TRANS_CODIGO = @PARAM_TRANS_CODIGO,
PARAM_TRANS_PROCESO = @PARAM_TRANS_PROCESO,
PARAM_TRANS_CREADO_POR = @PARAM_TRANS_CREADO_POR,
PARAM_TRANS_FECHA_CREACION = @PARAM_TRANS_FECHA_CREACION,
PARAM_TRANS_MODIFICADO_POR = @PARAM_TRANS_MODIFICADO_POR,
PARAM_TRANS_FECHA_MODIFICACION = @PARAM_TRANS_FECHA_MODIFICACION

WHERE PARAM_TRANS_ID = @PARAM_TRANS_ID
END
