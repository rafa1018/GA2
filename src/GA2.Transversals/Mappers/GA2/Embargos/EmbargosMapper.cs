using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    public class EmbargosMapper : Profile
    {
        public EmbargosMapper()
        {
            // Model JuzgadosDto Juzgados
            CreateMap<Juzgados, JuzgadosDto>()
                .ForMember(x => x.IdJuzgado, map => map.MapFrom(dto => dto.ID_JUZGADO))
                .ForMember(x => x.CodigoInterno, map => map.MapFrom(dto => dto.CODIGO_INTERNO))
                .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
                .ForMember(x => x.IdDepartamento, map => map.MapFrom(dto => dto.ID_DPD))
                .ForMember(x => x.Departamento, map => map.MapFrom(dto => dto.DPD_NOMBRE))
                .ForMember(x => x.IdCiudad, map => map.MapFrom(dto => dto.ID_DPC))
                .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.DPC_NOMBRE))
                .ForMember(x => x.NroCuenta, map => map.MapFrom(dto => dto.NRO_CUENTA))
                .ForMember(x => x.CodigoOficina, map => map.MapFrom(dto => dto.CODIGO_OFICINA))
                .ForMember(x => x.CorreoElectronico, map => map.MapFrom(dto => dto.CORREO_ELECTRONICO))
                .ForMember(x => x.Celular, map => map.MapFrom(dto => dto.CELULAR))
                .ForMember(x => x.Contacto, map => map.MapFrom(dto => dto.CONTACTO))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
                .ForMember(x => x.codigoCiudad, map => map.MapFrom(dto => dto.DPC_CODIGO))
                .ReverseMap();

            CreateMap<JuzgadosGuid, JuzgadosGuidDto>()
           .ForMember(x => x.IdJuzgado, map => map.MapFrom(dto => dto.ID_JUZGADO))
           .ForMember(x => x.CodigoInterno, map => map.MapFrom(dto => dto.CODIGO_INTERNO))
           .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
           .ForMember(x => x.IdDepartamento, map => map.MapFrom(dto => dto.ID_DPD))
           .ForMember(x => x.Departamento, map => map.MapFrom(dto => dto.DPD_NOMBRE))
           .ForMember(x => x.IdCiudad, map => map.MapFrom(dto => dto.ID_DPC))
           .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.DPC_NOMBRE))
           .ForMember(x => x.NroCuenta, map => map.MapFrom(dto => dto.NRO_CUENTA))
           .ForMember(x => x.CodigoOficina, map => map.MapFrom(dto => dto.CODIGO_OFICINA))
           .ForMember(x => x.CorreoElectronico, map => map.MapFrom(dto => dto.CORREO_ELECTRONICO))
           .ForMember(x => x.Celular, map => map.MapFrom(dto => dto.CELULAR))
           .ForMember(x => x.Contacto, map => map.MapFrom(dto => dto.CONTACTO))
           .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
           .ForMember(x => x.codigoCiudad, map => map.MapFrom(dto => dto.DPC_CODIGO))
           .ReverseMap();

            CreateMap<TipoEmbargos, TipoEmbargosDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TIE_ID))
               .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.TIE_NOMBRE))
               .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TIE_DESCRIPCION))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.TIE_ESTADO))
               .ReverseMap();

            CreateMap<TiposProcesos, TiposProcesosDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TPE_ID))
               .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.TPE_NOMBRE))
               .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TPE_DESCRIPCION))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.TPE_ESTADO))
               .ReverseMap();

            CreateMap<Embargo, EmbargosDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.EBA_ID))
               .ForMember(x => x.RadicadoWorkManager, map => map.MapFrom(dto => dto.EBA_RADICADO_WORK_MANAGER))
               .ForMember(x => x.FechaRadicadoWorkManager, map => map.MapFrom(dto => dto.EBA_FECHA_RADICADO_WORK_MANAGER))
               .ForMember(x => x.RadicadoJuzgado, map => map.MapFrom(dto => dto.EBA_RADICADO_JUZGADO))
               .ForMember(x => x.FechaRadicadoJuzgado, map => map.MapFrom(dto => dto.EBA_FECHA_RADICADO_JUZGADO))
               .ForMember(x => x.EmailRespuesta, map => map.MapFrom(dto => dto.EBA_EMAIL_RESPUESTA))
               .ForMember(x => x.DireccionRespuesta, map => map.MapFrom(dto => dto.EBA_DIRECCION_RESPUESTA))
               .ForMember(x => x.NombreDemandante, map => map.MapFrom(dto => dto.EBA_NOMBRE_DEMANDANTE))
               .ForMember(x => x.NombreDemandado, map => map.MapFrom(dto => dto.EBA_NOMBRE_DEMANDADO))
               .ForMember(x => x.ExpedienteBancoAgrario, map => map.MapFrom(dto => dto.EBA_EXPEDIENTE_BANCO_AGRARIO))
               .ForMember(x => x.Remanente, map => map.MapFrom(dto => dto.EBA_REMANENTE))
               .ForMember(x => x.Observaciones, map => map.MapFrom(dto => dto.EBA_OBSERVACIONES))
               .ForMember(x => x.Respuesta, map => map.MapFrom(dto => dto.EBA_RESPUESTA))
               .ForMember(x => x.Valor, map => map.MapFrom(dto => dto.EBA_VALOR))
               .ForMember(x => x.ClienteId, map => map.MapFrom(dto => dto.CLI_ID))
               .ForMember(x => x.JuzgadoId, map => map.MapFrom(dto => dto.EMB_ID_JUZGADO))
               .ForMember(x => x.ProcesoId, map => map.MapFrom(dto => dto.TPE_ID))
               .ForMember(x => x.TipoEmbargoId, map => map.MapFrom(dto => dto.TIE_ID))
               .ForMember(x => x.FechaRegistro, map => map.MapFrom(dto => dto.EBA_FECHA_REGISTRO))
               .ForMember(x => x.FechaActualizacion, map => map.MapFrom(dto => dto.EBA_FECHA_ACTUALIZACION))
               .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.EBA_CREADOPOR))
               .ForMember(x => x.ActualizadoPor, map => map.MapFrom(dto => dto.EBA_ACTUALIZADOPOR))
               .ForMember(x => x.Juzgado, map => map.MapFrom(dto => dto.JUZGADO))
               .ForMember(x => x.TipoProceso, map => map.MapFrom(dto => dto.TIPO_PROCESO))
               .ForMember(x => x.TipoEmbargo, map => map.MapFrom(dto => dto.TIPO_EMBARGO))
               .ReverseMap();


            CreateMap<EmbargoCuentaConcepto, EmbargoCuentaConceptoDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ECC_ID))
               .ForMember(x => x.Valor, map => map.MapFrom(dto => dto.ECC_VALOR))
               .ForMember(x => x.FechaInicio, map => map.MapFrom(dto => dto.ECC_FECHA_INICIO_EMBARGO))
               .ForMember(x => x.FechaFin, map => map.MapFrom(dto => dto.ECC_FECHA_FIN_EMBARGO))
               .ForMember(x => x.IndicadorCesantias, map => map.MapFrom(dto => dto.ECC_INDICADOR_CESANTIAS))
               .ForMember(x => x.EmbardoId, map => map.MapFrom(dto => dto.EBA_ID))
               .ForMember(x => x.TipoRetencionId, map => map.MapFrom(dto => dto.TRE_ID))
               .ForMember(x => x.TipoEmbargoId, map => map.MapFrom(dto => dto.TIE_ID))
               .ForMember(x => x.CuentaId, map => map.MapFrom(dto => dto.CTA_ID))
               .ForMember(x => x.ConceptoId, map => map.MapFrom(dto => dto.CCT_ID))
               .ForMember(x => x.FechaRegistro, map => map.MapFrom(dto => dto.EBA_FECHA_REGISTRO))
               .ForMember(x => x.FechaActualizacion, map => map.MapFrom(dto => dto.EBA_FECHA_ACTUALIZACION))
               .ForMember(x => x.CreadoPorId, map => map.MapFrom(dto => dto.EBA_CREADOPOR))
               .ForMember(x => x.ActualizadoPorId, map => map.MapFrom(dto => dto.EBA_ACTUALIZADOPOR))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ECC_ESTADO))
               .ForMember(x => x.Tipoembargo, map => map.MapFrom(dto => dto.TIPO_EMBARGO))
               .ForMember(x => x.TipoRetencion, map => map.MapFrom(dto => dto.TIPO_RETENCION))
               .ForMember(x => x.RadicadoWorkManager, map => map.MapFrom(dto => dto.EBA_RADICADO_WORK_MANAGER))
               .ReverseMap();

            CreateMap<TipoRetencion, TipoRetencionDto>()
              .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TRE_ID))
              .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.TRE_NOMBRE))
              .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TRE_DESCRIPCION))
              .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.TRE_ESTADO))
              .ReverseMap();


            CreateMap<BeneficiariosPagoEmbargo, BeneficiariosPagoEmbargoDto>()
              .ForMember(x => x.Id, map => map.MapFrom(dto => dto.BPE_ID))
              .ForMember(x => x.EmbargoId, map => map.MapFrom(dto => dto.EBA_ID))
              .ForMember(x => x.TipoDocumentoId, map => map.MapFrom(dto => dto.TID_ID))
              .ForMember(x => x.NumeroIdentificacion, map => map.MapFrom(dto => dto.BPE_NUMERO_IDENTIFICACION))
              .ForMember(x => x.PrimerNombre, map => map.MapFrom(dto => dto.BPE_PRIMER_NOMBRE))
              .ForMember(x => x.SegundoNombre, map => map.MapFrom(dto => dto.BPE_SEGUNDO_NOMBRE))
              .ForMember(x => x.PrimerApellido, map => map.MapFrom(dto => dto.BPE_PRIMER_APELLIDO))
              .ForMember(x => x.SegundoApellido, map => map.MapFrom(dto => dto.BPE_SEGUNGO_APELLIDO))
              .ForMember(x => x.FechaRegistro, map => map.MapFrom(dto => dto.BPE_FECHA_REGISTRO))
              .ForMember(x => x.FechaActualizacion, map => map.MapFrom(dto => dto.BPE_FECHA_ACTUALIZACION))
              .ForMember(x => x.Creadopor, map => map.MapFrom(dto => dto.BPE_CREADOPOR))
              .ForMember(x => x.ActualizadoPor, map => map.MapFrom(dto => dto.BPE_ACTUALIZADOPOR))
              .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.BPE_ESTADO))
              .ForMember(x => x.TipoIdentificacion, map => map.MapFrom(dto => dto.TIPO_IDENTIFICACION))
              .ForMember(x => x.RadicadoWorkManager, map => map.MapFrom(dto => dto.EBA_RADICADO_WORK_MANAGER))
              .ReverseMap();

            CreateMap<Desembargo, DesembargoDto>()
             .ForMember(x => x.Id, map => map.MapFrom(dto => dto.DES_ID))
             .ForMember(x => x.EmbargoCuentaConceptoId, map => map.MapFrom(dto => dto.ECC_ID))
             .ForMember(x => x.FechaRegistro, map => map.MapFrom(dto => dto.DES_FECHA_REGISTRO))
             .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.DES_ESTADO))
             .ReverseMap();


            CreateMap<ObtenerDesembargo, ObtenerDesembargoDto>()
            .ForMember(x => x.Id, map => map.MapFrom(dto => dto.DES_ID))
            .ForMember(x => x.Valor, map => map.MapFrom(dto => dto.ECC_VALOR))
            .ForMember(x => x.NombreDemandado, map => map.MapFrom(dto => dto.EBA_NOMBRE_DEMANDADO))
            .ForMember(x => x.NombreDemandante, map => map.MapFrom(dto => dto.EBA_NOMBRE_DEMANDANTE))
            .ForMember(x => x.RadicadoWorkManager, map => map.MapFrom(dto => dto.EBA_RADICADO_WORK_MANAGER))
            .ForMember(x => x.RadicadoJuzgado, map => map.MapFrom(dto => dto.EBA_RADICADO_JUZGADO))
            .ForMember(x => x.ExpedienteBancoAgrario, map => map.MapFrom(dto => dto.EBA_EXPEDIENTE_BANCO_AGRARIO))
            .ForMember(x => x.TipoEmbargo, map => map.MapFrom(dto => dto.TIPO_EMBARGO))
            .ForMember(x => x.TipoProceso, map => map.MapFrom(dto => dto.TIPO_PROCESO))
            .ForMember(x => x.TipoRetencion, map => map.MapFrom(dto => dto.TIPO_RETENCION))
            .ForMember(x => x.Juzgado, map => map.MapFrom(dto => dto.JUZGADO))
            .ForMember(x => x.CuentaId, map => map.MapFrom(dto => dto.CTA_ID))
            .ForMember(x => x.ClienteId, map => map.MapFrom(dto => dto.CLI_ID))

            .ReverseMap();




        }
    }
}
