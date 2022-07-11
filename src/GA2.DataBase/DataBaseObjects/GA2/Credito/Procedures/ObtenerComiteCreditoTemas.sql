USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerComiteCreditoTemas]    Script Date: 6/07/2021 4:32:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerComiteCreditoTemas
Descripcion: Consulta los datos del comite de credito de los temas del orden del dia
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/
ALTER PROC [dbo].[ObtenerComiteCreditoTemas]
@COT_ID uniqueidentifier,
@COC_ID bigint,
@IND int -- Indicador de consulta 1=COT_ID  2=COC_ID

AS
Begin
	Select CO.COT_ID, CO.COC_ID, CO.TCO_ID, COT_OBSERVACION, CO.COT_ORDEN,
	       COT_CREADO_POR,COT_FECHA_CREACION, 
		   TCO.TCO_DESCRIPCION as DESCRIPCION_TEMA 
	       	  From COT_COMITE_TEMAS_TRATADOS CO With(NoLock), 
	       TCO_TEMAS_COMITE_CREDITO TCO With(NoLock)
	 Where  CO.TCO_ID = TCO.TCO_ID
	   And (
		        @IND = 1 And COT_ID = @COT_ID
		     OR @IND = 2 And COC_ID = @COC_ID
		   )
	   	Order by COT_ORDEN
End