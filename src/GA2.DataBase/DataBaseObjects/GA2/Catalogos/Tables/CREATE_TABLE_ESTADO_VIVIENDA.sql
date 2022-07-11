﻿/*
Nombre: ESTADO_VIVIENDA 
Descripcion: Tabla ESTADO_VIVIENDA 
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/


IF OBJECT_ID('GA2.dbo.ESV_ESTADO_VIVIENDA') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.ESV_ESTADO_VIVIENDA;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.ESV_ESTADO_VIVIENDA (
	ESV_ID int NOT NULL,
	ESV_DESCRIPCION varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);
END