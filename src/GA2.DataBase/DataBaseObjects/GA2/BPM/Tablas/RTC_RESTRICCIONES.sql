
   --------------------------------------------
--- Descripcion: Restricciones de tareas sobre procesos
--- Autor: Oscar Julian Rojas
--- Fecha: 09/08/2021
---------------------------------------------
CREATE TABLE RTC_RESTRINCIONES (

	RTC_ID uniqueidentifier NOT NULL primary key,
	TRA_ID uniqueidentifier NOT NULL ,
	RTC_NOMBRE nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TRA_ID_RESTRICCION  uniqueidentifier NULL ,
	TRA_CREATEDOPOR uniqueidentifier NULL,
	TRA_FECHACREACION datetime NULL,
	TRA_MODIFICADOPOR uniqueidentifier NOT NULL,
	TRA_FECHAMODIFICACION datetime NOT NULL
);
        
        
 