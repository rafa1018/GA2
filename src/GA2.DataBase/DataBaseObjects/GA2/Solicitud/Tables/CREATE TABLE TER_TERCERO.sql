﻿/*
Nombre: TER_TERCERO
Descripcion: Tabla terceroa para solicitud cesantías compra de vivienda
Elaboro: Hanson Restrepo
Fecha: Noviembre 18 de 2021
*/

IF OBJECT_ID('TER_TERCERO', 'U') > 0
BEGIN
	DROP TABLE TER_TERCERO;
END

CREATE TABLE TER_TERCERO (
	TER_ID uniqueidentifier PRIMARY KEY,
	TER_NUMERO_DOCUMENTO VARCHAR(16) NOT NULL,
	TER_NOMBRE_RAZON_SOCIAL VARCHAR(100) NOT NULL,
	TER_DIRECCION VARCHAR(100),
	TER_CORREO_ELECTRONICO VARCHAR(50),
	TER_TELEFONO VARCHAR(20),
	TER_NUMERO_CUENTA VARCHAR(16),
	TER_NUMERO_LICENCIA_CONSTRUCCION VARCHAR(50),
	ENT_ID_FK uniqueidentifier FOREIGN KEY REFERENCES ENT_ENTIDAD_BANCARIA (ENT_ID),
	TID_ID_FK INT FOREIGN KEY REFERENCES TID_TIPO_IDENTIFICACION (TID_ID),
	DPC_ID_FK INT FOREIGN KEY REFERENCES DPC_CIUDAD (DPC_ID),
	TER_TIPO_TERCERO_FK INT FOREIGN KEY REFERENCES CVL_CATALOGO_VALOR (CVL_ID),
	TER_TIPO_CUENTA_FK INT FOREIGN KEY REFERENCES CVL_CATALOGO_VALOR (CVL_ID),
	TER_PARENTESCO INT FOREIGN KEY REFERENCES CVL_CATALOGO_VALOR (CVL_ID),
	SOL_ID_FK uniqueidentifier FOREIGN KEY REFERENCES SOL_SOLICITUD (SOL_ID),
	TER_NUM_RECIBO_PAGO VARCHAR(20) NULL,			-- NUM RECIBO
	TER_FECHA_LIMITE_PAGO DATETIME NULL,			-- FECHA LIMITE
	PGN_ID_FK uniqueidentifier FOREIGN KEY REFERENCES PGN_PROGRAMA_ENTIDAD (PGN_ID) NULL,
	PRN_ID_FK uniqueidentifier FOREIGN KEY REFERENCES PRN_PROGRAMA_NIVEL (PRN_ID) NULL,
	TER_ESAUTORIZADO BIT NULL,
	TER_ESTADO BIT NOT NULL,
	TER_CREATEDOPOR uniqueidentifier NOT NULL,
	TER_FECHACREACION DATETIME NOT NULL,
	TER_MODIFICADOPOR uniqueidentifier NULL,
	TER_FECHAMODIFICACION DATETIME NULL
);