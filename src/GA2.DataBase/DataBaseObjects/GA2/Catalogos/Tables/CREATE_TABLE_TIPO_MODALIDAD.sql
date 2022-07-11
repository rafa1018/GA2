------------------------------------------
--auhtor Erwin Pantoja España
-- descripcion: Tabla para tipo de solicitudes
-- date: 23/09/2021
------------------------------------------

IF OBJECT_ID('GA2.dbo.TIM_TIPO_MODALIDAD') IS NOT NULL
BEGIN
SELECT * FROM GA2.dbo.TIM_TIPO_MODALIDAD;
END
ELSE
BEGIN
CREATE TABLE GA2.dbo.TIM_TIPO_MODALIDAD (
	TIM_ID					INT		NOT NULL,
	TIS_ID					INT		FOREIGN KEY REFERENCES GA2.dbo.TIS_TIPO_SOLICITUD(TIS_ID),
	TIM_DESCRIPCION			VARCHAR(100) NOT NULL,
	TIM_ACTIVO				BIT NOT NULL
	CONSTRAINT PK_TIM_ID	PRIMARY KEY (TIM_ID)
);
END