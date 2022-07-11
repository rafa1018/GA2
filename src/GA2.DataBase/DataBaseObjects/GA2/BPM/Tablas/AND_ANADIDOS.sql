--------------------------------------------
--- Descripcion: Añadidos de tareas sobre procesos
--- Autor: Oscar Julian Rojas
--- Fecha: 09/08/2021
---------------------------------------------
CREATE TABLE AND_ANADIDOS (

	AND_ID uniqueidentifier NOT NULL primary key,
	TRA_ID uniqueidentifier NOT NULL ,
	AND_NOMBREANADIDO nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	AND_FILE Datetime NULL,
	AND_TIPO tinyint null,
	AND_CREATEDOPOR uniqueidentifier NULL,
	AND_FECHACREACION datetime NULL,
	AND_MODIFICADOPOR uniqueidentifier NOT NULL,
	AND_FECHAMODIFICACION datetime NOT NULL
);
