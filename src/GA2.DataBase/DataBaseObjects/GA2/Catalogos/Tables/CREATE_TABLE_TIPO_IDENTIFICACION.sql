/*
Nombre: TIPO_IDENTIFICACION 
Descripcion: tabla TIPO_IDENTIFICACION
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/


IF OBJECT_ID('GA2.dbo.TID_TIPO_IDENTIFICACION') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.TID_TIPO_IDENTIFICACION;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.TID_TIPO_IDENTIFICACION (
	TID_ID int NOT NULL,
	TID_CODIGO varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TID_DESCRIPCION varchar(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TID_EMPRESARIAL int NOT NULL,
	TID_ACTIVO int NOT NULL,
	TID_ERP int NULL,
	TID_AUDITORIA int NULL,
	TID_EMBARGO int NULL,
	CONSTRAINT PK_TID_TIPO_DOC_IDENTIFICACION PRIMARY KEY (TID_ID)
);
END