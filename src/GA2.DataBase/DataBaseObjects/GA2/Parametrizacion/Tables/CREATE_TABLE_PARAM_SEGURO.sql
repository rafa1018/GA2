------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_SEGURO') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_SEGURO;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_SEGURO (
	SEG_ID int IDENTITY(1,1) NOT NULL,
	SEG_VIDA numeric(4,2) NULL,
	SEG_TODO_RIESGO numeric(4,2) NULL,
	SEG_FECHA_MODIFICACION datetime NULL,
	SEG_MODIFICADO_POR int NULL,
	SEG_ESTADO bit NULL,
	CONSTRAINT PK__PARAM_SE__E85CF313164B58F5 PRIMARY KEY (SEG_ID)
);
END