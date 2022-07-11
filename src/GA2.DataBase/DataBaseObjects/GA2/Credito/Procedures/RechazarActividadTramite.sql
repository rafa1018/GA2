/*
Nombre: RechazarActividadTramite
Descripcion:  Rechaza y Acualiza los datos de la actividad del tramite, por el 
			  proceso de actualiacion
Elaboro: German Eduardo Guarnizo
Fecha: Abril 27 de 2021
*/
CREATE PROCEDURE[dbo].[RechazarActividadTramite]
@AFL_ID int,
@TRS_ID uniqueidentifier,
@ACT_OBSERVACION varchar(500),
@ACT_MODIFICADO_POR uniqueidentifier,
@ACT_FECHA_MODIFICACION DATETIME

AS
BEGIN
    Declare @ID uniqueidentifier
    Declare @IDSOL uniqueidentifier

	Select @ID = AC.ACT_ID, @IDSOL = TR.SOC_ID
	  From ACT_ACTIVIDAD_TRAMITE_SOLIC AC With(NoLock),
	       TRS_TRAMITE_SOLICITUD TR With(NoLock)
	 Where AC.TRS_ID = @TRS_ID
	   AND AC.AFL_ID = @AFL_ID
	   AND AC.TRS_ID= TR.TRS_ID

	Update ACT_ACTIVIDAD_TRAMITE_SOLIC SET
				ACT_ESTADO = 5,
				ACT_OBSERVACION = @ACT_OBSERVACION,
				ACT_MODIFICADO_POR = @ACT_MODIFICADO_POR,
				ACT_FECHA_MODIFICACION = @ACT_FECHA_MODIFICACION,
				ACT_FECHA_FINALIZA = @ACT_FECHA_MODIFICACION
	 Where ACT_ID = @ID


	Insert into OAT_OBS_ACTIVIDAD_TRAMITE (OAT_ID, TRS_ID, ACT_ID, OAT_OBSERVACION, OAT_CREADO_POR, OAT_FECHA_CREACION)
	 Values (NEWID(), @TRS_ID, @ID, @ACT_OBSERVACION, @ACT_MODIFICADO_POR, @ACT_FECHA_MODIFICACION)

	--Actualizo la observacion del Tramite
	Update TRS_TRAMITE_SOLICITUD SET TRS_OBSERVACION = TRS_OBSERVACION+' '+@ACT_OBSERVACION,
									TRS_FECHA_MODIFICACION = @ACT_FECHA_MODIFICACION,
									TRS_MODIFICADO_POR = @ACT_MODIFICADO_POR,
									TRS_FECHA_FINALIZACION = @ACT_FECHA_MODIFICACION
    Where TRS_ID = @TRS_ID
	--- Actualizo el estado de la Solicitud como Rechazada
	Update SOC_SOLICITUD_CREDITO SET SOC_ESTADO = 'R',
									SOC_FECHA_ACTUALIZA = @ACT_FECHA_MODIFICACION,
									SOC_ACTUALIZADO_POR = @ACT_MODIFICADO_POR
    Where SOC_ID = @IDSOL
	--- Retorno Datos de la Actividad Actualizada
	Select * From ACT_ACTIVIDAD_TRAMITE_SOLIC
	 Where TRS_ID = @TRS_ID
	   AND AFL_ID = @AFL_ID
END
