------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_LEGAL_GMF') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_LEGAL_GMF;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_LEGAL_GMF (
	LEG_G_ID int IDENTITY(1,1) NOT NULL,
	LEG_G_GMF float NOT NULL,
	LEG_G_VIGENCIA_GMF datetime NOT NULL,
	LEG_G_FECHA_MODIFICACION datetime NOT NULL,
	LEG_G_MODIFICADO_POR int NOT NULL,
	LEG_G_ESTADO bit NULL,
	CONSTRAINT PARAM_LEGAL_GMF_PK PRIMARY KEY (LEG_G_ID)
);
END
