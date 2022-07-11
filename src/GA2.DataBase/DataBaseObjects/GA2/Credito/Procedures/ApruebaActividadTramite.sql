/*
Nombre: ApruebaActividadTramite
Descripcion:  Aprueba y Acualiza los datos de la actividad del tramite, por el 
			  proceso de actualiacion
Elaboro: German Eduardo Guarnizo
Fecha: Abril 27 de 2021
*/
CREATE PROCEDURE[dbo].[ApruebaActividadTramite]
@AFL_ID int,
@TRS_ID uniqueidentifier,
@ACT_OBSERVACION varchar(500),
@ACT_MODIFICADO_POR uniqueidentifier,
@ACT_FECHA_MODIFICACION DATETIME

AS
BEGIN
    Declare @ID uniqueidentifier,
			@FLU_ID int,
			@ORDEN int
	Select @ID = AC.ACT_ID, @FLU_ID = TR.FLU_ID, @ORDEN = AF.AFL_ORDEN
	  From ACT_ACTIVIDAD_TRAMITE_SOLIC AC With(NoLock), 
	       TRS_TRAMITE_SOLICITUD TR With(NoLock),
	       AFL_ACTIVIDAD_FLUJO AF With(NoLock)
	 Where AC.TRS_ID = TR.TRS_ID
	   AND AC.TRS_ID = @TRS_ID
	   AND AC.AFL_ID = @AFL_ID
	   AND AC.AFL_ID = AF.AFL_ID

	Update ACT_ACTIVIDAD_TRAMITE_SOLIC SET
				ACT_ESTADO = 4,
				ACT_OBSERVACION = @ACT_OBSERVACION,
				ACT_FECHA_FINALIZA = @ACT_FECHA_MODIFICACION,
				ACT_FECHA_APROBACION = @ACT_FECHA_MODIFICACION,
				ACT_APROBADO_POR = @ACT_MODIFICADO_POR
	 Where ACT_ID = @ID


	Insert into OAT_OBS_ACTIVIDAD_TRAMITE (OAT_ID, TRS_ID, ACT_ID, OAT_OBSERVACION, OAT_CREADO_POR, OAT_FECHA_CREACION)
	 Values (NEWID(), @TRS_ID, @ID, @ACT_OBSERVACION, @ACT_MODIFICADO_POR, @ACT_FECHA_MODIFICACION)


	--Lanzo la actividad siguiente 
	Set @ID = NEWID() 
	Exec CrearActividadFlujoTramite @ID, @TRS_ID, @FLU_ID, @ORDEN, 1,' ', @ID, @ID, @ACT_FECHA_MODIFICACION
	--- Retorno Datos de la Actividad Actualizada
	Select * From ACT_ACTIVIDAD_TRAMITE_SOLIC
	 Where TRS_ID = @TRS_ID
	   AND AFL_ID = @AFL_ID
END
