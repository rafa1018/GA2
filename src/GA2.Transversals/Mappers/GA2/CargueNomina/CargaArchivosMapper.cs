using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper del documento cargado para validar nombre del archivo
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    /// </summary>
    public class CargaArchivosMapper : Profile
    {
        public CargaArchivosMapper()
        {
            //model TipoArchivo TypeFile
            CreateMap<NombreArchivoDto, NombreArchivoDto>()
                .ForMember(x => x.FILE_TIPO, map => map.MapFrom(dto => dto.FILE_TIPO))
                .ForMember(x => x.FILE_CATEGORIA, map => map.MapFrom(dto => dto.FILE_CATEGORIA))
                .ForMember(x => x.FILE_PERIODOS_APORTES, map => map.MapFrom(dto => dto.FILE_PERIODOS_APORTES))
                .ForMember(x => x.FILE_UNIDAD_EJECUTORA, map => map.MapFrom(dto => dto.FILE_UNIDAD_EJECUTORA))
                .ForMember(x => x.FILE_FECHA_ENVIO, map => map.MapFrom(dto => dto.FILE_FECHA_ENVIO));


            CreateMap<Ejecutor, EjecutorDto>()
                .ForMember(x => x.DCT_FECHA_INCIAL, map => map.MapFrom(dto => dto.DCT_FECHA_INCIAL))
                .ForMember(x => x.DCT_ID, map => map.MapFrom(dto => dto.DCT_ID))
                .ForMember(x => x.FILE_CATEGORIA, map => map.MapFrom(dto => dto.FILE_CATEGORIA))
                .ForMember(x => x.FILE_TIPO, map => map.MapFrom(dto => dto.FILE_TIPO))
                .ForMember(x => x.FILE_UNIDAD_EJECUTORA, map => map.MapFrom(dto => dto.FILE_UNIDAD_EJECUTORA))
                .ForMember(x => x.FILE_PERIODOS_APORTES, map => map.MapFrom(dto => dto.FILE_PERIODOS_APORTES))
                .ReverseMap();
            CreateMap<VerificarAfiliado, VerificarAfiliadoDTO>()
                .ForMember(x => x.ClienteId, map => map.MapFrom(dto => dto.CLI_ID))
                .ForMember(x => x.TipoCuentaId, map => map.MapFrom(dto => dto.TCT_ID))
                .ForMember(x => x.EstadodCuentaId, map => map.MapFrom(dto => dto.ECT_ID))
                .ForMember(x => x.CausalEstadId, map => map.MapFrom(dto => dto.CCN_ID))
                .ForMember(x => x.NumeroDocumetoId, map => map.MapFrom(dto => dto.DCT_ID))
                .ForMember(x => x.CuentaFechaCreacion, map => map.MapFrom(dto => dto.CTA_FECHA_CREACION))
                .ForMember(x => x.CuentaFechaCierre, map => map.MapFrom(dto => dto.CTA_FECHA_CIERRE))
                .ForMember(x => x.CuentaFechaPrimerAporte, map => map.MapFrom(dto => dto.CTA_FECHA_PRIMER_APORTE))
                .ForMember(x => x.CuentaSaldo, map => map.MapFrom(dto => dto.CTA_SALDO))
                .ForMember(x => x.CuentaSaldoCanje, map => map.MapFrom(dto => dto.CTA_SALDO_CANJE))
                .ForMember(x => x.CcuentaSaldoDisponible, map => map.MapFrom(dto => dto.CTA_SALDO_DISPONIBLE))
                .ForMember(x => x.CuentaCuotas, map => map.MapFrom(dto => dto.CTA_CUOTAS))
                .ForMember(x => x.MovimientoValor, map => map.MapFrom(dto => dto.MVT_VALOR))
                .ForMember(x => x.TipoMovimiento, map => map.MapFrom(dto => dto.CAT_TIPO_MOVIMIENTO))
                .ForMember(x => x.MovimientoFechaProceso, map => map.MapFrom(dto => dto.MVT_FECHA_PROCESO))
                .ForMember(x => x.MovimientoAnoPeriodo, map => map.MapFrom(dto => dto.MVT_ANO_PERIODO))
                .ForMember(x => x.FechaMovimiento, map => map.MapFrom(dto => dto.MVT_FECHA_MOVIMIENTO))
                .ReverseMap();
            CreateMap<AfiliadoporIdentificacion, AfiliadoporIdentificacionDTO>()
                .ForMember(x => x.NumeroIidentificacion, map => map.MapFrom(dto => dto.CLI_IDENTIFICACION))
                .ForMember(x => x.IdCliente, map => map.MapFrom(dto => dto.CLI_ID))
                .ReverseMap();

        }
    }
}
