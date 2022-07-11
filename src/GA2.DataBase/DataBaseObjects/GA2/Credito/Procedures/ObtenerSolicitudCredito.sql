/*
Nombre: ObtenerSolicitudCredito
Descripcion: COnsulta los datos de la solicitud de Credito de la informacion de producto
Elaboro: German Eduardo Guarnizo
Fecha: Abril 9 de 2021
*/
CREATE PROC[dbo].[ObtenerSolicCreditoProducto]
@SOP_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicaodr de consulta 1=SOP_ID 2 = SOC_ID

AS
Begin
	Select PR.*, DP.DPD_NOMBRE as DEPARTAMENTO_INMUEBLE, CI.DPC_NOMBRE as CIUDAD_INMUEBLE,
		  TV.TVV_DESCRIPCION as TIPO_VIVIENDA
	  From SOP_SOLICITUD_PRODUCTO PR With(NoLock), TVV_TIPO_VIVIENDA TV With(NoLock), 
			DPD_DEPARTAMENTO DP With(NoLock), DPC_CIUDAD CI With(NoLock) 
	 Where PR.DPD_ID = DP.DPD_ID
	   And PR.DPC_ID = CI.DPC_ID
	   And PR.TVV_ID = TV.TVV_ID
	   And  (@IND = 1 And SOP_ID = @SOP_ID

			OR @IND = 2 And SOC_ID = @SOC_ID
			)
End