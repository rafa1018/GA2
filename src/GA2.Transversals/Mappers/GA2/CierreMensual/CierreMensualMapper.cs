using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper profile aplication BUA
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public class CierreMensualMapper : Profile
    {
        public CierreMensualMapper()
        {

            CreateMap<CierreMensual, CierreMensualDto>()
                .ForMember(x => x.IPC, map => map.MapFrom(dto => dto.IPC))
                .ForMember(x => x.ListConceptosAhorros, map => map.MapFrom(dto => dto.ListConceptosAhorros))
                .ForMember(x => x.ListConceptosCesantias, map => map.MapFrom(dto => dto.ListConceptosCesantias))
                .ForMember(x => x.CuentaAbonoAhorros, map => map.MapFrom(dto => dto.CuentaAbonoAhorros))
                .ForMember(x => x.CuentaAbonoCesantias, map => map.MapFrom(dto => dto.CuentaAbonoCesantias))
                .ReverseMap();

            CreateMap<ParametrosCierreMensual, ParametrosCierreMensualDto>()
                 .ForMember(x => x.TipoProceso, map => map.MapFrom(dto => dto.TipoProceso))
                 .ForMember(x => x.GeneraActualizacion, map => map.MapFrom(dto => dto.GeneraActualizacion))
                 .ForMember(x => x.Usuario, map => map.MapFrom(dto => dto.Usuario))
                 .ReverseMap();

            CreateMap<IPC, IPCDto>()
                 .ForMember(x => x.Anio, map => map.MapFrom(dto => dto.ANIO))
                 .ForMember(x => x.FechaActualizacion, map => map.MapFrom(dto => dto.FECHA_ACTUALIZACION))
                 .ForMember(x => x.ValorIPC, map => map.MapFrom(dto => dto.VALOR_IPC))
                 .ForMember(x => x.Mes, map => map.MapFrom(dto => dto.MES))
                 .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID))
                 .ReverseMap();

            CreateMap<ProgramacionCierreMensual, ProgramacionCierreMensualDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID))
                .ForMember(x => x.FechaCargue, map => map.MapFrom(dto => dto.FECHA_CARGUE))
                .ForMember(x => x.FechaProcesamiento, map => map.MapFrom(dto => dto.FECHA_PROCESAMIENTO))
                .ForMember(x => x.UsuarioProcesamiento, map => map.MapFrom(dto => dto.USUARIO_PROCESAMIENTO))
                .ForMember(x => x.GeneraActualizacion, map => map.MapFrom(dto => dto.GENERA_ACTUALIZACION))
                .ForMember(x => x.TipoProceso, map => map.MapFrom(dto => dto.TIPO_PROCESO))
                .ForMember(x => x.TipoProcesoDesc, map => map.MapFrom(dto => dto.TIPO_PROCESO_DESC))
                .ForMember(x => x.CuentaAbonoAhorro, map => map.MapFrom(dto => dto.CUENTA_ABONO_AHORRO))
                .ForMember(x => x.ConceptosAhorro, map => map.MapFrom(dto => dto.CONCEPTOS_AHORRO))
                .ForMember(x => x.CuentaAbonoCesantias, map => map.MapFrom(dto => dto.CUENTA_ABONO_CESANTIAS))
                .ForMember(x => x.ConceptosCesantias, map => map.MapFrom(dto => dto.CONCEPTOS_CESANTIAS))
                .ForMember(x => x.IPC, map => map.MapFrom(dto => dto.IPC))
                .ForMember(x => x.Anio, map => map.MapFrom(dto => dto.ANIO))
                .ForMember(x => x.Mes, map => map.MapFrom(dto => dto.MES))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
                .ForMember(x => x.EstadoDesc, map => map.MapFrom(dto => dto.ESTADO_DESC))
                .ReverseMap();

            CreateMap<RespuestaCierreMensual, RespuestaCierreMensualDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
                .ReverseMap();

            CreateMap<ReporteCierreMensual, ReporteCierreMensualDto>()
                .ForMember(x => x.IdProgramacion, map => map.MapFrom(dto => dto.ID_PROGRAMACION_CIERRE_MENSUAL))
                .ForMember(x => x.UnidadEjecutora, map => map.MapFrom(dto => dto.UNIDAD_EJECUTORA))
                .ForMember(x => x.UnidadEjecutoraDesc, map => map.MapFrom(dto => dto.UNIDAD_EJECUTORA_DESC))
                .ForMember(x => x.Concepto, map => map.MapFrom(dto => dto.CONCEPTO))
                .ForMember(x => x.TipoIdentificacion, map => map.MapFrom(dto => dto.CLI_ID))
                .ForMember(x => x.Identificacion, map => map.MapFrom(dto => dto.CLI_IDENTIFICACION))
                .ForMember(x => x.PrimerNombre, map => map.MapFrom(dto => dto.CLI_PRIMER_NOMBRE))
                .ForMember(x => x.SegundoNombre, map => map.MapFrom(dto => dto.CLI_SEGUNDO_NOMBRE))
                .ForMember(x => x.PrimerApellido, map => map.MapFrom(dto => dto.CLI_PRIMER_APELLIDO))
                .ForMember(x => x.SegundoApellido, map => map.MapFrom(dto => dto.CLI_SEGUNDO_APELLIDO))
                .ForMember(x => x.SaldoActual, map => map.MapFrom(dto => dto.SALDO_ACTUAL))
                .ForMember(x => x.SaldoAnterior, map => map.MapFrom(dto => dto.SALDO_ANTERIOR))
                .ForMember(x => x.SaldoInicialIntereses, map => map.MapFrom(dto => dto.SALDO_INICIAL_INTERES))
                .ForMember(x => x.SaldoInicialIngresos, map => map.MapFrom(dto => dto.SALDO_INICIAL_INGRESOS))
                .ForMember(x => x.ValorInteres, map => map.MapFrom(dto => dto.VALOR_INTERES))
                .ForMember(x => x.SaldoInteresCausado, map => map.MapFrom(dto => dto.SALDO_INTERES_CAUSADO))
                .ForMember(x => x.NuevoSaldo, map => map.MapFrom(dto => dto.NUEVO_SALDO))
                .ForMember(x => x.Periodo, map => map.MapFrom(dto => dto.PERIODO))
                .ForMember(x => x.IPC, map => map.MapFrom(dto => dto.IPC))
                .ReverseMap();

        }

    }
}
