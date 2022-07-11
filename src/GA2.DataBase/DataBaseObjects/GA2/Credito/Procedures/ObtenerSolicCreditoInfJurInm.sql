/*
Nombre: ObtenerSolicCreditoInfJurInm
Descripcion: Consulta los datos de la solicitud de Credito de la informacion Juridica (Abogado) Inmueble
Elaboro: German Eduardo Guarnizo
Fecha: Abril 30 de 2021
*/
Create PROC[dbo].[ObtenerSolicCreditoInfJurInm]
@SJI_ID uniqueidentifier,
@SIJ_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicador de consulta 1=STI_ID  2=SIT_ID  3 = SOC_ID 

AS
Begin
	Select * From SJI_SOLICITUD_INF_JUR_INM
	 Where  (@IND = 1 And SIJ_ID = @SIJ_ID)
	   OR(@IND = 2 And SJI_ID = @SJI_ID)
	   OR(@IND = 3 And SOC_ID = @SOC_ID)
	Order by SJI_ID
End