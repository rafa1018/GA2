IF OBJECT_ID('PGE_PROGRAMA_EDUCATIVO', 'U') > 0
BEGIN
	DROP TABLE PGE_PROGRAMA_EDUCATIVO;
END

CREATE TABLE PGE_PROGRAMA_EDUCATIVO (
	PGE_ID uniqueidentifier PRIMARY KEY,
	PGE_DESCRIPCION VARCHAR(50),
	PGE_ESTADO BIT NOT NULL,
	PGE_CREATEDOPOR uniqueidentifier NOT NULL,
	PGE_FECHACREACION DATETIME NOT NULL,
	PGE_MODIFICADOPOR uniqueidentifier NULL,
	PGE_FECHAMODIFICACION DATETIME NULL
);