using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper profile aplication Identity
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public class MapperParametrization : Profile
    {
        public MapperParametrization()
        {  // Model SeguroParametrization Dto ParametrizacionSeguroDto
            CreateMap<SeguroParametrizacion, ParametrizacionSeguroDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_SEG_ID))
                .ForMember(x => x.SeguroVida, map => map.MapFrom(dto => dto.PAR_VIDA))
                .ForMember(x => x.SeguroTodoRiesgo, map => map.MapFrom(dto => dto.PAR_TODO_RIESGO))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model TasaParametrization Dto ParametrizacionTasaDto
            CreateMap<TasaParametrizacion, ParametrizacionTasaDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_TAS_ID))
                .ForMember(x => x.TasaUsuraEA, map => map.MapFrom(dto => dto.PAR_USURA_EA))
                .ForMember(x => x.TasaUsuraNM, map => map.MapFrom(dto => dto.PAR_USURA_NM))
                .ForMember(x => x.TasaCorrienteEA, map => map.MapFrom(dto => dto.PAR_CORRIENTE_EA))
                .ForMember(x => x.TasaCorrienteNM, map => map.MapFrom(dto => dto.PAR_CORRIENTE_NM))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model PlazoParametrization Dto ParametrizacionPlazosDto
            CreateMap<PlazoParametrizacion, ParametrizacionPlazosDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_PLA_ID))
                .ForMember(x => x.YearMin, map => map.MapFrom(dto => dto.PAR_YEAR_MIN))
                .ForMember(x => x.MonthMin, map => map.MapFrom(dto => dto.PAR_MONTH_MIN))
                .ForMember(x => x.YearMax, map => map.MapFrom(dto => dto.PAR_YEAR_MAX))
                .ForMember(x => x.MonthMax, map => map.MapFrom(dto => dto.PAR_MONTH_MAX))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model LegalTasaParametrization Dto ParametrizacionLegalTasaDto
            CreateMap<LegalTasaParametrizacion, ParametrizacionLegalTasaDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_LET_ID))
                .ForMember(x => x.TasaFrech, map => map.MapFrom(dto => dto.PAR_TASA_FRECH))
                .ForMember(x => x.VigenciaTasaFrech, map => map.MapFrom(dto => dto.PAR_VIGENCIA_TASA_FRECH))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model LegalAlivioParametrization Dto ParametrizacionLegalAlivioDto
            CreateMap<LegalAlivioParametrizacion, ParametrizacionLegalAlivioDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_LEA_ID))
                .ForMember(x => x.AlivioCuota, map => map.MapFrom(dto => dto.PAR_ALIVIO_CUOTA))
                .ForMember(x => x.VigenciaAlivioCuota, map => map.MapFrom(dto => dto.PAR_VIGENCIA_ALIVIO_CUOTA))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model LegalGmfParametrization Dto ParametrizacionLegalGmfDto
            CreateMap<LegalGmfParametrizacion, ParametrizacionLegalGmfDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_LEG_ID))
                .ForMember(x => x.Gmf, map => map.MapFrom(dto => dto.PAR_GMF))
                .ForMember(x => x.VigenciaGmf, map => map.MapFrom(dto => dto.PAR_VIGENCIA_GMF))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model LiquidacionParametrization Dto ParametrizacionLiquidacionDto
            CreateMap<LiquidacionParametrizacion, ParametrizacionLiquidacionDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_LIQ_ID))
                .ForMember(x => x.FechaCorte, map => map.MapFrom(dto => dto.PAR_FECHA_CORTE))
                .ForMember(x => x.FechaPago, map => map.MapFrom(dto => dto.PAR_FECHA_PAGO))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PAR_ESTADO))
                .ReverseMap();

            // Model Estado EstadoDto
            CreateMap<Estado, EstadoDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.EST_ID))
               .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.EST_CODIGO))
               .ForMember(x => x.Concepto, map => map.MapFrom(dto => dto.EST_CONCEPTO))
               .ForMember(x => x.DiasMoraActivaEstado, map => map.MapFrom(dto => dto.EST_DIAS_MORA_ACTIVA_ESTADO))
               .ForMember(x => x.SaldoDeuda, map => map.MapFrom(dto => dto.EST_SALDO_DEUDA))
               .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.EST_FECHA_MODIFICACION))
               .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.EST_MODIFICADO_POR))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.EST_ESTADO))
               .ReverseMap();

            // Model ParametroTransaccion ParametroTransaccionDto
            CreateMap<ParametroTransaccion, ParametroTransaccionDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PAR_TRA_ID))
               .ForMember(x => x.Concepto, map => map.MapFrom(dto => dto.PAR_CONCEPTO))
               .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.PAR_CODIGO))
               .ForMember(x => x.Proceso, map => map.MapFrom(dto => dto.PAR_PROCESO))
               .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.PAR_CREADO_POR))
               .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.PAR_FECHA_CREACION))
               .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.PAR_MODIFICADO_POR))
               .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PAR_FECHA_MODIFICACION))
               .ReverseMap();


            // Model ParametrizacionArchivoModalidad ParametrizacionArchivoModalidadDto
            CreateMap<ParametrizacionArchivoModalidad, ParametrizacionArchivoModalidadDto>()
               .ForMember(x => x.parametrizacionId, map => map.MapFrom(dto => dto.PAM_ID))
               .ForMember(x => x.nombreArchivo, map => map.MapFrom(dto => dto.PAM_NOMBRE_ARCHIVO))
               .ForMember(x => x.descripcionArchivo, map => map.MapFrom(dto => dto.PAM_DESCRIPCION_ARCHIVO))
               .ForMember(x => x.estadoRequerido, map => map.MapFrom(dto => dto.PAM_REQUERIDO))
               .ForMember(x => x.estadoActivo, map => map.MapFrom(dto => dto.PAM_ESTADO))
               .ForMember(x => x.ordenamiento, map => map.MapFrom(dto => dto.PAM_ORDEN))
               .ReverseMap();

            // Model ParametrizacionArchivoEntidadEducativa ParametrizacionArchivoEntidadEducativaDto
            CreateMap<ParametrizacionArchivoEntidadEducativa, ParametrizacionArchivoEntidadEducativaDto>()
               .ForMember(x => x.IdParametrizacion, map => map.MapFrom(dto => dto.ENE_PAM_ID))
               .ForMember(x => x.NombreArchivo, map => map.MapFrom(dto => dto.ENE_PAM_NOMBRE_ARCHIVO))
               .ForMember(x => x.DescripcionArchivo, map => map.MapFrom(dto => dto.ENE_PAM_DESCRIPCION_ARCHIVO))
               .ForMember(x => x.EstadoRequerido, map => map.MapFrom(dto => dto.ENE_PAM_REQUERIDO))
               .ForMember(x => x.EstadoActivo, map => map.MapFrom(dto => dto.ENE_PAM_ESTADO))
               .ForMember(x => x.Ordenamiento, map => map.MapFrom(dto => dto.ENE_PAM_ORDEN))
               .ReverseMap();

        }
    }
}
