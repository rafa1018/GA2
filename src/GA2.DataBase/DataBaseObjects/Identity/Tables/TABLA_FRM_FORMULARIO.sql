--------------------------------------------
--- author Oscar Julian Rojas
--- Descripcion: Tabla formulario de modulos
--- Date: 21/04/2021

CREATE TABLE GA2.dbo.FRM_FORMULARIO (
	FRM_ID uniqueidentifier NOT NULL primary key,
	MNU_ID uniqueidentifier null,
	FRM_SUBMODULOID uniqueidentifier NULL,
	FRM_DESCRIPCION nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	FRM_VISIBLE bit NOT NULL,
	FRM_MODIFIEDBY uniqueidentifier NULL,
	FRM_MODIFIEDON datetime NULL,
	FRM_CREATEBY uniqueidentifier NOT NULL,
	FRM_CREATEON datetime NOT NULL,
	FRM_STATE bit NOT NULL
) GO;