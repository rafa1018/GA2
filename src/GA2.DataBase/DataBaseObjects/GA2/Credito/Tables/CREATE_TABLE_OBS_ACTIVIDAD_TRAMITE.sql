﻿/*
Nombre: OBS_ACTIVIDAD_TRAMITE
Descripcion: Tabla OBS_ACTIVIDAD_TRAMITE
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

IF OBJECT_ID('GA2.dbo.OAT_OBS_ACTIVIDAD_TRAMITE') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.OAT_OBS_ACTIVIDAD_TRAMITE;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.OAT_OBS_ACTIVIDAD_TRAMITE (
	OAT_ID uniqueidentifier NOT NULL,
	TRS_ID uniqueidentifier NOT NULL,
	ACT_ID uniqueidentifier NOT NULL,
	OAT_OBSERVACION varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	OAT_CREADO_POR uniqueidentifier NULL,
	OAT_FECHA_CREACION datetime NOT NULL,
	CONSTRAINT PK_OAT_OBS_ACTIVIDAD_TRAMITE PRIMARY KEY (OAT_ID)
);
END