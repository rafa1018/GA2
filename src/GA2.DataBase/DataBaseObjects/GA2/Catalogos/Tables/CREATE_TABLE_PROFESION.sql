------------------------------------------
-- auhtor Oscar Julian Rojas
-- descripcion: Tabla para entidades de prosiones
-- date: 21/04/2021
------------------------------------------



IF OBJECT_ID('GA2.dbo.PRF_PROFESION') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PRF_PROFESION;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PRF_PROFESION(
   PRF_ID int IDENTITY(1,1) NOT NULL,
   PRF_DESCRIPCION varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
   PRF_ESTADO int NOT NULL,
	PRF_CREADO_POR uniqueidentifier NOT NULL,
	PRF_FECHA_CREACION datetime NOT NULL,
	PRF_ACTUALIZADO_POR uniqueidentifier NOT NULL,
	PRF_FECHA_ACTUALIZA datetime NOT NULL,
	CONSTRAINT PK_PRF_PROFESION PRIMARY KEY(PRF_ID)
) GO;
END