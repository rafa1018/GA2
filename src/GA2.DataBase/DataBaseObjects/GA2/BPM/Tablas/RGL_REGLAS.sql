--------------------------------------------
---Descripcion: Reglas de tareas sobre procesos
--- Autor: Oscar Julian Rojas
--- Fecha: 09 / 08 / 2021
-------------------------------------------- -
CREATE TABLE RGL_REGLAS(

	RGL_ID uniqueidentifier NOT NULL primary key,
	TRA_ID uniqueidentifier NOT NULL,
	RGL_NOMBRE nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	RGL_CUMPLEREGLA bit NULL,

	RGL_CREATEDOPOR uniqueidentifier NULL,
	RGL_FECHACREACION datetime NULL,
	RGL_MODIFICADOPOR uniqueidentifier NOT NULL,
	RGL_FECHAMODIFICACION datetime NOT NULL
);

