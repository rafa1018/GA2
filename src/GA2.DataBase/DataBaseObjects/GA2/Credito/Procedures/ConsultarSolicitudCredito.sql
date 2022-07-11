USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarSolicitudCredito]    Script Date: 6/07/2021 4:59:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ConsultarSolicitudCredito
Descripcion: COnsulta la Información de la Solicitud de Credito del Cliente
Elaboro: German Eduardo Guarnizo
Fecha: Abril 21 de 2021
*/
ALTER PROCEDURE [dbo].[ConsultarSolicitudCredito] 
@SOC_ID uniqueidentifier=null,
@NUMERO_DOCUMENTO varchar(20)='0',
@ESTADO char(1)='0'

AS
BEGIN
    --Select @SOC_ID
	Select SOC.*, 
	Case When SOC_CONVENIO_ASEGURADORA = 'S' Then 'SI' Else 'NO' End as CONVENIO_VIDA,
	Case When SOC_CONVENIO_ASEGURADORA_HOGAR = 'S' Then 'SI' Else 'NO' End as CONVENIO_HOGAR,
	Case When ASE.ASE_ID IS NOT NULL Then ASE.ASE_RAZON_SOCIAL ELSE ' ' End as ASEGURADORA
	  From SOC_SOLICITUD_CREDITO SOC With(NoLock)
	              LEFT JOIN ASE_ASEGURADORAS ASE With(NoLock) On ASE.ASE_ID=SOC.ASE_ID, 
	       TCR_TIPO_CREDITO TC With(NoLock)
	 Where SOC.TCR_ID = TC.TCR_ID 
	   AND SOC.SOC_NUMERO_SOLICITUD!=0
	   --AND (@SOC_ID = NULL Or SOC_ID = @SOC_ID)
	   AND (@NUMERO_DOCUMENTO='0' Or SOC.CLI_IDENTIFICACION = @NUMERO_DOCUMENTO)
	   AND (@ESTADO = '0' Or SOC.SOC_ESTADO = @ESTADO)
	Order by SOC.SOC_NUMERO_SOLICITUD
END
