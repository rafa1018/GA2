USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerComiteCredito]    Script Date: 6/07/2021 4:29:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: ObtenerComiteCredito
Descripcion: COnsulta los datos del Comite de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Abril 9 de 2021
*/
ALTER PROC [dbo].[ObtenerComiteCredito]
@COC_ID bigint=NULL,
@COC_FECHA varchar(10)=NULL,
@COC_NUMERO_COMITE bigint=NULL,
@COC_ESTADO char(1)=NULL

AS
Begin

If @COC_ID IS NULL
  SET @COC_ID=0
If @COC_FECHA IS NULL
  SET @COC_FECHA='0'
If @COC_ESTADO IS NULL
  SET @COC_ESTADO='0'
If @COC_NUMERO_COMITE IS NULL
  SET @COC_NUMERO_COMITE = 0

	Select COC_ID, COC_FECHA, COC_LUGAR, COC_HORA_INICIO, COC_HORA_FINALIZACION,
	       COC_NUMERO_COMITE, COC_DESARROLLO, COC_TEMAS_APROBACION, COC_ANOTACION,
		   COC_CARGO_ANALISTA, COC_ESTADO, COC_CREADO_POR, COC_FECHA_CREACION,
		   COC_ACTUALIZADO_POR, COC_FECHA_ACTUALIZA,
		   Case When COC_ESTADO = 'C' Then 'Creado' Else 'Aprobado' End as ESTADO
	  From COC_COMITE_CREDITO With(NoLock)
	 Where  ( @COC_ID = 0 Or COC_ID = @COC_ID )
	   And  ( @COC_FECHA = '0' Or convert(varchar(10),COC_FECHA,111) = @COC_FECHA)
	   And  ( @COC_NUMERO_COMITE = 0 Or COC_NUMERO_COMITE = @COC_NUMERO_COMITE)
	   And  ( @COC_ESTADO = '0' Or COC_ESTADO = @COC_ESTADO)
	Order by COC_ID
End