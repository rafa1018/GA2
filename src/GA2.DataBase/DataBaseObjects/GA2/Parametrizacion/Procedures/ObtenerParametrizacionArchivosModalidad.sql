--

IF OBJECT_ID('ObtenerParametrizacionArchivosModalidad') IS NOT NULL
BEGIN
	DROP PROCEDURE ObtenerParametrizacionArchivosModalidad
END
GO
/*
Nombre: ObtenerParametrizacionArchivosModalidad
Descripcion: Obtiene la parametrizacion de los archivos por tipo de modalidad
Elaboro: Erwin Pantoja España
Fecha: Octubre 10 de 2021
*/
CREATE PROCEDURE ObtenerParametrizacionArchivosModalidad
	@TIM_ID				INT
AS
BEGIN
		SELECT PAM_ID, PAM_NOMBRE_ARCHIVO, PAM_DESCRIPCION_ARCHIVO, PAM_REQUERIDO, PAM_ESTADO, PAM_ORDEN
		FROM PAM_PARAMETRIZACION_ARHIVOS_MODALIDAD
		WHERE TIM_ID = @TIM_ID
		ORDER BY PAM_ORDEN ASC
END
