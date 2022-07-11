
/*
Nombre: ObtenerObservacíonTramite
Descripcion: Consulta las observaciones de la solicitud
Elaboro: German Eduardo Guarnizo
Fecha: Abril 28 de 2021
*/
CREATE PROC [dbo].[ObtenerObservacíonTramite]
@TRS_ID uniqueidentifier,
@ACT_ID uniqueidentifier,
@IND int=1  -- 1 = Filtro por TRS_ID  2 = FIltro por ACT_ID

AS
Begin
	Select OBS.TRS_ID as ID_TRAMITE, OBS.ACT_ID as ID_ACTIVIDAD_TRAMITE, 
	      AF.AFL_ID as ID_ACTIVIDAD, TA.TAC_DESCRIPCION as ACTIVIDAD,
		  OBS.OAT_OBSERVACION as OBSERVACION, OBS.OAT_FECHA_CREACION as FECHA_INGRESO
	 From OAT_OBS_ACTIVIDAD_TRAMITE OBS With(NoLock), 
		  ACT_ACTIVIDAD_TRAMITE_SOLIC AC With(NoLock), 
		  AFL_ACTIVIDAD_FLUJO AF With(NoLock), TAC_TIPO_ACTIVIDAD TA With(NoLock)
    Where OBS.ACT_ID = AC.ACT_ID
	  AND AC.AFL_ID = AF.AFL_ID
	  AND AF.TAC_ID = TA.TAC_ID
	  AND (
		      @IND = 1 And OBS.TRS_ID = @TRS_ID
		   Or @IND = 2 And OBS.ACT_ID = @ACT_ID
	  )
	Order by OBS.OAT_FECHA_CREACION
End
