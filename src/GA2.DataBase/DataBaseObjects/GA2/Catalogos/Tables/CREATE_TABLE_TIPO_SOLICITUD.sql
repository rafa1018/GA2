------------------------------------------
--auhtor Erwin Pantoja España
-- descripcion: Tabla para tipo de solicitudes
-- date: 23/09/2021
------------------------------------------

IF OBJECT_ID('GA2.dbo.TIS_TIPO_SOLICITUD') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.TIS_TIPO_SOLICITUD;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.TIS_TIPO_SOLICITUD (
	TIS_ID				INT		NOT NULL,
	TPA_ID				INT		NOT NULL,
	TIS_DESCRIPCION		VARCHAR(100) NOT NULL,
	TIS_ACTIVO			BIT NOT NULL
	CONSTRAINT PK_TIS_ID PRIMARY KEY (TIS_ID)
);
END