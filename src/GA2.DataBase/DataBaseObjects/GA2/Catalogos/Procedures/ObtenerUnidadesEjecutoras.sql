/*
Nombre: ObtenerUnidadesEjecutoras
Descripcion: Obtiene unidades ejecutoras que existen
Elaboro: Jorge Alberto Parrado Mariño
Fecha: Mayo 7 de 2021
*/


CREATE PROCEDURE ObtenerUnidadesEjecutoras	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
    -- Insert statements for procedure here
	SELECT UEJ_ID, TID_ID, UEJ_IDENTIFICACION, UEJ_NOMBRE, UEJ_SIGLA, UEJ_FECHA, FRZ_ID, UEJ_CODIGO, UEJ_TASA_APORTE, UEJ_AREA_NEGOCIO, FRM_ID, UEJ_AVAL
	FROM GA2.dbo.UEJ_UNIDADES_EJECUTORAS

END