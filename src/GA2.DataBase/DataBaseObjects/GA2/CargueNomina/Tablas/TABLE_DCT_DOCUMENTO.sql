
-----------------------------------------------------------
--- Author Oscar Julian Rojas
--- Date 18/05/2021
--- Descripcion Crear los documentos de carga de archivos 
--- de nomina
-----------------------------------------------------------

CREATE TABLE GA2.dbo.DCT_DOCUMENTO (
	DCT_ID uniqueidentifier NOT NULL,
	TDC_ID int NOT NULL,
	DCT_NOMBRE nvarchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DCT_FECHA_INICIAL datetime NOT NULL,
	ESD_ID int DEFAULT 1 NOT NULL,
	UEJ_ID int not null,
	CED_ID int NULL,
	DCT_FECHA_FINAL datetime NULL,
	DCT_ID_ANULA int NULL,
	DCT_ALERTA varchar(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DCT_CREADOPOR uniqueidentifier NOT NULL,
	DCT_FECHACREACION datetime NOT NULL,
	DCT_FECHAMODIFICACION datetime NULL,
	DCT_MODIFICADOPOR uniqueidentifier NULL,
	CONSTRAINT PK__DCT_DOCU__41B1C6F107B7A80E PRIMARY KEY (DCT_ID)
) GO;