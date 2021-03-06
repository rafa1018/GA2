/*
Nombre: SOLICITUD_PRODUCTO
Descripcion: Tabla SOLICITUD_PRODUCTO
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/

-- Drop table

-- DROP TABLE GA2.dbo.SOP_SOLICITUD_PRODUCTO;
IF OBJECT_ID('GA2.dbo.SOP_SOLICITUD_PRODUCTO') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.SOP_SOLICITUD_PRODUCTO;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.SOP_SOLICITUD_PRODUCTO (
	SOP_ID uniqueidentifier NOT NULL,
	SOC_ID uniqueidentifier NOT NULL,
	SOP_ESTADO_INMUEBLE varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_TIPO_INMUEBLE varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_TIENE_GARAJE varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_TIENE_DEPOSITO varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_CONJUNTO_CERRADO varchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TVV_ID int NOT NULL,
	SOP_AÑOS_CONSTRUCCION int NOT NULL,
	SOP_MATRICULA_INMOBILIARIA1 varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_MATRICULA_INMOBILIARIA2 varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_MATRICULA_INMOBILIARIA3 varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_VALOR_INMUEBLE float NOT NULL,
	SOP_DIRECCION_INMUEBLE varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DPD_ID int NOT NULL,
	DPC_ID int NOT NULL,
	SOP_VALOR_CREDITO float NOT NULL,
	SOP_PORC_FINANCIACION decimal(9,6) NOT NULL,
	SOP_PLAZO_FINANCIACION int NOT NULL,
	TID_ID int NULL,
	SOP_NUMERO_DOCUMENTO_CONSTRUCTOR varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SOP_NOMBRE_CONSTRUCTOR varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SOP_FECHA_ENTREGA_INMUEBLE date NULL,
	SOP_NOMBRE_FIDUCIA varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SOP_NOMBRE_PROYECTO varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TID_ID_VENDEDOR int NULL,
	SOP_NUMERO_DOCUMENTO_VENDEDOR varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SOP_NOMBRE_VENDEDOR varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	SOP_DIRECCION_VENDEDOR varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DPD_ID_VENDEDOR int NOT NULL,
	DPC_ID_VENDEDOR int NOT NULL,
	SOP_CORREO_VENDEDOR varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_TELEFONO_VENDEDOR varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	SOP_CREADO_POR uniqueidentifier NOT NULL,
	SOP_FECHA_CREACION datetime NOT NULL,
	SOP_ACTUALIZADO_POR uniqueidentifier NULL,
	SOP_FECHA_ACTUALIZA datetime NULL,
	CONSTRAINT PK_SOP_SOLICITUD_PRODUCTO PRIMARY KEY (SOP_ID),
	CONSTRAINT FK_SOP_SOLICITUD_PRODUCTO_DPC_CIUDAD FOREIGN KEY (DPC_ID) REFERENCES GA2.dbo.DPC_CIUDAD(DPC_ID),
	CONSTRAINT FK_SOP_SOLICITUD_PRODUCTO_DPC_CIUDAD1 FOREIGN KEY (DPC_ID_VENDEDOR) REFERENCES GA2.dbo.DPC_CIUDAD(DPC_ID),
	CONSTRAINT FK_SOP_SOLICITUD_PRODUCTO_DPD_DEPARTAMENTO FOREIGN KEY (DPD_ID) REFERENCES GA2.dbo.DPD_DEPARTAMENTO(DPD_ID),
	CONSTRAINT FK_SOP_SOLICITUD_PRODUCTO_DPD_DEPARTAMENTO1 FOREIGN KEY (DPD_ID_VENDEDOR) REFERENCES GA2.dbo.DPD_DEPARTAMENTO(DPD_ID),
	CONSTRAINT FK_SOP_SOLICITUD_PRODUCTO_SOC_SOLICITUD_CREDITO FOREIGN KEY (SOC_ID) REFERENCES GA2.dbo.SOC_SOLICITUD_CREDITO(SOC_ID),
	CONSTRAINT FK_SOP_SOLICITUD_PRODUCTO_TVV_TIPO_VIVIENDA FOREIGN KEY (TVV_ID) REFERENCES GA2.dbo.TVV_TIPO_VIVIENDA(TVV_ID)
);
END