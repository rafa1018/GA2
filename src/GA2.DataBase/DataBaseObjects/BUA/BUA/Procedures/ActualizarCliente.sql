/*
Nombre: ActualizarCliente
Descripcion: Actualizar cliente 
Elaboro: Edgar Andrés Riaño Suárez
Fecha: Mayo 7 de 2021
*/

ALTER PROC [dbo].[ActualizarCliente](
	 @IdCliente							int
    ,@IdTipoIdentificacion				int
	,@IdTipoActor						int
    ,@Identificacion					varchar(20)
    ,@FechaExpedicionDocumento			datetime
    ,@IdDepartamentoExpedicionDocumento	int
    ,@IdCiudadExpedicionDocumento		int
    ,@LugarExpedicionExtranjero			varchar(50)
    ,@PrimerNombre						varchar(50)
    ,@SegundoNombre						varchar(50)
    ,@PrimerApellido					varchar(50)
    ,@SegundoApellido					varchar(50)
    ,@FechaNacimiento					datetime
    ,@IdPaisNacimiento					int
    ,@IdDepartamentoNacimiento			int
    ,@IdCiudadNacimiento				int
    ,@LugarNacimientoExtranjero			varchar(50)
    ,@Sexo								char(1)
    ,@EstadoCivil						char(1)
    ,@IdProfesion						int
    ,@IdUnidadEjecutora					int
    ,@IdFuerza							int
    ,@IdCategoria						int
    ,@IdGrado							int
    ,@FechaInscripcion					datetime
    ,@FechaAlta							datetime
    ,@FechaAltaCalculada				datetime
    ,@ValidacionBiometrica				bit
	,@Regimen							int
    ,@IdActividadEconomica				int
    ,@IngresoMensual					numeric(18,2)
    ,@EgresoMensual						numeric(18,2)
    ,@TotalActivos						numeric(18,2)
    ,@TotalPasivos						numeric(18,2)
    ,@TotalPatrimonio					numeric(18,2)
    ,@IngresoAdicional					numeric(18,2)
    ,@ConceptoIngresosAdicionales		varchar(255)
    ,@TransaccionesMonedaExtranjera		bit
    ,@IdMoneda							int
    ,@MontoTransaccionesExtranjero		numeric(18,2)
    ,@IdDireccion						int
    ,@IdPaisResidencia					int
    ,@IdDepartamentoResidencia			int
    ,@IdCiudadResidencia				int
    ,@CiudadResidenciaExtranjero		varchar(255)
    ,@IdTipoCalle						int
    ,@NumeroCalle1						int
    ,@IdLetra1							int
    ,@IdBis1							int
    ,@IdCardinal1						int
    ,@NumeroCalle2						int
    ,@IdLetra2							int
    ,@IdBis2							int
    ,@IdCardinal2						int
    ,@NumeroCalle3						int
    ,@IdLetra3							int
    ,@IdCardinal3						int
    ,@ComplementoDireccion				varchar(50)
    ,@Direccion							varchar(255)
    ,@Barrio							varchar(100)
    ,@IdTipoDireccion					int
    ,@Correo							varchar(255)
    ,@IdTipoCorreo						int
    ,@EnvioInformacionCorreo			bit
    ,@CorreoActivo						bit
    ,@Telefono							varchar(20)
    ,@IdTipoTelefono					int
    ,@EnvioInformacionSMS				bit
    ,@TelefonoActivo					bit
    ,@IdTipoIdentificacionConyuge		int
    ,@IdentificacionConyuge				varchar(20)
    ,@PrimerNombreConyuge				varchar(50)
    ,@SegundoNombreConyuge				varchar(50)
    ,@PrimerApellidoConyuge				varchar(50)
    ,@SegundoApellidoConyuge			varchar(50)
    ,@ConyugeActivo						bit
)
AS
BEGIN
	UPDATE CLI_CLIENTE
	SET	TID_ID 								= @IdTipoIdentificacion		
		,TPA_ID								= @IdTipoActor
		,CLI_IDENTIFICACION 				= @Identificacion				
		,CLI_FECHA_EXPEDICION  				= @FechaExpedicionDocumento		
		,DPC_ID_IDENTIFICACION_EXPEDIDA 	= @IdCiudadExpedicionDocumento	
		,DPD_ID_IDENTIFICACION_EXPEDIDA 	= @IdDepartamentoExpedicionDocumento	
		,CLI_LUGAR_EXPEDICION 				= @LugarExpedicionExtranjero		
		,CLI_PRIMER_NOMBRE 					= @PrimerNombre					
		,CLI_SEGUNDO_NOMBRE 				= @SegundoNombre					
		,CLI_PRIMER_APELLIDO				= @PrimerApellido				
		,CLI_SEGUNDO_APELLIDO 				= @SegundoApellido				
		,CLI_FECHA_NACIMIENTO  				= @FechaNacimiento				
		,DPP_ID_PAIS_NACIMIENTO 			= @IdPaisNacimiento				
		,DPD_ID 							= @IdDepartamentoNacimiento		
		,DPC_ID								= @IdCiudadNacimiento			
		,CLI_LUGAR_NACIMIENTO				= @LugarNacimientoExtranjero		
		,CAT_SEXO							= @Sexo							
		,CAT_ESTADO_CIVIL					= @EstadoCivil					
		,CLI_PROFESION						= @IdProfesion					
		,UEJ_ID								= @IdUnidadEjecutora						
		,FRZ_ID								= @IdFuerza						
		,CTG_ID								= @IdCategoria						
		,GRD_ID								= @IdGrado						
		,CLI_FECHA_INSCRIPCION				= @FechaInscripcion				
		,CLI_FECHA_ALTA						= @FechaAlta						
		,CTS_SLP							= @FechaAltaCalculada			
		,CLI_VALIDACION_BIOMETRICA			= @ValidacionBiometrica
		,CLI_REGIMEN						= @Regimen
	WHERE CLI_ID = @IdCliente	
	
	UPDATE CLI_CLIENTE_INFO_ECONOMICA
	SET ACC_ID								= @IdActividadEconomica					
		,CIE_INGRESO_MENSUAL				= @IngresoMensual				
		,CIE_EGRESO_MENSUAL					= @EgresoMensual					
		,CIE_TOTAL_ACTIVOS					= @TotalActivos					
		,CIE_TOTAL_PASIVOS					= @TotalPasivos					
		,CIE_TOTAL_PATRIMONIO				= @TotalPatrimonio				
		,CIE_INGRESO_ADICIONAL				= @IngresoAdicional				
		,CIE_CONCEPTO_INGRESO_ADICIONAL		= @ConceptoIngresosAdicionales	
		,CIE_TRANS_EXTRANJERO				= @TransaccionesMonedaExtranjera 
		,MND_ID								= @IdMoneda						
		,CIE_VALOR_TRANSFERENCIA			= @MontoTransaccionesExtranjero	
	WHERE CLI_ID = @IdCliente

	UPDATE DRC_DIRECCION_CLIENTE
	SET DPP_ID_RESIDENCIA					= @IdPaisResidencia					
		,DPD_ID_RESIDENCIA					= @IdDepartamentoResidencia		
		,DPC_ID_RESIDENCIA					= @IdCiudadResidencia			
		,DRC_CIUDAD_RESIDENCIA_EXTRANJERO	= @CiudadResidenciaExtranjero	
		,TPC_TIPO_CALLE						= @IdTipoCalle					
		,DRC_NUMERO_1						= @NumeroCalle1					
		,LTR_LETRA_1						= @IdLetra1						
		,BS_BIS_1							= @IdBis1						
		,CRD_CARDINAL_1						= @IdCardinal1					
		,DRC_NUMERO_2						= @NumeroCalle2					
		,LTR_LETRA_2						= @IdLetra2						
		,BS_BIS_2							= @IdBis2						
		,CRD_CARDINAL_2						= @IdCardinal2					
		,DRC_NUMERO_3						= @NumeroCalle3					
		,LTR_LETRA_3						= @IdLetra3						
		,CRD_CARDINAL_3						= @IdCardinal3					
		,DRC_COMPLEMENTO_DIRECCION			= @ComplementoDireccion			
		,DRC_DIRECCION						= @Direccion						
		,DRC_BARRIO							= @Barrio						
		,TPD_ID								= @IdTipoDireccion				
	WHERE CLI_ID = @IdCliente

	UPDATE DRC_DIRECCION_CORREO
	SET DCE_CORREO							= @Correo						
		,TCE_ID								= @IdTipoCorreo					
		,DCE_ENVIO_INFORMACION				= @EnvioInformacionCorreo		
		,DCE_ACTIVO							= @CorreoActivo					
	WHERE DRC_ID = @IdDireccion

	UPDATE DRC_DIRECCION_TELEFONO			
	SET DTL_TELEFONO						= @Telefono						
		,TPT_ID								= @IdTipoTelefono				
		,DTL_ACTIVO							= @EnvioInformacionSMS			
		,DTL_ENVIO_INFORMACION				= @TelefonoActivo				
	WHERE DRC_ID = @IdDireccion

	IF ((SELECT COUNT(*) FROM CNY_CONYUGE_CLIENTE WHERE CLI_ID = @IdCliente) > 0)
	BEGIN
		UPDATE CNY_CONYUGE_CLIENTE
		SET CNY_TID_ID							= @IdTipoIdentificacionConyuge	
			,CNY_IDENTIFICACION					= @IdentificacionConyuge			
			,CNY_PRIMER_NOMBRE					= @PrimerNombreConyuge			
			,CNY_SEGUNDO_NOMBRE					= @SegundoNombreConyuge			
			,CNY_PRIMER_APELLIDO				= @PrimerApellidoConyuge			
			,CNY_SEGUNDO_APELLIDO				= @SegundoApellidoConyuge		
			,CNY_ACTIVO							= @ConyugeActivo					
		WHERE CLI_ID = @IdCliente
	END
	ELSE
	BEGIN
		INSERT INTO CNY_CONYUGE_CLIENTE
		VALUES (@IdCliente
				,@IdTipoIdentificacionConyuge
				,@IdentificacionConyuge		
				,@PrimerNombreConyuge			
				,@SegundoNombreConyuge			
				,@PrimerApellidoConyuge		
				,@SegundoApellidoConyuge		
				,@ConyugeActivo)				
	END

	EXEC ObtenerClientePorTipoIdentificationYNumero @IdTipoIdentificacion, @Identificacion	
END

