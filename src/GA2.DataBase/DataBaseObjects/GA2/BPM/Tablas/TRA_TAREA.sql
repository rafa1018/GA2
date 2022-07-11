--------------------------------------------
--- Descripcion: Tarea sobre procesos
--- Autor: Oscar Julian Rojas
--- Fecha: 09/08/2021
---------------------------------------------
CREATE TABLE TRA_TAREA (

	TRA_ID uniqueidentifier NOT NULL primary key,
	PCS_ID uniqueidentifier NOT NULL ,
	TRA_NOMBRE nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TRA_FECHAINICIO Datetime NOT NULL,
	TRA_FECHAFIN Datetime NULL,
	TRA_TAREA_CIERRE Datetime NULL,
	TRA_ACTIVA bit not null,
	RL_ID_RESPONSABLE uniqueidentifier not null,
	TRA_CREATEDOPOR uniqueidentifier NULL,
	TRA_FECHACREACION datetime NULL,
	TRA_MODIFICADOPOR uniqueidentifier NOT NULL,
	TRA_FECHAMODIFICACION datetime NOT NULL
);
