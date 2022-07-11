using System.ComponentModel;


namespace GA2.Infraestructure.Data
{
    public enum EnumGeneralParameters {
        [Description("@TIP_SUB_ID")]
        SubModalidad,

        [Description("@SLT_ID")]
        SolicitudTarea,
    }

    public enum EnumSolicitudParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@CTA_ID")]
        cuentaId,

        [Description("@TPS_SUB_ID")]
        tipoSubModalidadId,

        [Description("@CLI_ID")]
        clienteId,

        [Description("@SOL_CREATEDOPOR")]
        creadoPor,
        
        [Description("@TRA_ID")]
        tareaId,

        [Description("@SOL_ESTADO_SOLICITUD")]
        solEstadoSolicitud,

        [Description("@STL_ESTADO_SOLICITUD")]
        stlEstadoSolicitud,

        [Description("@SOL_VALOR_A_RETIRAR")]
        valorRetirar
    }


    public enum EnumConsultaSolicitudParameters
    {

        [Description("@TPS_SUB_ID")]
        tipoSubModalidadId,

        [Description("@CLI_ID")]
        clienteId,

        [Description("@SOL_ESTADO_ANULADO")]
        solEstadoAnulado
    }

    public enum EnumSolicitudMatriculaParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@NUMERO_MATRICULA")]
        NumeroMatricula,

        [Description("@FECHA_REGISTRO")]
        FechaRegistro,

        [Description("@DIRECCION")]
        Direccion,

        [Description("@DPC_ID_FK")]
        CiudadId,

        [Description("@MAI_PRINCIPAL")]
        Principal,

        [Description("@MAI_CREATEDOPOR")]
        CreadoPor
    }

    public enum EnumSolicitudPropietarioParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@NUMERO_IDENTIFICACION")]
        NumeroIdentificacion,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@PRP_CREATEDOPOR")]
        CreadoPor
    }

    public enum EnumSolicitudTerceroApoderadoParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTercero,

        [Description("@TER_ESAUTORIZADO")]
        EsAutorizado,

        [Description("@TER_PARENTESCO")]
        Parentesco
    }

    public enum EnumSolicitudTerceroBeneficiarioParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@ENT_ID_FK")]
        Entidad,

        [Description("@TER_TIPO_CUENTA_FK")]
        TipoCuenta,

        [Description("@NUMERO_CUENTA")]
        NumeroCuenta,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTercero,

        [Description("@TER_VALOR_RETIRAR")]
        ValorRetirarDos
    }

    public enum EnumSolicitudTerceroConstructorParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@NUMERO_LICENCIA_CONSTRUCCION")]
        NumeroLicencia,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTercero
    }

    public enum EnumSolicitudTerceroVendedorParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@DIRECCION")]
        Direccion,

        [Description("@DPC_ID_FK")]
        Ciudad,

        [Description("@CORREO_ELECTRONICO")]
        CorreoElectronico,

        [Description("@TELEFONO")]
        Telefono,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTercero
    }

    public enum EnumInsertarArchivoParameters
    {
        [Description("@AST_ID")]
        ArchivoSolicitudId,

        [Description("@AST_NOMBRE_ARCHIVO")]
        NombreArchivo,

        [Description("@AST_RUTA_STORAGE")]
        RutaArchivo,

        [Description("@AST_EXTENSION")]
        ExtensionArchivo,

        [Description("@AST_FECHA_CARGUE")]
        FechaCargue,

        [Description("@SOL_ID_FK")]
        Solicitud,

        [Description("@PAM_ID_FK")]
        Parametrizacion,

        [Description("@PAM_ORDEN")]
        Orden,

        [Description("@AST_CREATEDOPOR")]
        CreadoPor
    }

    public enum EnumActualizaSolicitudTareaParameters
    {
        [Description("@SLT_ID")]
        SolicitudTareaId,

        [Description("@SLT_ESTADO_SOLICITUD")]
        SolicitudTareaEstadoId,

        [Description("@SLT_ESTADO_SOLICITUD_NUEVO")]
        SolicitudTareaEstadoNuevoId,

        [Description("@SOL_ESTADO_SOLICITUD")]
        SolicitudEstadoId
    }

    public enum EnumConsultarSolicitudMatriculaParameters
    {
        [Description("@SOL_ID")]
        SolicitudId
    }

    public enum EnumSolicitudTerceroAutorizadoParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor
    }

    public enum EnumSolicitudPropietarioMatriculaParameters
    {
        [Description("@PRP_ID")]
        PropietarioId,

        [Description("@MAI_ID")]
        MatriculaId,

        [Description("@PMA_CREATEDOPOR")]
        CreadoPor
    }

    public enum EnumSolicitudEntidadEducativaParameters
    {
        [Description("@PGN_ID_FK")]
        EntidadId,

        [Description("@NUMERO_DOCUMENTO")]
        Nit,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@PRN_ID_FK")]
        NivelId,

        [Description("@TER_NUM_RECIBO_PAGO")]
        ReciboPago,

        [Description("@TER_FECHA_LIMITE_PAGO")]
        FechaPago,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTerceroEntidadEducativa,

        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacionNit
    }

    public enum EnumSolicitudTerceroBeneficiarioEstudioParameters
    {
        [Description("@TER_NUMERO_DOCUMENTO")]
        numDoc,

        [Description("@TER_NOMBRE_RAZON_SOCIAL")]
        razonSocialEstudiante,

        [Description("@TER_PARENTESCO")]
        parentescoId,

        [Description("@CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTerceroBeneficiarioEstudioId,

        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        tipoDocId
    }

    public enum EnumSolicitudTerceroBeneficiarioEstudioEntidadEducativaParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTerceroBeneficiarioEstudioEntidadEducativaId,

        [Description("@TID_ID_FK")]
        tipoDocId,

        [Description("@TER_NUMERO_DOCUMENTO")]
        numDoc,

        [Description("@TER_NOMBRE_RAZON_SOCIAL")]
        razonSocialEstudiante,

        [Description("@TER_PARENTESCO")]
        parentescoId,

        [Description("@PGN_ID_FK")]
        EntidadId,

        [Description("@NUMERO_DOCUMENTO")]
        Nit,

        [Description("@NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@PRN_ID_FK")]
        NivelId,

        [Description("@TER_NUM_RECIBO_PAGO")]
        ReciboPago,

        [Description("@SOL_VALOR_A_RETIRAR")]
        valorRetirar,

        [Description("@TER_FECHA_LIMITE_PAGO")]
        FechaPago,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor
    }

    public enum EnumSolicitudTerceroEntidadSeguroEducativoParameters
    {
        [Description("@TER_NUMERO_DOCUMENTO")]
        numDoc,

        [Description("@TER_NOMBRE_RAZON_SOCIAL")]
        razonSocialAseguradora,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTerceroEntidadSeguroId,

        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        tipoDocId,

        [Description("@ESE_ID_FK")]
        entidadSeguroEducativoId,

        [Description("@TER_NUM_POLIZA")]
        numeroPoliza        
    }

    public enum EnumSolicitudTerceroTenedorAccionesParameters
    {
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@TID_ID_FK")]
        TipoIdentificacion,

        [Description("@TER_NUMERO_DOCUMENTO")]
        NumeroDocumento,

        [Description("@TER_NOMBRE_RAZON_SOCIAL")]
        RazonSocial,

        [Description("@TER_DIRECCION")]
        Direccion,

        [Description("@DPC_ID_FK")]
        Ciudad,

        [Description("@TER_CORREO_ELECTRONICO")]
        CorreoElectronico,

        [Description("@TER_TELEFONO")]
        Telefono,

        [Description("@TER_CREATEDOPOR")]
        CreadoPor,

        [Description("@TER_TIPO_TERCERO_FK")]
        TipoTercero,

        [Description("@TER_EMISOR_NOMBRE_RAZON_SOCIAL")]
        RazonSocialEmisor
    }

    public enum EnumInconsistenciaSolicitudParameters
    {

        [Description("@INC_ID")]
        InconsistenciaId,

        [Description("@LIN_ID_FK")]
        ListaInconsistenciaId,

        [Description("@GIN_GRUPO")]
        GrupoInconsistencia,

        [Description("@HER_ID_FK")]
        HerramientaId,

        [Description("@PTA_ID_FK")]
        PuntoAtencionId,
        
        [Description("@SOL_ID_FK")]
        SolicitudId,

        [Description("@USR_ID_FK")]
        TecnicoId,

        [Description("@INC_OBJETO_ESTUDIO")]
        ObjetoEstudio,

        [Description("@INC_ANALISIS_REALIZADO")]
        Analisis,
        
        [Description("@INC_OBSERVACION")]
        Observacion,

        [Description("@INC_ESTADO")]
        Estado,

        [Description("@INC_CREATEDOPOR")]
        CreadoPor,

        [Description("@INC_MODIFICADOPOR")]
        ModificadoPor,

        [Description("@INC_FECHAMODIFICACION")]
        FechaModificacion
    }

    public enum EnumConsultarSolicitudCesantiasParameters
    {
        [Description("@SOL_FECHA_SOLICITUD")]
        FechaSolicitud,

        [Description("@CLI_IDENTIFICACION")]
        Identificacion,

        [Description("@USR_ID")]
        Usuario,

        [Description("@SLT_ESTADO_SOLICITUD")]
        EstadoSolicitud,

        [Description("@PCS_ID")]
        TipoSolicitud
    }
}
