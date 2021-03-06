
CREATE TABLE GA2.dbo.CLA_CLASIFICACION_ARCHIVO (
	CLA_ID int IDENTITY(1,1) NOT NULL,
	CLA_CODIGO NVARCHAR(50)
	CLA_DESCRIPCION Nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CLA_FECHA_CREACION datetime not null,
	CLA_CREADO_POR uniqueidentifier not null,,
	CLA_FECHA_MODIFICACION datetime null,
	CLA_MODIFICADO_POR uniqueidentifier null,
	CLA_ESTADO bit default true
) GO;