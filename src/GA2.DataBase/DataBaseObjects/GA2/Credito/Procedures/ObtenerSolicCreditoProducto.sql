USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerSolicCreditoProducto]    Script Date: 6/07/2021 6:41:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerSolicitudCredito
Descripcion: COnsulta los datos de la solicitud de Credito de la informacion de producto
Elaboro: German Eduardo Guarnizo
Fecha: Abril 9 de 2021
*/
ALTER PROC [dbo].[ObtenerSolicCreditoProducto]
@SOP_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@IND int -- Indicaodr de consulta 1=SOP_ID 2 = SOC_ID

AS
Begin
	Select PR.*, DP.DPD_NOMBRE as DEPARTAMENTO_INMUEBLE, CI.DPC_NOMBRE as CIUDAD_INMUEBLE,
	       TV.TVV_DESCRIPCION as TIPO_VIVIENDA, TID.TID_DESCRIPCION as TIPO_DOCUMENTO_VENDEDOR
      From SOP_SOLICITUD_PRODUCTO PR With(NoLock),
	       TVV_TIPO_VIVIENDA TV With(NoLock), 
		   DPD_DEPARTAMENTO DP With(NoLock), DPC_CIUDAD CI With(NoLock) ,
		   TID_TIPO_IDENTIFICACION TID With(NoLock)
	 Where PR.DPD_ID = DP.DPD_ID
	   And PR.DPC_ID = CI.DPC_ID
	   And PR.TVV_ID = TV.TVV_ID
	   And PR.TID_ID = TID.TID_ID
	   And  (@IND = 1 And SOP_ID = @SOP_ID
	        OR   @IND = 2 And PR.SOC_ID = @SOC_ID
			)
End