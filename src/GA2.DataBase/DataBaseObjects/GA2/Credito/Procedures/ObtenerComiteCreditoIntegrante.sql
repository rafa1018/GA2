USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerComiteCreditoIntegrante]    Script Date: 6/07/2021 4:29:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerComiteCreditoIntegrante
Descripcion: Consulta los datos del comite de credito de los integrantes
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/
ALTER PROC [dbo].[ObtenerComiteCreditoIntegrante]
@COI_ID uniqueidentifier,
@COC_ID bigint,
@IND int -- Indicador de consulta 1=CI_ID  2=COC_ID

AS
Begin
	Select COI.COI_ID, COI.COC_ID, COI.ICO_ID, COI.COI_ORDEN, COI.COI_CREADO_POR, 
	       COI.COI_FECHA_CREACION, ICO.ICO_NOMBRE as NOMBRE_INTEGRANTE, 
		   ICO.ICO_TIPO as TIPO_INTEGRANTE, ICO.ICO_CARGO as CARGO_INTEGRANTE
	  From COI_COMITE_INTEGRANTES COI With(NoLock), 
	       ICO_INTEGRANTE_COMITE_CREDITO ICO With(NoLock)
	 Where  COI.ICO_ID = ICO.ICO_ID
	   And (
		        @IND = 1 And COI_ID = @COI_ID
		     OR @IND = 2 And COC_ID = @COC_ID
		   )
	   
	Order by COI_ORDEN
End