USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearComiteCreditoTemas]    Script Date: 6/07/2021 4:28:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: CrearComiteCreditoTemas
Descripcion: Crea  el registro del Comite de Credito Temas Orden del Dia
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/
ALTER PROCEDURE [dbo].[CrearComiteCreditoTemas] 
@COT_ID uniqueidentifier,
@COC_ID bigint,
@TCO_ID int,
@COT_ORDEN int,
@COT_OBSERVACION varchar(1000),
@COT_CREADO_POR uniqueidentifier, 
@COT_FECHA_CREACION datetime

AS
BEGIN
	Declare @mIdInt bigInt
	Set @mIdInt = 0

	Select @mIdInt = COUNT(*) From COT_COMITE_TEMAS_TRATADOS 
	 Where COC_ID = @COC_ID
	   And TCO_ID = @TCO_ID

	If @mIdInt = 0
	Begin
		Insert Into COT_COMITE_TEMAS_TRATADOS (COT_ID,	COC_ID,TCO_ID,COT_ORDEN,
		                                       COT_OBSERVACION, COT_CREADO_POR, COT_FECHA_CREACION)
		Values (@COT_ID,@COC_ID,@TCO_ID,@COT_ORDEN, @COT_OBSERVACION,
			    @COT_CREADO_POR, @COT_FECHA_CREACION)		
	End
	-- Retorno los Datos de los Temas del Orden de Dia
	Select  * From COT_COMITE_TEMAS_TRATADOS
	 Where COC_ID = @COC_ID
	   And TCO_ID = @TCO_ID
END
