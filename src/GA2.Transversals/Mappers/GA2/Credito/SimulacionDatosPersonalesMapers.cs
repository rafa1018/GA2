using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers.Credito
{
    public class SimulacionDatosPersonalesMapers : Profile
    {
        /// <summary>
        /// Mapeador entidad Simulacion Credito Datos Personales
        /// </summary>
        public SimulacionDatosPersonalesMapers()
        {
            // Dto SimulacionDatosPersomales Modelo SimulacionDatosPersomales
            CreateMap<SimulacionDatosPersonalesDto, SimulacionDatosPersonales>()
                .ForMember(source => source.SDP_ID, map => map.MapFrom(destino => destino.Id))
                .ForMember(source => source.SLS_ID, map => map.MapFrom(destino => destino.IdSimulacion))
                .ForMember(source => source.FRZ_ID, map => map.MapFrom(destino => destino.FrzId))
                .ForMember(source => source.CTG_ID, map => map.MapFrom(destino => destino.CrgId))
                .ForMember(source => source.GRD_ID, map => map.MapFrom(destino => destino.GrdId))
                .ForMember(source => source.SDP_NUMERO_DOCUMENTO, map => map.MapFrom(destino => destino.NumeroDocumento))
                .ForMember(source => source.SDP_NOMBRES_APELLIDOS, map => map.MapFrom(destino => destino.NombresApellidos))
                .ForMember(source => source.DPC_ID, map => map.MapFrom(destino => destino.DpcId))
                .ForMember(source => source.DPD_ID, map => map.MapFrom(destino => destino.DpdId))
                .ForMember(source => source.SDP_CUOTAS, map => map.MapFrom(destino => destino.Cuotas))
                .ForMember(source => source.SDP_DIRECCION, map => map.MapFrom(destino => destino.Direccion))
                .ForMember(source => source.SDP_E_MAIL, map => map.MapFrom(destino => destino.EMail))
                .ForMember(source => source.SDP_EDAD, map => map.MapFrom(destino => destino.Edad))
                .ForMember(source => source.SDP_FECHA_AFILIACION, map => map.MapFrom(destino => destino.FechaAfiliacion))
                .ForMember(source => source.SDP_REGIMEN, map => map.MapFrom(destino => destino.Regimen))
                .ForMember(source => source.SDP_TELEFONO_CELULAR, map => map.MapFrom(destino => destino.TelefonoCelular))
                .ForMember(source => source.SDP_TELEFONO_FIJO, map => map.MapFrom(destino => destino.TelefonoFijo))
                .ForMember(source => source.SDP_VALOR_INMUEBLE, map => map.MapFrom(destino => destino.ValorInmueble))
                .ForMember(source => source.TVV_ID, map => map.MapFrom(destino => destino.TvvId))
                .ForMember(source => source.DPD_ID_INMUEBLE, map => map.MapFrom(destino => destino.DpdIdInmueble))
                .ForMember(source => source.DPC_ID_INMUEBLE, map => map.MapFrom(destino => destino.DpcIdInmueble))
                .ForMember(source => source.SDP_FECHA_ACTUALIZA, map => map.MapFrom(destino => destino.FechaActualiza))
                .ForMember(source => source.SDP_USUARIO_ACTUALIZA, map => map.MapFrom(destino => destino.UsuarioActualiza))
                .ForMember(source => source.DEPARTAMENTO_RESIDENCIA, map => map.MapFrom(destino=>destino.DepartamentoResidencia))
                .ForMember(source => source.CIUDAD_RESIDENCIA, map => map.MapFrom(destino=>destino.CiudadResidencia))
                .ForMember(source => source.DEPARTAMENTO_INMIUEBLE, map => map.MapFrom(destino=>destino.DepartamentoInmueble))
                .ForMember(source => source.CIUDAD_INMUEBLE, map => map.MapFrom(destino=>destino.CiudadInmueble))
                .ForMember(source => source.FUERZA, map => map.MapFrom(destino=>destino.Fuerza))
                .ForMember(source => source.CATEGORIA, map => map.MapFrom(destino=>destino.Categoria))
                .ForMember(source => source.GRADO, map => map.MapFrom(destino=>destino.Grado))
                .ForMember(source => source.TIPO_VIVIENDA, map => map.MapFrom(destino=>destino.TipoVivienda))
                .ForMember(source => source.TPA_ID, map => map.MapFrom(destino=>destino.TipoAfiliadoId))
                .ForMember(source => source.TIPO_ACTOR, map => map.MapFrom(destino=>destino.TipoAfiliado))
                .ForMember(source => source.UNIDAD_EJECUTORA, map => map.MapFrom(destino=>destino.UnidadEjecutora))
                .ForMember(source => source.UEJ_ID, map => map.MapFrom(destino=>destino.UejId))

                .ReverseMap();
        }
    }
}
