USE [GA2]
GO
/****** Object:  StoredProcedure [dbo].[CrearComiteCredito]    Script Date: 6/07/2021 4:24:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Nombre: CrearComiteCredito
Descripcion: Crea y actualiza el registro del Comite de Credito
Elaboro: German Eduardo Guarnizo
Fecha: Mayo 19 de 2021
*/
ALTER PROCEDURE [dbo].[CrearComiteCredito] 
@COC_ID bigint=0,
@COC_FECHA date,
@COC_LUGAR varchar(100), 
@COC_HORA_INICIO varchar(5),  
@COC_HORA_FINALIZACION varchar(5),  
@COC_DESARROLLO varchar(500), 
@COC_TEMAS_APROBACION varchar(1000), 
@COC_ANOTACION varchar(1000), 
@COC_CARGO_ANALISTA varchar(100),  
@COC_CREADO_POR uniqueidentifier, 
@COC_FECHA_CREACION datetime

AS
BEGIN
	Declare @mIdComite bigInt
	Set @mIdComite = 0

	Select @mIdComite = COUNT(*) From COC_COMITE_CREDITO Where COC_ID = @COC_ID

	If @mIdComite = 0
	Begin
		Declare @mConsecutivo bigint 
		Declare @Error int
		Set @mConsecutivo = 0
		Set @Error = 0

		SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
		BEGIN TRANSACTION oTrans

		-- Obtengo el consecutivo del preaprobado
		Update CNS_CONSECUTIVO SET CNS_ULTIMO_NUMERO = CNS_ULTIMO_NUMERO + 1,
								   @mConsecutivo = CNS_ULTIMO_NUMERO + 1
		Where CNS_ID = 'CC'

		IF @@ERROR <> 0 
		BEGIN
			SET @Error = 1
			goto Error
		END

		--- Creo el COmite
		Insert into COC_COMITE_CREDITO (COC_FECHA, COC_LUGAR, COC_HORA_INICIO, COC_HORA_FINALIZACION,
										COC_NUMERO_COMITE, COC_DESARROLLO, COC_TEMAS_APROBACION, COC_ANOTACION,
										COC_CARGO_ANALISTA, COC_ESTADO, COC_CREADO_POR, COC_FECHA_CREACION
									   )
		Values (@COC_FECHA, @COC_LUGAR, @COC_HORA_INICIO, @COC_HORA_FINALIZACION,
			    @mConsecutivo, @COC_DESARROLLO, @COC_TEMAS_APROBACION, @COC_ANOTACION,
		        @COC_CARGO_ANALISTA, 'C', @COC_CREADO_POR, @COC_FECHA_CREACION)
	
		IF @@ERROR <> 0 
		BEGIN
			SET @Error = 1
			goto Error
		END

		Select @COC_ID = MAX(COC_ID) From COC_COMITE_CREDITO
		Where COC_CREADO_POR = @COC_CREADO_POR 

		IF @@ERROR <> 0 
		BEGIN
			SET @Error = 1
			goto Error
		END

		Error:
		  IF @Error = 0 
			begin
				COMMIT TRANSACTION

				-- Retorno los Datos del Comite
				Select  * From COC_COMITE_CREDITO
				 Where COC_ID = @COC_ID
			end
			ELSE
			begin
				ROLLBACK TRANSACTION 

				-- Retorno los Datos del Comite
				Select  * From COC_COMITE_CREDITO
				 Where COC_ID = @COC_ID
			End
	End
	Else
	Begin
		Update COC_COMITE_CREDITO Set COC_LUGAR=@COC_LUGAR,
									  COC_HORA_INICIO=@COC_HORA_INICIO,
									  COC_HORA_FINALIZACION=@COC_HORA_FINALIZACION,
									  COC_DESARROLLO=@COC_DESARROLLO,
									  COC_TEMAS_APROBACION=@COC_TEMAS_APROBACION,
									  COC_ANOTACION=@COC_ANOTACION,
									  COC_CARGO_ANALISTA=@COC_CARGO_ANALISTA,
									  COC_ACTUALIZADO_POR=@COC_CREADO_POR,
									  COC_FECHA_ACTUALIZA = @COC_FECHA_CREACION
        Where COC_ID = @COC_ID

		-- Elimino los detalles de Asistentes y Temas
		Delete From COI_COMITE_INTEGRANTES Where COC_ID = @COC_ID
		Delete From COT_COMITE_TEMAS_TRATADOS Where COC_ID = @COC_ID
		-- Retorno los Datos del Comite
		Select  * From COC_COMITE_CREDITO
		 Where COC_ID = @COC_ID

	End
END
