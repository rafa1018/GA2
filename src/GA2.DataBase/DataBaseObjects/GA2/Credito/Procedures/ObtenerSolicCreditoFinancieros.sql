/*
Nombre: ObtenerSolicCreditoFinancieros
Descripcion: COnsulta los datos de la solicitud de Credito de la informacion Financiera
Elaboro: German Eduardo Guarnizo
Fecha: Abril 12 de 2021
*/
Create PROC[dbo].[ObtenerSolicCreditoFinancieros]
@SOF_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicador de consulta 1=SOF_ID 2 = SOC_ID

AS
Begin
	Select * From SOF_SOLICITUD_INF_FINANCIERA
	 Where  (@IND = 1 And SOF_ID = @SOF_ID)
	   OR(@IND = 2 And SOC_ID = @SOC_ID)
End