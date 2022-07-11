/*
Nombre: ObtenerSolicCreditoInfTecInm
Descripcion: Consulta los datos de la solicitud de Credito de la informacion Tecnica (Avaluo) Inmueble
Elaboro: German Eduardo Guarnizo
Fecha: Abril 30 de 2021
*/
Create PROC[dbo].[ObtenerSolicCreditoInfTecInm]
@STI_ID uniqueidentifier,
@SIT_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicador de consulta 1=STI_ID  2=SIT_ID  3 = SOC_ID 

AS
Begin
	Select * From STI_SOLICITUD_INF_TEC_INM
	 Where  (@IND = 1 And STI_ID = @STI_ID)
	   OR(@IND = 2 And SIT_ID = @SIT_ID)
	   OR(@IND = 3 And SOC_ID = @SOC_ID)
	Order by STI_ID
End