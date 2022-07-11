/*
Nombre: ObtenerSolicCreditoInfJuridica
Descripcion: Consulta los datos de la solicitud de Credito de la informacion Juridca (Abogado)
Elaboro: German Eduardo Guarnizo
Fecha: Abril 30 de 2021
*/
CREATE PROC[dbo].[ObtenerSolicCreditoInfJuridica]
@SIJ_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicador de consulta 1=SIJ_ID 2 = SOC_ID

AS
Begin
	Select  JR.*, USR.USR_USERNAME as NOMBRE_ALIADO  
	  From SIJ_SOLICITUD_INF_JURIDICA JR, USR_USERS USR
	 Where JR.SIJ_CREADO_POR = USR.USR_ID
	   And (  @IND = 1 And SIJ_ID = @SIJ_ID
	        OR   @IND = 2 And SOC_ID = @SOC_ID
	       )
End