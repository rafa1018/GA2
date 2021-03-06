IF OBJECT_ID('SLT_SOLICITUD_TAREA', 'U') > 0
BEGIN
	DROP TABLE SLT_SOLICITUD_TAREA
END

CREATE TABLE SLT_SOLICITUD_TAREA (
	SLT_ID						UNIQUEIDENTIFIER	 PRIMARY KEY NOT NULL,
	SOL_ID						UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SOL_SOLICITUD(SOL_ID) NOT NULL,
	TRA_ID						UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TRA_TAREA(TRA_ID) NOT NULL,
	SLT_ESTADO_SOLICITUD		INT FOREIGN KEY REFERENCES CVL_CATALOGO_VALOR(CVL_ID) NOT NULL,
	SLT_OBSERVACION				VARCHAR(1024) NULL,
	SLT_ESTADO					BIT NOT NULL,
	SLT_CREATEDOPOR				UNIQUEIDENTIFIER	NOT NULL,
	SLT_FECHACREACION			DATETIME	NOT NULL,
	SLT_MODIFICADOPOR			UNIQUEIDENTIFIER	NULL,
	SLT_FECHAMODIFICACION		DATETIME NULL
)