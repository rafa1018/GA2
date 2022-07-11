------------------------------------------
--auhtor Oscar Julian Rojas
-- descripcion: Tabla para catalogos
-- date: 21 / 04 / 2021
------------------------------------------

IF OBJECT_ID('GA2.dbo.CTL_CATALOGO') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.CTL_CATALOGO;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.CTL_CATALOGO (
	CTL_ID int NOT NULL,
	CTL_NOMBRE varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CTL_DESCRIPCION varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CTL_EXPRESION varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CTL_EDITABLE bit NOT NULL,
	CONSTRAINT PK_CTL_ID PRIMARY KEY (CTL_ID)
);
END