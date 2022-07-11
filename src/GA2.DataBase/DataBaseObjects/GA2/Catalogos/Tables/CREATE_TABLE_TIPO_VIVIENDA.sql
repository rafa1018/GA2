﻿/*
Nombre: TIPO_VIVIENDA
Descripcion: Tabla TIPO_VIVIENDA
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/


IF OBJECT_ID('GA2.dbo.TVV_TIPO_VIVIENDA') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.TVV_TIPO_VIVIENDA;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.TVV_TIPO_VIVIENDA (
	TVV_ID int NOT NULL,
	TVV_DESCRIPCION varchar(60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TVV_PROMOCIONADA int NOT NULL,
	TVV_ACTIVA int NOT NULL,
	CONSTRAINT PK_TVV_TIPO_VIVIENDA PRIMARY KEY (TVV_ID)
);
END