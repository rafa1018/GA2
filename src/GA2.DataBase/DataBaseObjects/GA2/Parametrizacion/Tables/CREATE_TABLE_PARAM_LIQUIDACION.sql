------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_LIQUIDACION') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_LIQUIDACION;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_LIQUIDACION (
	LIQ_ID int IDENTITY(1,1) NOT NULL,
	LIQ_FECHA_CORTE float NOT NULL,
	LIQ_FECHA_PAGO float NOT NULL,
	LIQ_FECHA_MODIFICACION datetime NOT NULL,
	LIQ_MODIFICADO_POR int NOT NULL,
	LIQ_ESTADO bit NULL,
	CONSTRAINT PARAM_LIQUIDACION_PK PRIMARY KEY (LIQ_ID)
);
END