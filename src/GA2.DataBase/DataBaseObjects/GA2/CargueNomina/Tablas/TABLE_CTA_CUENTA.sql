--------------------------------------------------
--- Descripcion: Cuenta de afiliados
--- Autor: Oscar Julian Rojas
--- Date: 22/05/2021
--------------------------------------------------
CREATE TABLE GA2.dbo.CTA_CUENTA (
	CTA_ID uniqueidentifier primary key NOT NULL,
	CTA_NUMERO int NOT NULL,
	CTA_SUBCUENTA int DEFAULT 0 NOT NULL,
	TCT_ID int NOT NULL,
	CTA_SALDO int NOT NULL,
	CTA_FECHA_CREACION datetime NOT NULL,
	ECT_ID int NOT NULL,
	CCN_ID int NULL,
	DCT_ID int NULL,
	TPA_ID int NOT NULL,
	CTA_CUOTAS int NULL,
	CTA_FECHA_CIERRE datetime NULL,
	CTA_ID_CUENTAHABIENTE int NOT NULL,
	CTA_CUOTAS_PENDIENTES int NOT NULL,
	CTA_FECHA_PRIMER_APORTE datetime NULL,
	CTA_SALDO_CANJE int NOT NULL,
	CTA_SALDO_DISPONIBLE int NOT NULL,
	CTA_PRINCIPAL bit NOT NULL
) GO
