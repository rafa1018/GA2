------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_SEGURO_UBICACION') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_SEGURO_UBICACION;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_SEGURO_UBICACION (
	SEU_ID int IDENTITY(1,1) NOT NULL,
	SEU_TODO_RIESGO numeric(4,2) NULL,
	DPD_ID int NOT NULL,
	DPC_ID int NOT NULL,
	SEU_FECHA_MODIFICACION datetime NULL,
	SEU_MODIFICADO_POR int NULL,
	SEU_ESTADO bit NULL,
	CONSTRAINT PK__PARAM_SE__1AC0107ABE7FDB08 PRIMARY KEY (SEU_ID)
);
END