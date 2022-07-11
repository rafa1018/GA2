using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    public class BpmProfile : Profile
    {
        public BpmProfile()
        {
            CreateMap<Procesos, ProcesoDto>();
            CreateMap<Tarea, TareaDto>();
            CreateMap<Anadidos, AnadidosDto>();
            CreateMap<Reglas, ReglasDto>();
            CreateMap<Restricciones, Restricciones>();
        }
    }
}
