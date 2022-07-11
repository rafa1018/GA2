﻿/*
Nombre: UNIDADES_EJECUTORA
Descripcion: Tabla UNIDADES_EJECUTORA
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/


IF OBJECT_ID('GA2.dbo.UEJ_UNIDADES_EJECUTORAS') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.UEJ_UNIDADES_EJECUTORAS;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.UEJ_UNIDADES_EJECUTORAS (
	UEJ_ID int NOT NULL,
	TID_ID int NULL,
	UEJ_IDENTIFICACION varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UEJ_NOMBRE varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UEJ_SIGLA varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UEJ_FECHA datetime NULL,
	FRZ_ID int NULL,
	UEJ_CODIGO int NULL,
	UEJ_TASA_APORTE decimal(18,2) NULL,
	UEJ_AREA_NEGOCIO int NULL,
	FRM_ID int NULL,
	UEJ_AVAL bit NULL,
	CONSTRAINT PK__UEJ_UNID__07C0A72D22AC1D39 PRIMARY KEY (UEJ_ID)
);
END