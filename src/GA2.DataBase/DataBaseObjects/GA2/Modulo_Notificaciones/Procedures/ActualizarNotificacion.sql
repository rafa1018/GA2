/*
Nombre: ActualizarNotificacion
Descripcion: Actualiza la notificacion por el ID
Elaboro: Camilo Andres Yaya Poveda
Fecha: Mayo 14 de 2021
*/
CREATE PROCEDURE[dbo].ActualizarNotificacion
@ID uniqueidentifier,
@VISTO bit,
@ESTADO bit
AS 
BEGIN
UPDATE GA2..MOD_NOTIFICACIONES
SET MOD_N_VISTO = @VISTO,
MOD_N_ESTADO = @ESTADO
WHERE MOD_N_ID = @ID


SELECT MOD_N_ID, MOD_N_MENSAJE, MOD_N_RECEPTOR, MOD_N_TIPO, MOD_N_VISTO, MOD_N_EMISOR, MOD_N_FECHA_CREACION, MOD_N_ESTADO
FROM MOD_NOTIFICACIONES WHERE MOD_N_ID = @ID
 
END