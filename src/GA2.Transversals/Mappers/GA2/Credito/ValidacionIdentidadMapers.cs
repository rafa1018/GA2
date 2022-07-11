using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Dto.Credito.Simulador;
using GA2.Domain.Entities;
using GA2.Domain.Entities.Credito.Simulador;

namespace GA2.Transversals.Mappers.Credito
{
    /// <summary>
    /// Mapeador entidad Validacion de Identidad
    /// </summary>
    public class ValidacionIdentidadMapers : Profile
    {
        public ValidacionIdentidadMapers()
        {
            // Dto ValidacionIdentidadDto Modelo ValidacionIdentidad
            CreateMap<ValidacionIdentidadDto, ValidacionIdentidad>()
                .ForMember(source => source.VLI_ID, map => map.MapFrom(destino => destino.Id))
                .ForMember(source => source.TID_ID, map => map.MapFrom(destino => destino.TidId))
                .ForMember(source => source.VLI_NUMERO_DOCUMENTO, map => map.MapFrom(destino => destino.NumeroDocumento))
                .ForMember(source => source.VLI_NUMERO_CELULAR, map => map.MapFrom(destino => destino.NumeroCelular))
                .ForMember(source => source.VLI_ACEPTA_HABEAS, map => map.MapFrom(destino => destino.AceptaHabeas))
                .ForMember(source => source.VLI_ACEPTA_TERMINOS, map => map.MapFrom(destino => destino.AceptaTerminos))
                .ForMember(source => source.VLI_FECHA_EXPEDICION, map => map.MapFrom(destino => destino.FechaExpedicion))
                .ForMember(source => source.VLI_FECHA_VALIDA_IDEN, map => map.MapFrom(destino => destino.FechaValidaIdentidad))
                .ForMember(source => source.VLI_FECHA_VALIDA_OTP, map => map.MapFrom(destino => destino.FechaValidaOtp))
                .ForMember(source => source.VLI_CODIGO_OTP, map => map.MapFrom(destino => destino.CodigoOtp))
                .ForMember(source => source.VLI_PASO_VALIDACION, map => map.MapFrom(destino => destino.PasoValidacion))
                .ForMember(source => source.VLI_FECHA_ACTUALIZA, map => map.MapFrom(destino => destino.FechaActualiza))
                .ForMember(source => source.VLI_USUARIO_ACTUALIZA, map => map.MapFrom(destino => destino.UsuarioActualiza))
                .ForMember(source => source.VALOR_PRESTAMO, map => map.MapFrom(destino => destino.ValorPrestamo))
                .ForMember(source => source.VALOR_VIVIENDA, map => map.MapFrom(destino => destino.ValorVivienda))
                .ForMember(source => source.TIPO_VIVIENDA, map => map.MapFrom(destino => destino.TipoVivienda))
                .ForMember(source => source.VIVIENDA_VIS, map => map.MapFrom(destino => destino.ViviendaVis));

            // Modelo ValidacionIdentidad ValidacionIdentidadDto
            CreateMap<ValidacionIdentidad, ValidacionIdentidadDto>()
                .ForMember(source => source.Id, map => map.MapFrom(destino => destino.VLI_ID))
                .ForMember(source => source.TidId, map => map.MapFrom(destino => destino.TID_ID))
                .ForMember(source => source.NumeroDocumento, map => map.MapFrom(destino => destino.VLI_NUMERO_DOCUMENTO))
                .ForMember(source => source.NumeroCelular, map => map.MapFrom(destino => destino.VLI_NUMERO_CELULAR))
                .ForMember(source => source.AceptaHabeas, map => map.MapFrom(destino => destino.VLI_ACEPTA_HABEAS))
                .ForMember(source => source.AceptaTerminos, map => map.MapFrom(destino => destino.VLI_ACEPTA_TERMINOS))
                .ForMember(source => source.FechaExpedicion, map => map.MapFrom(destino => destino.VLI_FECHA_EXPEDICION))
                .ForMember(source => source.FechaValidaIdentidad, map => map.MapFrom(destino => destino.VLI_FECHA_VALIDA_IDEN))
                .ForMember(source => source.FechaValidaOtp, map => map.MapFrom(destino => destino.VLI_FECHA_VALIDA_OTP))
                .ForMember(source => source.CodigoOtp, map => map.MapFrom(destino => destino.VLI_CODIGO_OTP))
                .ForMember(source => source.PasoValidacion, map => map.MapFrom(destino => destino.VLI_PASO_VALIDACION))
                .ForMember(source => source.FechaActualiza, map => map.MapFrom(destino => destino.VLI_FECHA_ACTUALIZA))
                .ForMember(source => source.UsuarioActualiza, map => map.MapFrom(destino => destino.VLI_USUARIO_ACTUALIZA))
                .ForMember(source => source.ValorPrestamo, map => map.MapFrom(destino => destino.VALOR_PRESTAMO))
                .ForMember(source => source.ValorVivienda, map => map.MapFrom(destino => destino.VALOR_VIVIENDA))
                .ForMember(source => source.TipoVivienda, map => map.MapFrom(destino => destino.TIPO_VIVIENDA))
                .ForMember(source => source.ViviendaVis, map => map.MapFrom(destino => destino.VIVIENDA_VIS));              

            /// Parametros Simulador
            CreateMap<ParametrosSimulador, ParametrosSimuladorDto>()
                .ForMember(source => source.SalarioMinimoLV, map => map.MapFrom(destino => destino.PRM_SMLV))
                .ForMember(source => source.DiasValidoPreaprobado, map => map.MapFrom(destino => destino.PRM_DIAS_VALIDO_PREAPROB))
                .ForMember(source => source.PorcLeyVivienda, map => map.MapFrom(destino => destino.PRM_PORC_LEY_LIBRANZA))
                .ForMember(source => source.ScoreMinimo, map => map.MapFrom(destino => destino.PRM_SCORE_MINIMO))
                .ForMember(source => source.PorcCapacidadEndeudamiento, map => map.MapFrom(destino => destino.PRM_PORC_CAPACIDAD_ENDEUDA)).ReverseMap();

        }
    }
}
