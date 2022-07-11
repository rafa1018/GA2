--------------------------------------------
---Descripcion: Procesos de negocio
--- Autor: Oscar Julian Rojas
--- Fecha: 09 / 08 / 2021
--------------------------------------------
CREATE TABLE PSC_PROCESO(

	PCS_ID uniqueidentifier NOT NULL primary key,
	PCS_NOMBRE nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PCS_DESCRIPCION nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PSC_VERSION nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PCS_ESTADO bit not null,
	PSC_CREATEDOPOR uniqueidentifier NULL,
	PSC_FECHACREACION datetime NULL,
	PSC_MODIFICADOPOR uniqueidentifier NOT NULL,
	PSC_FECHAMODIFICACION datetime NOT NULL
);

