------------------------------------------
-- auhtor Oamilo Andres Yaya Poveda
-- descripcion: Tabla para los estados del modulo de notificaciones
-- date: 14 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.MOD_NOTIFICACIONES') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.MOD_NOTIFICACIONES;
END
ELSE
BEGIN

CREATE TABLE GA2.dbo.MOD_NOTIFICACIONES (
	MOD_N_ID uniqueidentifier primary key,
	MOD_N_MENSAJE nvarchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MOD_N_RECEPTOR int NOT NULL,
	MOD_N_TIPO nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MOD_N_VISTO bit NOT NULL,
	MOD_N_EMISOR int NOT NULL,
	MOD_N_FECHA_CREACION datetime NOT NULL,
	MOD_N_ESTADO bit DEFAULT 1 NULL
)
END