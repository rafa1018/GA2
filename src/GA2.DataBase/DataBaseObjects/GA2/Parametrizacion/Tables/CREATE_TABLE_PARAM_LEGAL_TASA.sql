------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_LEGAL_TASA') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_LEGAL_TASA;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_LEGAL_TASA (
	LEG_T_ID int IDENTITY(1,1) NOT NULL,
	LEG_T_TASA_FRECH float NOT NULL,
	LEG_T_VIGENCIA_TASA_FRECH datetime NOT NULL,
	LEG_T_FECHA_MODIFICACION datetime NOT NULL,
	LEG_T_MODIFICADO_POR int NOT NULL,
	LEG_T_ESTADO bit NULL,
	CONSTRAINT PARAM_LEGAL_PK PRIMARY KEY (LEG_T_ID)
);
END