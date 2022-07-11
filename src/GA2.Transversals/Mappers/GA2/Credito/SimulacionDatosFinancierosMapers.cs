using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers.Credito
{
    public class SimulacionDatosFinancierosMapers : Profile
    {
        /// <summary>
        /// Mapeador entidad Simulacion Credito Datos Personales
        /// Autor: John Byron Agudelo Gonzalez
        /// Fecha: 10/05/2021
        /// </summary>
        public SimulacionDatosFinancierosMapers()
        {
            // Dto SimulacionDatosFinancieros - SimulacionDatosFinancierosDto
            CreateMap<SimulacionDatosFinancierosDto, SimulacionDatosFinancieros>()
                .ForMember(source => source.SDF_ID, map => map.MapFrom(destino => destino.Id))
                .ForMember(source => source.SLS_ID, map => map.MapFrom(destino => destino.IdSimulacion))
                .ForMember(source => source.SDF_DESCRIPCION_SALARIO, map => map.MapFrom(destino => destino.DescripcionSalario))
                .ForMember(source => source.SDF_VALOR_SALARIO, map => map.MapFrom(destino => destino.ValorSalario))
                .ForMember(source => source.SDF_DESCRIPCION_OTRO_INGRESOS, map => map.MapFrom(destino => destino.DescripcionOtroIngresos))
                .ForMember(source => source.SDF_VALOR_OTROS_INGRESOS, map => map.MapFrom(destino => destino.ValorOtrosIngresos))
                .ForMember(source => source.SDF_DESCRIPCION_OTRO_ING1, map => map.MapFrom(destino => destino.DescripcionOtroIng1))
                .ForMember(source => source.SDF_VALOR_OTROS_INGRESOS1, map => map.MapFrom(destino => destino.ValorOtrosIngresos1))
                .ForMember(source => source.SDF_DESCRIPCION_OTRO_ING2, map => map.MapFrom(destino => destino.DescripcionOtroIng2))
                .ForMember(source => source.SDF_VALOR_OTROS_INGRESOS2, map => map.MapFrom(destino => destino.ValorOtrosIngresos2))
                .ForMember(source => source.SDF_DESCRIPCION_OTRO_ING3, map => map.MapFrom(destino => destino.DescripcionOtroIng3))
                .ForMember(source => source.SDF_VALOR_OTROS_INGRESOS3, map => map.MapFrom(destino => destino.ValorOtrosIngresos3))
                .ForMember(source => source.SDF_DESCRIPCION_OTRO_ING4, map => map.MapFrom(destino => destino.DescripcionOtroIng4))
                .ForMember(source => source.SDF_VALOR_OTROS_INGRESOS4, map => map.MapFrom(destino => destino.ValorOtrosIngresos4))
                .ForMember(source => source.SDF_DESCRIPCION_OTRO_ING5, map => map.MapFrom(destino => destino.DescripcionOtroIng5))
                .ForMember(source => source.SDF_VALOR_OTROS_INGRESOS5, map => map.MapFrom(destino => destino.ValorOtrosIngresos5))
                .ForMember(source => source.SDF_VALOR_TOTAL_INGRESOS, map => map.MapFrom(destino => destino.ValorTotalIngresos))
                .ForMember(source => source.SDF_VALOR_TOTAL_EGRESOS, map => map.MapFrom(destino => destino.ValorTotalEgresos))
                .ForMember(source => source.SDF_USUARIO_ACTUALIZA, map => map.MapFrom(destino => destino.UsuarioActualiza))
                .ForMember(source => source.SDF_FECHA_ACTUALIZA, map => map.MapFrom(destino => destino.FechaActualiza)).ReverseMap();
        }
    }
}
