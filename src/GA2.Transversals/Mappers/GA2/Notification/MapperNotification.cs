using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper Notificacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>17/05/2021</date>
    /// </summary>
    public class MapperNotification : Profile
    {
        public MapperNotification()
        {  // Model Notification Dto ParametrizacionNotificacionDto

            // Model Notificacion NotificacionDto
            CreateMap<Notificacion, NotificacionDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.MOD_N_ID))
               .ForMember(x => x.Mensaje, map => map.MapFrom(dto => dto.MOD_N_MENSAJE))
               .ForMember(x => x.Receptor, map => map.MapFrom(dto => dto.MOD_N_RECEPTOR))
               .ForMember(x => x.Tipo, map => map.MapFrom(dto => dto.MOD_N_TIPO))
               .ForMember(x => x.Visto, map => map.MapFrom(dto => dto.MOD_N_VISTO))
               .ForMember(x => x.Emisor, map => map.MapFrom(dto => dto.MOD_N_EMISOR))
               .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.MOD_N_FECHA_CREACION))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.MOD_N_ESTADO))
               .ReverseMap();
        }
    }
}
