------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_TASA') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_TASA;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_TASA (
	TAS_ID int IDENTITY(1,1) NOT NULL,
	TAS_USURA_EA float NOT NULL,
	TAS_USURA_NM float NOT NULL,
	TAS_CORRIENTE_EA float NOT NULL,
	TAS_CORRIENTE_NM float NOT NULL,
	TAS_FECHA_MODIFICACION datetime NOT NULL,
	TAS_MODIFICADO_POR int NOT NULL,
	TAS_ESTADO bit NULL,
	CONSTRAINT PARAM_TASA_PK PRIMARY KEY (TAS_ID)
);
END