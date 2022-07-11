using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper para validar informaciond entro del documento cargado
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    /// </summary>
    public class ParamCargueNominaMapper : Profile
    {

        public ParamCargueNominaMapper()
        {
            //Model ParamCargueNominaDTO a ParamCargueNomina
            CreateMap<ParamCargueNomDTO, ParamCargueNom>()
                .ReverseMap();


            CreateMap<AportesCategoriaClienteTmp, AportesCategoriaClienteTmpDto>()
                  .ForMember(x => x.IdRegistro, map => map.MapFrom(dto => dto.CLI_ID))
                  .ForMember(x => x.Categoria, map => map.MapFrom(dto => dto.CTG_ID))
                  .ForMember(x => x.FechaPrimeraCuota, map => map.MapFrom(dto => dto.APC_FECHA_PRIMERA_CUOTA))
                  .ForMember(x => x.FechaUltimaCuota, map => map.MapFrom(dto => dto.APC_FECHA_ULTIMA_CUOTA)).ReverseMap();
        }
    }
}
