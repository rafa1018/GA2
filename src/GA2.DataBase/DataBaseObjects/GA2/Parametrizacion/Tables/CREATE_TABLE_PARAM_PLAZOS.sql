------------------------------------------
--auhtor Camilo Andres Yaya Poveda
-- descripcion: Tabla para los productos
-- date: 07 / 05 / 2021
------------------------------------------
IF OBJECT_ID('GA2.dbo.PARAM_PLAZOS') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.PARAM_PLAZOS;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.PARAM_PLAZOS (
	PLAZ_ID int IDENTITY(1,1) NOT NULL,
	PLAZ_YEAR_MIN float NOT NULL,
	PLAZ_MONTH_MIN float NOT NULL,
	PLAZ_YEAR_MAX float NOT NULL,
	PLAZ_MONTH_MAX float NOT NULL,
	PLAZ_FECHA_MODIFICACION datetime NOT NULL,
	PLAZ_MODIFICADO_POR int NOT NULL,
	PLAZ_ESTADO bit NULL,
	CONSTRAINT PARAM_PLAZOS_PK PRIMARY KEY (PLAZ_ID)
);
END