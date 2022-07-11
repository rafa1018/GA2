/*
Nombre: ObtenerNotificaciones
Descripcion: Obteniene los Notificaciones existentes que esten habilitados por el id 
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 14 de 2021
*/
CREATE PROC[dbo].ObtenerNotificaciones
@ID int
AS 
BEGIN
	SELECT MOD_N_ID,
	MOD_N_MENSAJE,
	MOD_N_RECEPTOR,
	MOD_N_TIPO,
	MOD_N_VISTO,
	MOD_N_EMISOR,
	MOD_N_FECHA_CREACION,
	MOD_N_ESTADO
	FROM MOD_NOTIFICACIONES
	WHERE MOD_N_ESTADO = 1 
	AND MOD_N_RECEPTOR = @ID 
	AND  MOD_N_VISTO = 0
END