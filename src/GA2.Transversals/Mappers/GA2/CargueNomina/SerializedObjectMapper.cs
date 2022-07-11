using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Maper para archivo json que se envía a la BD
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    /// </summary>
    public class SerializedObjectMapper : Profile
    {
        public SerializedObjectMapper()
        {
            //Model ObjetoSerializadoDTO ObjetoSerializado
            CreateMap<ObjetoSerializadoDTO, ObjetoSerializado>()
                    .ForMember(x => x.Json, map => map.MapFrom(dto => dto.Json))
                    .ReverseMap();
        }

    }
}
