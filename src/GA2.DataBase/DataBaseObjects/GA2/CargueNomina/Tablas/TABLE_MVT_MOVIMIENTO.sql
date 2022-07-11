---------------------------------------
-- Autor: Oscar Julian Rojas
-- Descripcion: Crear la tabla de movientos de cargue
-- Date: 22/05/2021
---------------------------------------
CREATE TABLE GA2.dbo.MVT_MOVIMIENTO (
	MVT_ID uniqueidentifier primary key NOT NULL,
	CTA_ID uniqueidentifier NOT NULL,
	CNC_ID int NOT NULL,
	MVT_VALOR numeric(25,2) NOT NULL,
	CAT_TIPO_MOVIMIENTO varchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MVT_FECHA_PROCESO datetime NOT NULL,
	DCT_ID varchar(36) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MVT_ANO_PERIODO int NOT NULL,
	MVT_MES_PERIODO varchar(4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	MVT_FECHA_MOVIMIENTO datetime NOT NULL
) GO;