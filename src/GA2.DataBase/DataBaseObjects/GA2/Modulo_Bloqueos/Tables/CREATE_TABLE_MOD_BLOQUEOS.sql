------------------------------------------
-- author Camilo Andres Yaya Poveda
-- descripcion: Tabla para los estados del modulo de estados
-- date: 07 / 05 / 2021
------------------------------------------

IF OBJECT_ID('GA2.dbo.MOD_BLOQUEOS') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.MOD_BLOQUEOS;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.MOD_BLOQUEOS (
	MOD_B_ID int IDENTITY(1,1) NOT NULL,
	MOD_B_CODIGO int NOT NULL,
	MOD_B_CONCEPTO varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MOD_B_DIAS_MORA varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MOD_B_REVERSIBLE bit NOT NULL,
	MOD_B_ACELERACION_DEUDA bit NOT NULL,
	MOD_B_FECHA_MODIFICACION datetime NOT NULL,
	MOD_B_MODIFICADO_POR int NOT NULL,
	MOD_B_ESTADO bit NULL,
	CONSTRAINT MOD_BLOQUEOS_PK PRIMARY KEY (MOD_B_ID)
);
END
