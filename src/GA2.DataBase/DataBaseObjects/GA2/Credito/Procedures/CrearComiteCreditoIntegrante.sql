USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearComiteCreditoIntegrante]    Script Date: 6/07/2021 4:25:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: CrearComiteCreditoIntegrante
Descripcion: Crea  el registro del Comite de Credito Integrante
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/
ALTER PROCEDURE [dbo].[CrearComiteCreditoIntegrante] 
@COI_ID uniqueidentifier,
@COC_ID bigint,
@ICO_ID int,
@COI_ORDEN int,
@COI_CREADO_POR uniqueidentifier, 
@COI_FECHA_CREACION datetime

AS
BEGIN
	Declare @mIdInt bigInt
	Set @mIdInt = 0

	Select @mIdInt = COUNT(*) From COI_COMITE_INTEGRANTES 
	 Where COC_ID = @COC_ID
	   And ICO_ID = @ICO_ID

	If @mIdInt = 0
	Begin
		Insert Into COI_COMITE_INTEGRANTES (COI_ID,	COC_ID,ICO_ID,COI_ORDEN,
		                                    COI_CREADO_POR, COI_FECHA_CREACION)
		Values (@COI_ID,@COC_ID,@ICO_ID,@COI_ORDEN,
			    @COI_CREADO_POR, @COI_FECHA_CREACION)		
	End
	-- Retorno los Datos del Integrante
	Select  * From COI_COMITE_INTEGRANTES
	 Where COC_ID = @COC_ID
	   And ICO_ID = @ICO_ID
END
