------------------------------------------
-- auhtor Oamilo Andres Yaya Poveda
-- descripcion: Tabla para los estados del modulo de estados
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.MOD_ESTADO') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.MOD_ESTADO;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.MOD_ESTADO (
	EST_ID int IDENTITY(1,1) NOT NULL,
	EST_CODIGO int NOT NULL,
	EST_CONCEPTO varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	EST_DIAS_MORA_ACTIVA_ESTADO varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	EST_SALDO_DEUDA varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	EST_FECHA_MODIFICACION datetime NOT NULL,
	EST_MODIFICADO_POR int NOT NULL,
	EST_ESTADO bit NULL,
	CONSTRAINT MOD_ESTADO_PK PRIMARY KEY (EST_ID)
);
END