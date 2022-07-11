/*
Nombre: ObtenerActividadesEconomicas
Descripcion: Obteniene actividades economicas que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/
CREATE OR ALTER PROCEDURE [dbo].ObtenerActividadesEconomicas
AS
BEGIN
	SELECT ACC_ID, ACC_DESCRIPCION, ACC_CODIGO_CIUU, ACC_ESTADO, ACC_CREADO_POR, ACC_FECHA_CREACION, ACC_ACTUALIZADO_POR, ACC_FECHA_ACTUALIZA
	FROM ACC_ACTIVIDAD_ECONOMICA
END

GRANT EXECUTE ON OBJECT::dbo.ObtenerActividadesEconomicas
    TO GA2AZURELOGIN;  