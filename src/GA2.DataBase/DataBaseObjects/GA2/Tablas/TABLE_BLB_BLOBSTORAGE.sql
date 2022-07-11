--------------------------------------------
--- Author: Oscar Julian Rojas
--- Date: 06/05/2021
--- Descripcion: Tabla registro de blob storage
--------------------------------------------
CREATE TABLE BLB_BLOBSTORAGE(
	ID uniqueidentifier DEFAULT newid() NOT NULL primary key,
	CONTAINERNAME nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	BLOBNAME nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MODULO nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MODIFICADOPOR uniqueidentifier NULL,
	FECHAMODIFICACION datetime NULL,
	CREADOPOR uniqueidentifier NOT NULL,
	FECHACREACION datetime NOT NULL,
	ESTADO bit NOT NULL
) GO;