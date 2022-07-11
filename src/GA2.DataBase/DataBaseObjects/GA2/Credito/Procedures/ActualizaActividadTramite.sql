/*
Nombre: ActualizaActividadTramite
Descripcion:  Acualiza los datos de la actividad del tramite, por el 
			  proceso de actualiacion
Elaboro: German Eduardo Guarnizo
Fecha: Abril 27 de 2021
*/
CREATE PROCEDURE [dbo].[ActualizaActividadTramite] 
@AFL_ID int,
@TRS_ID uniqueidentifier,
@ACT_OBSERVACION varchar(500),
@ACT_MODIFICADO_POR uniqueidentifier,
@ACT_FECHA_MODIFICACION DATETIME

AS
BEGIN
    Declare @ID uniqueidentifier
	Select @ID = ACT_ID From ACT_ACTIVIDAD_TRAMITE_SOLIC
	 Where TRS_ID = @TRS_ID
	   AND AFL_ID = AFL_ID

	Update ACT_ACTIVIDAD_TRAMITE_SOLIC SET
				ACT_OBSERVACION = @ACT_OBSERVACION,
				ACT_MODIFICADO_POR = @ACT_MODIFICADO_POR,
				ACT_FECHA_MODIFICACION = @ACT_FECHA_MODIFICACION
	 Where ACT_ID = @ID
	
	Insert into OAT_OBS_ACTIVIDAD_TRAMITE (OAT_ID, TRS_ID, ACT_ID, OAT_OBSERVACION, OAT_CREADO_POR, OAT_FECHA_CREACION )
     Values (NEWID(), @TRS_ID, @ID, @ACT_OBSERVACION,@ACT_MODIFICADO_POR,@ACT_FECHA_MODIFICACION)

	--- Retorno Datos de la Actividad Actualizada
	Select * From ACT_ACTIVIDAD_TRAMITE_SOLIC
	 Where TRS_ID = @TRS_ID
	   AND AFL_ID = @AFL_ID
END
