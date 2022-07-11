using System.ComponentModel;

namespace GA2.Infraestructure.Data
{

    /// <summary>
    /// Enum parametros Users
    /// <author>ONicolas Florez Sarraola</author>
    /// <date>12/03/2021</date>
    /// </summary>
    public enum EnumClientParameters
    {
        [Description("@IdCliente")]
        CLI_ID,
        [Description("@IdTipoActor")]
        TPA_ID,
        [Description("@IdTipoIdentificacion")]
        TID_ID,
        [Description("@Identificacion")]
        CLI_IDENTIFICACION,
        [Description("@FechaExpedicionDocumento")]
        CLI_FECHA_EXPEDICION,
        [Description("@IdPaisExpedicionDocumento")]
        DPP_ID_IDENTIFICACION_EXPEDIDA,
        [Description("@IdDepartamentoExpedicionDocumento")]
        DPD_ID_IDENTIFICACION_EXPEDIDA,
        [Description("@IdCiudadExpedicionDocumento")]
        DPC_ID_IDENTIFICACION_EXPEDIDA,
        [Description("@LugarExpedicionExtranjero")]
        CLI_LUGAR_EXPEDICION,
        [Description("@CodigoMilitar")]
        CLI_CODIGO_MILITAR,
        [Description("@PrimerNombre")]
        CLI_PRIMER_NOMBRE,
        [Description("@SegundoNombre")]
        CLI_SEGUNDO_NOMBRE,
        [Description("@PrimerApellido")]
        CLI_PRIMER_APELLIDO,
        [Description("@SegundoApellido")]
        CLI_SEGUNDO_APELLIDO,
        [Description("@FechaNacimiento")]
        CLI_FECHA_NACIMIENTO,
        [Description("@IdPaisNacimiento")]
        DPP_ID_PAIS_NACIMIENTO,
        [Description("@IdDepartamentoNacimiento")]
        DPD_ID,
        [Description("@IdCiudadNacimiento")]
        DPC_ID,
        [Description("@LugarNacimientoExtranjero")]
        CLI_LUGAR_NACIMIENTO,
        [Description("@Sexo")]
        CAT_SEXO,
        [Description("@EstadoCivil")]
        CAT_ESTADO_CIVIL,
        [Description("@IdProfesion")]
        CLI_PROFESION,
        [Description("@Unidad")]
        CLI_UNIDAD,
        [Description("@IdCategoria")]
        CTG_ID,
        [Description("@IdFuerza")]
        FRZ_ID,
        [Description("@IdGrado")]
        GRD_ID,
        [Description("@IdUnidadEjecutora")]
        UEJ_ID,
        [Description("@FechaInscripcion")]
        CLI_FECHA_INSCRIPCION,
        [Description("@FechaAlta")]
        CLI_FECHA_ALTA,
        [Description("@Regimen")]
        CLI_REGIMEN,
        [Description("@FechaAltaCalculada")]
        CTS_SLP,
        [Description("@FechaReintegro")]
        CLI_FECHA_REINTEGRO,
        [Description("@EstadoCliente")]
        ECL_ID,
        [Description("@NumeroValidacion")]
        CLI_VALIDACION,
        [Description("@IdPatrocinador")]
        CLI_ID_PATROCINADOR,
        [Description("@Participacion")]
        CLI_PARTICIPACION,
        [Description("@NumeroResolucion")]
        CLI_RESOLUCION,
        [Description("@ValidacionBiometrica")]
        CLI_VALIDACION_BIOMETRICA,
        [Description("@Payload")]
        CLI_INTEGRACION_GA2_PAYLOAD,
        [Description("@IdInformacionEconomica")]
        CIE_ID,
        [Description("@IdActividadEconomica")]
        ACC_ID,
        [Description("@FechaCorte")]
        CIE_FECHA_INFO_ECONOMICA,
        [Description("@IngresoMensual")]
        CIE_INGRESO_MENSUAL,
        [Description("@EgresoMensual")]
        CIE_EGRESO_MENSUAL,
        [Description("@TotalActivos")]
        CIE_TOTAL_ACTIVOS,
        [Description("@TotalPasivos")]
        CIE_TOTAL_PASIVOS,
        [Description("@TotalPatrimonio")]
        CIE_TOTAL_PATRIMONIO,
        [Description("@IngresoAdicional")]
        CIE_INGRESO_ADICIONAL,
        [Description("@ConceptoIngresosAdicionales")]
        CIE_CONCEPTO_INGRESO_ADICIONAL,
        [Description("@TransaccionesMonedaExtranjera")]
        CIE_TRANS_EXTRANJERO,
        [Description("@IdMoneda")]
        MND_ID,
        [Description("@MontoTransaccionesExtranjero")]
        CIE_VALOR_TRANSFERENCIA,
        [Description("@IdDireccion")]
        DRC_ID,
        [Description("@ConsecutivoDireccion")]
        DRC_CONSECUTIVO,
        [Description("@IdPaisResidencia")]
        DPP_ID_RESIDENCIA,
        [Description("@IdDepartamentoResidencia")]
        DPD_ID_RESIDENCIA,
        [Description("@IdCiudadResidencia")]
        DPC_ID_RESIDENCIA,
        [Description("@CiudadResidenciaExtranjero")]
        DRC_CIUDAD_RESIDENCIA_EXTRANJERO,
        [Description("@IdTipoCalle")]
        TPC_TIPO_CALLE,
        [Description("@NumeroCalle1")]
        DRC_NUMERO_1,
        [Description("@IdLetra1")]
        LTR_LETRA_1,
        [Description("@IdBis1")]
        BS_BIS_1,
        [Description("@IdCardinal1")]
        CRD_CARDINAL_1,
        [Description("@NumeroCalle2")]
        DRC_NUMERO_2,
        [Description("@IdLetra2")]
        LTR_LETRA_2,
        [Description("@IdBis2")]
        BS_BIS_2,
        [Description("@IdCardinal2")]
        CRD_CARDINAL_2,
        [Description("@NumeroCalle3")]
        DRC_NUMERO_3,
        [Description("@IdLetra3")]
        LTR_LETRA_3,
        [Description("@IdCardinal3")]
        CRD_CARDINAL_3,
        [Description("@ComplementoDireccion")]
        DRC_COMPLEMENTO_DIRECCION,
        [Description("@Direccion")]
        DRC_DIRECCION,
        [Description("@Barrio")]
        DRC_BARRIO,
        [Description("@IdTipoDireccion")]
        DRC_TIPO_DIR,
        [Description("@IdSistemaActualiza")]
        ID_SISTEMA_SIS,
        [Description("@IdCorreo")]
        DCE_ID,
        [Description("@Correo")]
        DCE_CORREO,
        [Description("@IdTipoCorreo")]
        TCE_ID,
        [Description("@EnvioInformacionCorreo")]
        DCE_ENVIO_INFORMACION,
        [Description("@CorreoActivo")]
        DCE_ACTIVO,
        [Description("@IdTelefono")]
        DTL_ID,
        [Description("@IndicativoPaisTelefono")]
        DTL_INDICATIVO_PAIS,
        [Description("@IndicativoCiudadTelefono")]
        DTL_INDICATIVO_CIUDAD,
        [Description("@Telefono")]
        DTL_TELEFONO,
        [Description("@IdTipoTelefono")]
        TPT_ID,
        [Description("@EnvioInformacionSMS")]
        DTL_ENVIO_INFORMACION,
        [Description("@TelefonoActivo")]
        DTL_ACTIVO,
        [Description("@IdConyuge")]
        CNY_ID,
        [Description("@IdTipoIdentificacionConyuge")]
        CNY_TID_ID,
        [Description("@IdentificacionConyuge")]
        CNY_IDENTIFICACION,
        [Description("@PrimerNombreConyuge")]
        CNY_PRIMER_NOMBRE,
        [Description("@SegundoNombreConyuge")]
        CNY_SEGUNDO_NOMBRE,
        [Description("@PrimerApellidoConyuge")]
        CNY_PRIMER_APELLIDO,
        [Description("@SegundoApellidoConyuge")]
        CNY_SEGUNDO_APELLIDO,
        [Description("@ConyugeActivo")]
        CNY_ACTIVO,

        [Description("@@CLIENTES_IDS")]
        @CLIENTES_IDS,




    }


    public enum EnumClientConsultaParameters
    {
       
        [Description("@TID_ID")]
        TID_ID,
        [Description("@CLI_IDENTIFICACION")]
        CLI_IDENTIFICACION,

        [Description("@CLI_ID")]
        CLI_ID,

        [Description("@CTG_ID")]
        CTG_ID,

        [Description("@FRZ_ID")]
        FRZ_ID,

        [Description("@GRD_ID")]
        GRD_ID,

        [Description("@UEJ_ID")]
        UEJ_ID,

        [Description("@TPF_ID")]
        TPF_ID,
 

    }
}
