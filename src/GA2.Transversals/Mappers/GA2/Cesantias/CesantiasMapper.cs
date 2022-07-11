using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    public class CesantiasMapper : Profile
    {

        public CesantiasMapper()
        {
            CreateMap<ParametrosObtenerCesantias, ParametrosObtenerCesantiasDto>()
                .ForMember(x => x.solicitudId, map => map.MapFrom(dto => dto.SOL_ID))
                .ForMember(x => x.subModalidadId, map => map.MapFrom(dto => dto.TPS_SUB_ID))
                .ForMember(x => x.IdCliente, map => map.MapFrom(dto => dto.CLI_ID))
                .ReverseMap();

            CreateMap<ObtenerTramiteCesantias, ObtenerTramiteCesantiasDto>()
                .ForMember(x => x.TIPO_CREDITO, map => map.MapFrom(dto => dto.TIPO_CREDITO))
                .ForMember(x => x.FECHA_SOLICITUD, map => map.MapFrom(dto => dto.FECHA_SOLICITUD))
                .ForMember(x => x.NUMERO_SOLICITUD, map => map.MapFrom(dto => dto.NUMERO_SOLICITUD))
                .ForMember(x => x.CEDULA_CLIENTE, map => map.MapFrom(dto => dto.CEDULA_CLIENTE))
                .ForMember(x => x.NOMBRE_CLIENTE, map => map.MapFrom(dto => dto.NOMBRE_CLIENTE))
                .ForMember(x => x.ACTIVIDAD, map => map.MapFrom(dto => dto.ACTIVIDAD))
                .ForMember(x => x.ID_ACTIVIDAD_FLUJO, map => map.MapFrom(dto => dto.ID_ACTIVIDAD_FLUJO))
                .ForMember(x => x.ORDEN, map => map.MapFrom(dto => dto.ORDEN))
                .ForMember(x => x.ESTADO_ACTIVIDAD, map => map.MapFrom(dto => dto.ESTADO_ACTIVIDAD))
                .ForMember(x => x.ID_CUENTA, map => map.MapFrom(dto => dto.ID_CUENTA))
                .ForMember(x => x.ID_SIMULACION, map => map.MapFrom(dto => dto.ID_SIMULACION))
                .ForMember(x => x.ID_ESTADO_ACTIVIDAD, map => map.MapFrom(dto => dto.ID_ESTADO_ACTIVIDAD))
                .ForMember(x => x.USUARIO_RESPONSABLE, map => map.MapFrom(dto => dto.USUARIO_RESPONSABLE))
                .ForMember(x => x.ID_TIPO_CREDITO, map => map.MapFrom(dto => dto.ID_TIPO_CREDITO))
                .ForMember(x => x.CONVENIO_ASEGURADORA, map => map.MapFrom(dto => dto.CONVENIO_ASEGURADORA))
                .ForMember(x => x.CODIGO_ASEGURADORA, map => map.MapFrom(dto => dto.CODIGO_ASEGURADORA))
                .ForMember(x => x.ASEGURADORA, map => map.MapFrom(dto => dto.ASEGURADORA))
                .ForMember(x => x.NO_CELULAR, map => map.MapFrom(dto => dto.NO_CELULAR))
                .ForMember(x => x.CORREO_PERSONAL, map => map.MapFrom(dto => dto.CORREO_PERSONAL))
                .ForMember(x => x.DIRECCION_RESIDENCIA, map => map.MapFrom(dto => dto.DIRECCION_RESIDENCIA))
                .ForMember(x => x.TELEFONO_RESIDENCIA, map => map.MapFrom(dto => dto.TELEFONO_RESIDENCIA))
                .ForMember(x => x.TIPO_INMUEBLE, map => map.MapFrom(dto => dto.TIPO_INMUEBLE))
                .ForMember(x => x.TIPO_VIVIENDA, map => map.MapFrom(dto => dto.TIPO_VIVIENDA))
                .ForMember(x => x.VALOR_INMUEBLE, map => map.MapFrom(dto => dto.VALOR_INMUEBLE))
                .ForMember(x => x.VALOR_CREDITO, map => map.MapFrom(dto => dto.VALOR_CREDITO))
                .ForMember(x => x.PLAZO_FINANCIEACION, map => map.MapFrom(dto => dto.PLAZO_FINANCIEACION))
                .ForMember(x => x.PORC_FINANCIACION, map => map.MapFrom(dto => dto.PORC_FINANCIACION))
                .ForMember(x => x.CAPTURA_DATOS, map => map.MapFrom(dto => dto.CAPTURA_DATOS))
                .ForMember(x => x.ACTIVIDAD_PRINCIPAL, map => map.MapFrom(dto => dto.ACTIVIDAD_PRINCIPAL))
                .ForMember(x => x.CARGA_ARCHIVO, map => map.MapFrom(dto => dto.CARGA_ARCHIVO))
                .ForMember(x => x.VISUALIZAR_ARCHIVOS, map => map.MapFrom(dto => dto.VISUALIZAR_ARCHIVOS))
                .ForMember(x => x.PUEDE_DELEGAR, map => map.MapFrom(dto => dto.PUEDE_DELEGAR))
                .ForMember(x => x.ENVIO_NITICACION, map => map.MapFrom(dto => dto.ENVIO_NITICACION))
                .ForMember(x => x.ENVIO_NOTICIACION_VENC, map => map.MapFrom(dto => dto.ENVIO_NOTICIACION_VENC))
                .ForMember(x => x.COLOR_GRILLA, map => map.MapFrom(dto => dto.COLOR_GRILLA))
                .ForMember(x => x.TRS_ID, map => map.MapFrom(dto => dto.ID_TRAMITE))
                .ForMember(x => x.PANELES, map => map.MapFrom(dto => dto.PANELES))
                .ForMember(x => x.CONSULTA_BURO, map => map.MapFrom(dto => dto.CONSULTA_BURO))
                .ForMember(x => x.CONSULTA_RIESGO, map => map.MapFrom(dto => dto.CONSULTA_RIESGO))
                .ForMember(x => x.GENERA_DOC_LEGALIZACION, map => map.MapFrom(dto => dto.GENERA_DOC_LEGALIZACION))
                .ForMember(x => x.USUARIO_RIESGO, map => map.MapFrom(dto => dto.USUARIO_RIESGO))
                .ForMember(x => x.GENERA_PDF_RESUMEN, map => map.MapFrom(dto => dto.GENERA_PDF_RESUMEN))
                // campos para cesantias
                .ForMember(x => x.clienteId, map => map.MapFrom(dto => dto.CLI_ID))
                .ReverseMap();

        }
    }
}
