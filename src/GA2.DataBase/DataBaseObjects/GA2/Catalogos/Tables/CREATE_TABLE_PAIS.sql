/*
Nombre: PAIS
Descripcion: Tabla Pais
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/


IF OBJECT_ID('GA2.dbo.DPP_PAIS') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.DPP_PAIS;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.DPP_PAIS (
	DPP_ID int NOT NULL,
	DPP_CODIGO int NOT NULL,
	DPP_NOMBRE varchar(60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_DPP_PAIS PRIMARY KEY (DPP_ID)
);
END