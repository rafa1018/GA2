using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper Mensaje
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>28/05/2021</date>
    /// </summary>
    public class MapperMessage : Profile
    {
        public MapperMessage()
        {  // Model SeguroMessage Dto ParametrizacionSeguroDto

            // Model Mensaje MensajeDto
            CreateMap<Mensaje, MensajeDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.MSJ_ID))
               .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.MSJ_CODIGO))
               .ForMember(x => x.Mensaje, map => map.MapFrom(dto => dto.MSJ_MENSAJE))
               .ForMember(x => x.Tipo, map => map.MapFrom(dto => dto.MSJ_TIPO))
               .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.MSJ_CREADO_POR))
               .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.MSJ_MODIFICADO_POR))
               .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.MSJ_FECHA_CREACION))
               .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.MSJ_FECHA_MODIFICACION))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.MSJ_ESTADO))
               .ReverseMap();
        }
    }
}
