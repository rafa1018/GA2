﻿IF OBJECT_ID('SOL_SOLICITUD', 'U') > 0
BEGIN
	DROP TABLE SOL_SOLICITUD
END
GO
--sol_solicitud
CREATE TABLE SOL_SOLICITUD (
	SOL_ID						UNIQUEIDENTIFIER	 PRIMARY KEY NOT NULL,
	CTA_ID						INT NOT NULL,
	PCS_ID						UNIQUEIDENTIFIER FOREIGN KEY REFERENCES PSC_PROCESO(PCS_ID) NOT NULL,
	TIS_ID						INT FOREIGN KEY REFERENCES TIS_TIPO_SOLICITUD(TIS_ID) NOT NULL,
	CLI_ID						INT NOT NULL,
	SOL_FECHA_SOLICITUD			DATETIME NOT NULL,
	SOL_OBSERVACION				VARCHAR(1024) NULL,
	SOL_ESTADO					BIT NOT NULL,
	SOL_CREATEDOPOR				UNIQUEIDENTIFIER	NOT NULL,
	SOL_FECHACREACION			DATETIME	NOT NULL,
	SOL_MODIFICADOPOR			UNIQUEIDENTIFIER	NULL,
	SOL_FECHAMODIFICACION		DATETIME NULL
)
