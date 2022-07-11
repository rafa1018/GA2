/*
Nombre: ObtenerSolicCreditoReferencias
Descripcion: Consulta los datos de la solicitud de Credito de la informacion Tecnica (Avaluo)
Elaboro: German Eduardo Guarnizo
Fecha: Abril 30 de 2021
*/
CREATE PROC[dbo].[ObtenerSolicCreditoInfTecnica]
@SIT_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicador de consulta 1=SIT_ID 2 = SOC_ID

AS
Begin
	Select IT.*, USR.USR_USERNAME as NOMBRE_ALIADO From SIT_SOLICITUD_INF_TECNICA IT, USR_USERS USR
	 Where IT.SIT_CREADO_POR = USR.USR_ID 
	  And (
	          @IND = 1 And IT.SIT_ID = @SIT_ID
  	       OR   @IND = 2 And IT.SOC_ID = @SOC_ID
	      )
End