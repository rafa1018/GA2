
/*
Nombre: ObtenerDocumentosFlujo
Descripcion: Consulta los documentos requeridos por cada actividad del flujo
Elaboro: German Eduardo Guarnizo
Fecha: Abril 20 de 2021
*/
CREATE PROC [dbo].[ObtenerDocumentosFlujo]
@TCR_ID int=0,
@ORDEN int=0,
@PRINCIPAL char(1)='S'

AS
Begin
	Select FL.TCR_ID, FL.FLU_ID, AF.AFL_ID, DA.DCA_ID, TD.TDC_ID, TD.TDC_DESCRIPCION, DA.DCA_OBLIGATORIO, DA.DCA_ORDEN
	  From FTC_FLUJO_TIPO_CREDITO FL, AFL_ACTIVIDAD_FLUJO AF, DCA_DOCUMENTO_ACTIVIDAD DA,
	       TDC_TIPO_DOCUMENTO TD
	Where FL.TCR_ID = @TCR_ID
	  AND FL.FLU_ID = AF.FLU_ID
	  AND AF.AFL_ID = DA.AFL_ID
	  AND AF.AFL_ORDEN = @ORDEN
	  AND AF.AFL_ACTIVIDAD_PRINCIPAL = @PRINCIPAL
	  AND DA.TDC_ID = TD.TDC_ID
	  AND DA.DCA_ESTADO = 1
	  AND DA.DCA_CARGA='S'
    Order by DA.DCA_ORDEN 
End
