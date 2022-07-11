using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper bloqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>05/05/2021</date>
    /// </summary>
    public class MapperLock : Profile
    {
        public MapperLock()
        {  // Model SeguroLock Dto ParametrizacionSeguroDto

            // Model Bloqueo BloqueoDto
            CreateMap<Bloqueo, BloqueoDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.MOD_B_ID))
               .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.MOD_B_CODIGO))
               .ForMember(x => x.Concepto, map => map.MapFrom(dto => dto.MOD_B_CONCEPTO))
               .ForMember(x => x.DiasMora, map => map.MapFrom(dto => dto.MOD_B_DIAS_MORA))
               .ForMember(x => x.Reversible, map => map.MapFrom(dto => dto.MOD_B_REVERSIBLE))
               .ForMember(x => x.AceleracionDeuda, map => map.MapFrom(dto => dto.MOD_B_ACELERACION_DEUDA))
               .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.MOD_B_FECHA_MODIFICACION))
               .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.MOD_B_MODIFICADO_POR))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.MOD_B_ESTADO))
               .ReverseMap();
        }
    }
}
