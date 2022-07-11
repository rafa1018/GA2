using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    public class SolicitudMapper : Profile
    {

        public SolicitudMapper()
        {
            CreateMap<SolicitudPropietario, SolicitudPropietarioDto>()
                .ForMember(x => x.RazonSocial, map => map.MapFrom(dto => dto.PRP_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.NumeroIdentificacion, map => map.MapFrom(dto => dto.PRP_NUMERO_IDENTIFICACION))
                //.ForMember(x => x.TipoIdentificacion.Id, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ReverseMap();

            CreateMap<SolicitudMatricula, SolicitudMatriculaDto>()
                .ForMember(x => x.CiudadId, map => map.MapFrom(dto => dto.DPC_ID_FK))
                .ForMember(x => x.Direccion, map => map.MapFrom(dto => dto.MAI_DIRECCION))
                .ForMember(x => x.NumeroMatricula, map => map.MapFrom(dto => dto.MAI_NUMERO_MATRICULA))
                .ForMember(x => x.EsPrincipal, map => map.MapFrom(dto => dto.MAI_PRINCIPAL))
                .ReverseMap();

            CreateMap<CrearSolicitud, CrearSolicitudDto>()
                .ForMember(x => x.tipoSubModalidad, map => map.MapFrom(dto => dto.TPS_SUB_ID))
                .ForMember(x => x.cuentaId, map => map.MapFrom(dto => dto.CTA_ID))
                .ForMember(x => x.creadoPor, map => map.MapFrom(dto => dto.SOL_CREATEDOPOR))
                .ForMember(x => x.clienteId, map => map.MapFrom(dto => dto.CLI_ID))
                .ReverseMap();

            CreateMap<ObtenerTramiteSolicitud, ObtenerTramiteSolicitudDto>()
                .ForMember(x => x.clienteId, map => map.MapFrom(dto => dto.CLI_ID))
                .ForMember(x => x.fechaSolicitud, map => map.MapFrom(dto => dto.SOL_FECHA_SOLICITUD))
                .ForMember(x => x.cuentaId, map => map.MapFrom(dto => dto.CTA_ID))
                .ForMember(x => x.solicitudId, map => map.MapFrom(dto => dto.SOL_ID))
                .ForMember(x => x.estadoSolicitud, map => map.MapFrom(dto => dto.SOL_ESTADO))
                .ForMember(x => x.tipoModalidadId, map => map.MapFrom(dto => dto.TIM_ID))
                .ForMember(x => x.solicitudEstadoId, map => map.MapFrom(dto => dto.SOL_ESTADO_SOLICITUD))
                .ForMember(x => x.solicitudTareaEstadoId, map => map.MapFrom(dto => dto.SLT_ESTADO_SOLICITUD))
                .ForMember(x => x.volverPantalla, map => map.MapFrom(dto => dto.VOLVER_PANTALLA))
                .ForMember(x => x.solicitudTareaId, map => map.MapFrom(dto => dto.SLT_ID))
                .ForMember(x => x.descripcionModalidad, map => map.MapFrom(dto => dto.TIM_DESCRIPCION))
                .ForMember(x => x.descripcionSubModalidad, map => map.MapFrom(dto => dto.TPS_SUB_DESCRIPCION))
                .ForMember(x => x.descripcionProceso, map => map.MapFrom(dto => dto.PCS_DESCRIPCION))
                .ForMember(x => x.valorRetirar, map => map.MapFrom(dto => dto.SOL_VALOR_A_RETIRAR))
                .ForMember(x => x.tipoSubModalidadId, map => map.MapFrom(dto => dto.TPS_SUB_ID))
                .ForMember(x => x.tipoModalidadId, map => map.MapFrom(dto => dto.TIM_ID))
                .ForMember(x => x.pestanas, map => map.MapFrom(dto => dto.PESTANAS))
                .ForMember(x => x.ultimoSolicitudTareaId, map => map.MapFrom(dto => dto.ULTIMO_SLT_ID))
                .ReverseMap();

            CreateMap<SolicitudTerceroApoderado, SolicitudTerceroApoderadoDto>()
                .ForMember(x => x.TipoDoc, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ForMember(x => x.NumDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
                .ForMember(x => x.Razonsocial, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.Parentesco, map => map.MapFrom(dto => dto.TER_PARENTESCO))
                .ForMember(x => x.EsAutorizado, map => map.MapFrom(dto => dto.TER_ESAUTORIZADO))
                .ReverseMap();

            CreateMap<SolicitudTerceroBeneficiario, SolicitudTerceroBeneficiarioDto>()
                .ForMember(x => x.TipoDoc, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ForMember(x => x.NumDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
                .ForMember(x => x.Razonsocial, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.Entidad, map => map.MapFrom(dto => dto.ENT_ID_FK))
                .ForMember(x => x.TipoCuenta, map => map.MapFrom(dto => dto.TER_TIPO_CUENTA))
                .ForMember(x => x.NumeroCuenta, map => map.MapFrom(dto => dto.TER_NUMERO_CUENTA))
                .ForMember(x => x.ValorRetirarDos, map => map.MapFrom(dto => dto.TER_VALOR_RETIRAR))
                .ReverseMap();

            CreateMap<SolicitudTerceroConstructor, SolicitudTerceroConstructorDto>()
                .ForMember(x => x.TipoDoc, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ForMember(x => x.NumDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
                .ForMember(x => x.Razonsocial, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.NumeroLicencia, map => map.MapFrom(dto => dto.TER_NUMERO_LICENCIA_CONSTRUCCION))
                .ReverseMap();

            CreateMap<SolicitudTerceroVendedor, SolicitudTerceroVendedorDto>()
                .ForMember(x => x.TipoDoc, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ForMember(x => x.NumDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
                .ForMember(x => x.Razonsocial, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.Direccion, map => map.MapFrom(dto => dto.TER_DIRECCION))
                .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.DPC_ID_FK))
                .ForMember(x => x.Correo, map => map.MapFrom(dto => dto.TER_CORREO_ELECTRONICO))
                .ForMember(x => x.Telefono, map => map.MapFrom(dto => dto.TER_TELEFONO))
                .ReverseMap();

            CreateMap<SolicitudTerceroAutorizado, SolicitudTerceroAutorizadoDto>()
                .ForMember(x => x.TipoDoc, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ForMember(x => x.NumDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
                .ForMember(x => x.Razonsocial, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
                .ReverseMap();

            CreateMap<RespuestaDocumentosPorSubModalidad, DocumentosPorSubModalidadDto>()
                .ForMember(x => x.descripcionArchivo, map => map.MapFrom(dto => dto.PAM_DESCRIPCION_ARCHIVO))
                .ForMember(x => x.esRequerido, map => map.MapFrom(dto => dto.PAM_REQUERIDO))
                .ForMember(x => x.idArchivo, map => map.MapFrom(dto => dto.PAM_ID))
                .ForMember(x => x.nombreArchivo, map => map.MapFrom(dto => dto.PAM_NOMBRE_ARCHIVO))
                .ForMember(x => x.ordenArchivo, map => map.MapFrom(dto => dto.PAM_ORDEN))
                .ForMember(x => x.esMultipleArchivo, map => map.MapFrom(dto => dto.PAM_MULTIPLE_ARCHIVO))
                .ForMember(x => x.formatoArchivo, map => map.MapFrom(dto => dto.PAM_FORMATO))
                .ReverseMap();

            //CreateMap<SolicitudTerceroEntidadSeguroEducativo, SolicitudTerceroEntidadSeguroEducativoDto>()
            //    .ForMember(x => x.tipoDocId, map => map.MapFrom(dto => dto.TID_ID_FK))
            //    .ForMember(x => x.numDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
            //    .ForMember(x => x.razonSocialAseguradora, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
            //    .ForMember(x => x.entidadSeguroEducativoId, map => map.MapFrom(dto => dto.ESE_ID_FK))
            //    .ForMember(x => x.numeroPoliza, map => map.MapFrom(dto => dto.TER_NUM_POLIZA))
            //    .ReverseMap();

            //CreateMap<SolicitudTerceroTenedorAcciones, SolicitudTerceroTenedorAccionesDto>()
            //    .ForMember(x => x.TipoDoc, map => map.MapFrom(dto => dto.TID_ID_FK))
            //    .ForMember(x => x.NumDoc, map => map.MapFrom(dto => dto.TER_NUMERO_DOCUMENTO))
            //    .ForMember(x => x.Razonsocial, map => map.MapFrom(dto => dto.TER_NOMBRE_RAZON_SOCIAL))
            //    .ForMember(x => x.Direccion, map => map.MapFrom(dto => dto.TER_DIRECCION))
            //    .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.DPC_ID_FK))
            //    .ForMember(x => x.Correo, map => map.MapFrom(dto => dto.TER_CORREO_ELECTRONICO))
            //    .ForMember(x => x.Telefono, map => map.MapFrom(dto => dto.TER_TELEFONO))
            //    .ForMember(x => x.Emisor, map => map.MapFrom(dto => dto.TER_EMISOR_NOMBRE_RAZON_SOCIAL))
            //    .ReverseMap();

            CreateMap<InsertarArchivo, InsertarArchivoDto>()
                .ForMember(x => x.nombreArchivo, map => map.MapFrom(dto => dto.AST_NOMBRE_ARCHIVO))
                .ForMember(x => x.ruta, map => map.MapFrom(dto => dto.AST_RUTA_STORAGE))
                .ForMember(x => x.extension, map => map.MapFrom(dto => dto.AST_EXTENSION))
                .ForMember(x => x.fechaCargue, map => map.MapFrom(dto => dto.AST_FECHA_CARGUE))
                .ReverseMap();

            CreateMap<ConsultarArchivoPorSolicitud, ConsultarArchivoPorSolicitudDto>()
                .ForMember(x => x.idArchivo, map => map.MapFrom(dto => dto.AST_ID))
                .ForMember(x => x.nombreArchivo, map => map.MapFrom(dto => dto.AST_NOMBRE_ARCHIVO))
                .ForMember(x => x.rutaStorage, map => map.MapFrom(dto => dto.AST_RUTA_STORAGE))
                .ForMember(x => x.extension, map => map.MapFrom(dto => dto.AST_EXTENSION))
                .ForMember(x => x.tipoArchivo, map => map.MapFrom(dto => dto.PAM_NOMBRE_ARCHIVO))
                .ForMember(x => x.orden, map => map.MapFrom(dto => dto.PAM_ORDEN))
                .ReverseMap();

            // Model InconsistenciaSolicitud InconsistenciaSolicitudDto
            CreateMap<InconsistenciaSolicitud, InconsistenciaSolicitudDto>()
                    .ForMember(x => x.InconsistenciaId, map => map.MapFrom(dto => dto.INC_ID))
                    .ForMember(x => x.ListaInconsistenciaId, map => map.MapFrom(dto => dto.LIN_ID_FK))
                    .ForMember(x => x.GrupoInconsistencia, map => map.MapFrom(dto => dto.GIN_GRUPO))
                    .ForMember(x => x.HerramientaId, map => map.MapFrom(dto => dto.HER_ID_FK))
                    .ForMember(x => x.PuntoAtencionId, map => map.MapFrom(dto => dto.PTA_ID_FK))
                    .ForMember(x => x.SolicitudId, map => map.MapFrom(dto => dto.SOL_ID_FK))
                    .ForMember(x => x.TecnicoId, map => map.MapFrom(dto => dto.USR_ID_FK))
                    .ForMember(x => x.ObjetoEstudio, map => map.MapFrom(dto => dto.INC_OBJETO_ESTUDIO))
                    .ForMember(x => x.Analisis, map => map.MapFrom(dto => dto.INC_ANALISIS_REALIZADO))
                    .ForMember(x => x.Observacion, map => map.MapFrom(dto => dto.INC_OBSERVACION))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.INC_ESTADO))
                    .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.INC_CREATEDOPOR))
                    .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.INC_MODIFICADOPOR))
                    .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.INC_FECHAMODIFICACION))
                    .ReverseMap();

            CreateMap<PeticionConsultarSolicitudCesantias, PeticionConsultarSolicitudCesantiasDto>()
                // .ForMember(x => x.FechaSolicitud, map => map.MapFrom(dto => dto.SOL_FECHA_SOLICITUD))
                .ForMember(x => x.Identificacion, map => map.MapFrom(dto => dto.CLI_IDENTIFICACION))
                // .ForMember(x => x.Usuario, map => map.MapFrom(dto => dto.USR_ID))
                .ForMember(x => x.EstadoTarea, map => map.MapFrom(dto => dto.CVL_ID))
                .ForMember(x => x.TipoSolicitud, map => map.MapFrom(dto => dto.PCS_ID))
                .ReverseMap();

            CreateMap<RespuestaConsultarSolicitudCesantias, RespuestaConsultarSolicitudCesantiasDto>()
                .ForMember(x => x.NumeroSolicitud, map => map.MapFrom(dto => dto.SOL_NUMERO_SOLICITUD))
                .ForMember(x => x.ProcesoDescripcion, map => map.MapFrom(dto => dto.PCS_DESCRIPCION))
                .ForMember(x => x.FechaSolicitud, map => map.MapFrom(dto => dto.SOL_FECHA_SOLICITUD))
                .ForMember(x => x.ValorRetirar, map => map.MapFrom(dto => dto.SOL_VALOR_A_RETIRAR))
                .ForMember(x => x.TareaNombre, map => map.MapFrom(dto => dto.TRA_NOMBRE))
                .ForMember(x => x.EstadoSolicitud, map => map.MapFrom(dto => dto.CVL_DESCRIPCION))
                .ForMember(x => x.IdCliente, map => map.MapFrom(dto => dto.CLI_ID))
                .ReverseMap();
        }
    }
}
