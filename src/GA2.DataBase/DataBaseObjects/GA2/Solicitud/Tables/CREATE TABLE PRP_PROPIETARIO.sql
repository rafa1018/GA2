/*
Nombre: PRP_PROPIETARIO
Descripcion: Tabla propietario para solicitud cesantías compra de vivienda
Elaboro: Hanson Restrepo
Fecha: Noviembre 18 de 2021
*/

IF OBJECT_ID('PRP_PROPIETARIO', 'U') > 0
BEGIN
	DROP TABLE PRP_PROPIETARIO;
END


CREATE TABLE PRP_PROPIETARIO (
	PRP_ID UNIQUEIDENTIFIER PRIMARY KEY,
	SOL_ID_FK UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SOL_SOLICITUD (SOL_ID),
	PRP_NUMERO_IDENTIFICACION VARCHAR(50) NOT NULL,
	PRP_NOMBRE_RAZON_SOCIAL VARCHAR(100) NOT NULL,
	TID_ID_FK INT FOREIGN KEY REFERENCES TID_TIPO_IDENTIFICACION (TID_ID),
	PRP_PARENTESCO_FK INT FOREIGN KEY REFERENCES CVL_CATALOGO_VALOR (CVL_ID),
	PRP_ESTADO BIT NOT NULL,
	PRP_CREATEDOPOR uniqueidentifier NOT NULL,
	PRP_FECHACREACION DATETIME NOT NULL,
	PRP_MODIFICADOPOR uniqueidentifier NULL,
	PRP_FECHAMODIFICACION DATETIME NULL
);
