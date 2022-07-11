/*
Nombre: RestaurarIntegracionCliente
Descripcion: Restaurar informacion cliente 
Elaboro: Edgar Andrés Riaño Suárez
Fecha: Mayo 7 de 2021
*/

ALTER PROC [dbo].[RestaurarIntegracionCliente](
	@IdCliente							int
    ,@IdTipoIdentificacion				int
	,@IdTipoActor						int
    ,@Identificacion					varchar(20)
    ,@FechaExpedicionDocumento			datetime
    ,@IdDepartamentoExpedicionDocumento	int
    ,@IdCiudadExpedicionDocumento		int
    ,@PrimerNombre						varchar(50)
    ,@SegundoNombre						varchar(50)
    ,@PrimerApellido					varchar(50)
    ,@SegundoApellido					varchar(50)
    ,@FechaNacimiento					datetime
    ,@IdPaisNacimiento					int
    ,@IdDepartamentoNacimiento			int
    ,@IdCiudadNacimiento				int
    ,@Sexo								char(1)
    ,@EstadoCivil						char(1)
    ,@IdProfesion						int
    ,@Unidad							varchar(15)
    ,@IdFuerza							int
    ,@IdGrado							int
    ,@IdCategoria						int
    ,@IdUnidadEjecutora					int
    ,@FechaInscripcion					datetime
    ,@FechaAlta							datetime
    ,@FechaAltaCalculada				datetime
	,@ValidacionBiometrica				bit
	,@Regimen							int
	,@IdInformacionEconomica			int
	,@IdActividadEconomica				int
    ,@IngresoMensual					numeric(18,2)
    ,@EgresoMensual						numeric(18,2)
    ,@TotalActivos						numeric(18,2)
    ,@TotalPasivos						numeric(18,2)
    ,@TotalPatrimonio					numeric(18,2)
    ,@IngresoAdicional					numeric(18,2)
    ,@ConceptoIngresosAdicionales		varchar(255)
    ,@IdDireccion						int
    ,@IdPaisResidencia					int
    ,@IdDepartamentoResidencia			int
    ,@IdCiudadResidencia				int
    ,@Direccion							varchar(255)
    ,@Barrio							varchar(100)
    ,@Correo							varchar(255)
    ,@IdTipoCorreo						int
    ,@Telefono							varchar(20)
    ,@IdTipoTelefono					int
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
	DECLARE @CLI_ID INT = (select CLI_ID from CLI_CLIENTE where CLI_IDENTIFICACION = @Identificacion)
	DECLARE @DRC_ID INT = (select DRC_ID from DRC_DIRECCION_CLIENTE where CLI_ID = @CLI_ID)
	
	delete from CLI_CLIENTE where CLI_ID = @CLI_ID
	delete from CLI_CLIENTE_INFO_ECONOMICA WHERE CLI_ID = @CLI_ID
	delete from DRC_DIRECCION_CLIENTE WHERE CLI_ID = @CLI_ID
	delete FROM DRC_DIRECCION_CORREO WHERE DRC_ID = @DRC_ID
	delete FROM DRC_DIRECCION_TELEFONO WHERE DRC_ID = @DRC_ID
	delete FROM DPT_DEPENDIENTE WHERE CLI_ID = @CLI_ID
	delete FROM CNY_CONYUGE_CLIENTE WHERE CLI_ID = @CLI_ID
	delete from CTA_CUENTA WHERE CLI_ID = @CLI_ID
	delete from MVT_MOVIMIENTO WHERE CTA_ID in (select CTA_ID_INTEGRACION from CTA_CUENTA where CLI_ID = @CLI_ID)
	delete from APC_APORTES_CATEGORIA_CLIENTE WHERE CLI_ID = @CLI_ID

	INSERT INTO CLI_CLIENTE(
		TID_ID,
		TPA_ID,
		CLI_IDENTIFICACION,
		CLI_FECHA_EXPEDICION,
		DPD_ID_IDENTIFICACION_EXPEDIDA,
		DPC_ID_IDENTIFICACION_EXPEDIDA,
		CLI_PRIMER_NOMBRE,
		CLI_SEGUNDO_NOMBRE,
		CLI_PRIMER_APELLIDO,
		CLI_SEGUNDO_APELLIDO,
		CLI_FECHA_NACIMIENTO,
		DPP_ID_PAIS_NACIMIENTO,
		DPD_ID,
		DPC_ID,
		CAT_SEXO,
		CAT_ESTADO_CIVIL,
		CLI_PROFESION,
		CLI_UNIDAD,
		FRZ_ID,
		GRD_ID,
		CTG_ID,
		UEJ_ID,
		CLI_FECHA_INSCRIPCION,
		CLI_FECHA_ALTA,
		CTS_SLP,
		CLI_VALIDACION_BIOMETRICA,
		CLI_REGIMEN
	) VALUES (
		@IdTipoIdentificacion	
		,@IdTipoActor
		,@Identificacion				
		,@FechaExpedicionDocumento		
		,@IdDepartamentoExpedicionDocumento	
		,@IdCiudadExpedicionDocumento	
		,@PrimerNombre					
		,@SegundoNombre					
		,@PrimerApellido				
		,@SegundoApellido				
		,@FechaNacimiento				
		,@IdPaisNacimiento				
		,@IdDepartamentoNacimiento		
		,@IdCiudadNacimiento			
		,@Sexo							
		,@EstadoCivil					
		,@IdProfesion					
		,@Unidad						
		,@IdFuerza						
		,@IdGrado						
		,@IdCategoria						
		,@IdUnidadEjecutora						
		,@FechaInscripcion				
		,@FechaAlta		
		,@FechaAltaCalculada
		,@ValidacionBiometrica
		,@Regimen
	)

	DECLARE @CLIENTE_ID int = (SELECT TOP 1 CLI_ID FROM CLI_CLIENTE ORDER BY CLI_ID DESC)

	INSERT INTO CLI_CLIENTE_INFO_ECONOMICA (
		ACC_ID,
		CIE_INGRESO_MENSUAL,
		CIE_EGRESO_MENSUAL, 
		CIE_TOTAL_ACTIVOS,
		CIE_TOTAL_PASIVOS,
		CIE_TOTAL_PATRIMONIO,
		CIE_INGRESO_ADICIONAL,
		CIE_CONCEPTO_INGRESO_ADICIONAL,
		CLI_ID
	) VALUES (
		@IdActividadEconomica,
		@IngresoMensual,			
		@EgresoMensual,				
		@TotalActivos,				
		@TotalPasivos,				
		@TotalPatrimonio,			
		@IngresoAdicional,			
		@ConceptoIngresosAdicionales,
		@CLIENTE_ID
	)

	INSERT INTO DRC_DIRECCION_CLIENTE (	
		DPP_ID_RESIDENCIA,
		DPD_ID_RESIDENCIA,
		DPC_ID_RESIDENCIA,
		DRC_DIRECCION,
		DRC_BARRIO,
		CLI_ID
	) VALUES (
		@IdPaisResidencia			
		,@IdDepartamentoResidencia	
		,@IdCiudadResidencia		
		,@Direccion					
		,@Barrio
		,@CLIENTE_ID
	)

	DECLARE @DIRECCION_ID INT = (SELECT TOP 1 DRC_ID FROM DRC_DIRECCION_CLIENTE ORDER BY DRC_ID DESC)

	INSERT INTO DRC_DIRECCION_CORREO (
		DCE_CORREO,
		DRC_ID,
		TCE_ID
	) VALUES (
		@Correo,
		@DIRECCION_ID,
		@IdTipoCorreo
	)

	INSERT INTO DRC_DIRECCION_TELEFONO (
		DTL_TELEFONO,
		DRC_ID,
		TPT_ID
	) VALUES (
		@Telefono,
		@DIRECCION_ID,
		@IdTipoTelefono
	)

	INSERT INTO CNY_CONYUGE_CLIENTE(
		CNY_TID_ID
		,CNY_IDENTIFICACION
		,CNY_PRIMER_NOMBRE
		,CNY_SEGUNDO_NOMBRE
		,CNY_PRIMER_APELLIDO
		,CNY_SEGUNDO_APELLIDO
		,CNY_ACTIVO
		,CLI_ID
	) VALUES (
		@IdTipoIdentificacionConyuge	
		,@IdentificacionConyuge			
		,@PrimerNombreConyuge			
		,@SegundoNombreConyuge			
		,@PrimerApellidoConyuge			
		,@SegundoApellidoConyuge		
		,@ConyugeActivo	
		,@CLIENTE_ID
	)

	EXEC ObtenerClientePorTipoIdentificationYNumero @IdTipoIdentificacion, @Identificacion	
END

