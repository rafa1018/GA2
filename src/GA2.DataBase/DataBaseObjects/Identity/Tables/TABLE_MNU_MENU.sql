-----------------------------------------
--- Author Oscar Julian Rojas
--- Descripcion Talba Menu de aplicacion
--- Date 28-04-2021
------------------------------------------
CREATE TABLE MNU_MENU (
	MNU_ID uniqueidentifier primary key NOT NULL,
	APP_ID uniqueidentifier not null, 
	MNU_DESCRIPCION varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MNU_LINK varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MNU_ICONO varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	MNU_VISIBLE BIt null, 
	FRM_ID uniqueidentifier null,
	MNU_MODIFICADOPOR uniqueidentifier null,
	MNU_FECHAMODIFICACION datetime null, 
	MNU_CREADOPOR uniqueidentifier null,
	MNU_FECHACREACION  datetime null, 
	MNU_ESTADO bit null
) GO;