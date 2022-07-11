﻿------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_TRANSACCION') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_TRANSACCION;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_TRANSACCION (
	PARAM_TRANS_ID int IDENTITY(1,1) NOT NULL,
	PARAM_TRANS_CONCEPTO varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PARAM_TRANS_CODIGO int NOT NULL,
	PARAM_TRANS_PROCESO varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PARAM_TRANS_CREADO_POR uniqueidentifier NULL,
	PARAM_TRANS_FECHA_CREACION date NULL,
	PARAM_TRANS_MODIFICADO_POR uniqueidentifier NULL,
	PARAM_TRANS_FECHA_MODIFICACION date NULL,
	CONSTRAINT PK_PARAM_TRANSACCION PRIMARY KEY (PARAM_TRANS_ID)
);
END