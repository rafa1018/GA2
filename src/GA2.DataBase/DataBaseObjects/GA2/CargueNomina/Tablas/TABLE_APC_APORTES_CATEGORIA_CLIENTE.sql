-----------------------------------------------------------
--- Descripcion: Tabla de registro de aportes por categoria cliente
--- Autor: Oscar Julian Rojas
--- Date: 22/05/2021
-----------------------------------------------------------
CREATE TABLE GA2.dbo.APC_APORTES_CATEGORIA_CLIENTE (
	APC_ID uniqueidentifier primary key not null,
	CLI_ID int NOT NULL,
	CTG_ID int NOT NULL,
	APC_CUOTAS_ACUMULADAS int NOT NULL,
	APC_FECHA_ULTIMA_CUOTA datetime NULL,
	APC_FECHA_PRIMERA_CUOTA datetime NULL
) GO;