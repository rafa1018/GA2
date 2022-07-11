------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------

IF OBJECT_ID('GA2.dbo.PARAM_LEGAL_ALIVIO') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_LEGAL_ALIVIO;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_LEGAL_ALIVIO (
	LEG_A_ID int IDENTITY(1,1) NOT NULL,
	LEG_A_ALIVIO_CUOTA float NOT NULL,
	LEG_A_VIGENCIA_ALIVIO_CUOTA datetime NOT NULL,
	LEG_A_FECHA_MODIFICACION datetime NOT NULL,
	LEG_A_MODIFICADO_POR int NOT NULL,
	LEG_A_ESTADO bit NULL,
	CONSTRAINT PARAM_LEGAL_ALIVIO_PK PRIMARY KEY (LEG_A_ID)
);
END