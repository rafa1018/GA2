USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearComiteCreditoSolicitud]    Script Date: 6/07/2021 4:26:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: CrearComiteCreditoSolicitud
Descripcion: Crea  el registro del Comite de Credito Solicitudes
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 24 de 2021
*/
ALTER PROCEDURE [dbo].[CrearComiteCreditoSolicitud] 
@COS_ID uniqueidentifier,
@SOC_ID uniqueidentifier,
@COC_ID bigint,
@COS_RESULTADO varchar(1000),
@COS_APROBADA varchar(1),
@COS_VALOR_CREDITO float=0,
@COS_PLAZO_CREDITO int=0,
@COS_TEA_CREDITO decimal(6,3)=0,
@COS_RECHAZADA varchar(1),
@COS_CREADO_POR uniqueidentifier, 
@COS_FECHA_CREACION datetime

AS
BEGIN
	Declare @mIdInt bigInt
	Set @mIdInt = 0

	if  @COS_ID  = '00000000-0000-0000-0000-000000000000'
	  SET @COS_ID = NEWID()

	Select @mIdInt = COUNT(*) From COS_COMITE_SOLICITUD_CREDITO 
	 Where COC_ID = @COC_ID
	   And SOC_ID = @SOC_ID

	If @mIdInt = 0
	Begin
		Insert Into COS_COMITE_SOLICITUD_CREDITO (COS_ID, SOC_ID, COC_ID, COS_RESULTADO,
		                                          COS_APROBADA, COS_RECHAZADA, 
												  COS_VALOR_CREDITO, COS_PLAZO_CREDITO,  COS_TEA_CREDITO,
												  COS_CREADO_POR, COS_FECHA_CREACION)
		Values (@COS_ID, @SOC_ID, @COC_ID, @COS_RESULTADO,
                @COS_APROBADA, @COS_RECHAZADA, 
				@COS_VALOR_CREDITO, @COS_PLAZO_CREDITO,  @COS_TEA_CREDITO,
				@COS_CREADO_POR, @COS_FECHA_CREACION)		
	End
	Else
	Begin
		Update COS_COMITE_SOLICITUD_CREDITO Set COS_RESULTADO = @COS_RESULTADO,
												COS_APROBADA = @COS_APROBADA,
												COS_RECHAZADA = @COS_RECHAZADA,
												COS_VALOR_CREDITO=@COS_VALOR_CREDITO, 
												COS_PLAZO_CREDITO=@COS_PLAZO_CREDITO,  
												COS_TEA_CREDITO=@COS_TEA_CREDITO,
												COS_ACTUALIZADO_POR = @COS_CREADO_POR,
												COS_FECHA_ACTUALIZACION = @COS_FECHA_CREACION
	     Where COC_ID = @COC_ID
	       And SOC_ID = @SOC_ID
	End

	-- Retorno los Datos de los Temas del Orden de Dia
	Select  * From COS_COMITE_SOLICITUD_CREDITO
	Where COC_ID = @COC_ID
	  And SOC_ID = @SOC_ID

END
