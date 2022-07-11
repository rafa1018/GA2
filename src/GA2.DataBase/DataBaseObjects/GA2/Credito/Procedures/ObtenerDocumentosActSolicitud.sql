
/*
Nombre: ObtenerDocumentosActSolicitud
Descripcion: Consulta los documentos a visualizar en la actuvudad del Flujo
Elaboro: German Eduardo Guarnizo
Fecha: Abril 27 de 2021
*/
CREATE PROC [dbo].[ObtenerDocumentosActSolicitud]
@SOC_ID uniqueidentifier,
@TCR_ID int=0,
@AFL_ID int=0

AS
Begin
	Select AF.AFL_ID as ID_ACTIVIDAD_FLUJO, TA.TAC_DESCRIPCION as ACTIVIDAD, 
	       TD.TDC_DESCRIPCION as TIPO_DOCUMENTO, DS.DCS_RUTA_IMAGEN as RUTA_IMAGEN
	  From FTC_FLUJO_TIPO_CREDITO FL With(NoLock), 
	       AFL_ACTIVIDAD_FLUJO AF With(NoLock), 
	       DCA_DOCUMENTO_ACTIVIDAD DA With(NoLock),
	       TDC_TIPO_DOCUMENTO TD With(NoLock), 
		   DCS_DOCUMENTO_SOLIC_CREDITO DS With(NoLock),
		   TAC_TIPO_ACTIVIDAD TA With(NoLock)
	Where FL.TCR_ID = @TCR_ID
	  AND FL.FLU_ID = AF.FLU_ID
	  AND AF.AFL_ID = DA.AFL_ID
	  AND AF.AFL_ID = @AFL_ID
	  AND DA.TDC_ID = TD.TDC_ID
	  AND DA.DCA_ESTADO = 1
	  AND DA.DCA_VISUALIZA='S'
	  AND TD.TDC_ID=DS.TDC_ID
	  AND DS.SOC_ID = @SOC_ID
	  AND AF.TAC_ID = TA.TAC_ID
    Order by DA.DCA_ORDEN 
End
