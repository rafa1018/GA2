using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    public class EntidadesMapper : Profile
    {
        public EntidadesMapper()
        {
            // Model SedeEntidadEducativaDto SedesEntidadEducativa
            CreateMap<SedeEntidadEducativa, SedeEntidadEducativaDto>()
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.CiudadId, map => map.MapFrom(dto => dto.SNE_SEDE_DPC_ID))
                .ForMember(x => x.IdSedeEntidad, map => map.MapFrom(dto => dto.SNE_SEDE_ID))
                .ForMember(x => x.NombreSede, map => map.MapFrom(dto => dto.SNE_SEDE_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.SNE_SEDE_ESTADO))
                .ReverseMap();

            //// Model EntidadEducativaDto EntidadEducativa
            CreateMap<EntidadEducativa, EntidadEducativaDto>()
                    .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                    .ForMember(x => x.TipoIdentificacion, map => map.MapFrom(dto => dto.ENE_TIPO_IDENTIFICACION))
                    .ForMember(x => x.Nit, map => map.MapFrom(dto => dto.ENE_NIT))
                    .ForMember(x => x.RazonSocial, map => map.MapFrom(dto => dto.ENE_NOMBRE_RAZON_SOCIAL))
                    .ForMember(x => x.CorreoElectronico, map => map.MapFrom(dto => dto.ENE_CORREO_ELECTRONICO))
                    .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.ENE_DPC_ID))
                    .ForMember(x => x.Direccion, map => map.MapFrom(dto => dto.ENE_DIRECCION))
                    .ForMember(x => x.Telefono, map => map.MapFrom(dto => dto.ENE_TELEFONO))
                    .ForMember(x => x.Contacto, map => map.MapFrom(dto => dto.ENE_NOMBRE_CONTACTO))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ENE_ESTADO))
                    .ReverseMap();

            // Model ProgramaEducativoDto ProgramaEducativo
            CreateMap<ProgramaEducativo, ProgramaEducativoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PGE_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.PGE_DESCRIPCION))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PGE_ESTADO))
                    .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.PGE_CREATEDOPOR))
                    .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.PGE_FECHACREACION))
                    .ForMember(x => x.ModificacionPor, map => map.MapFrom(dto => dto.PGE_MODIFICADOPOR))
                    .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PGE_FECHAMODIFICACION))
                    .ReverseMap();

            // Model ListarProgramaEducativoDto ListarProgramaEducativo
            CreateMap<ListarProgramaEducativo, ListarProgramaEducativoDto>()
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.RazonSocialEntidad, map => map.MapFrom(dto => dto.ENE_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.IdPrograma, map => map.MapFrom(dto => dto.PGE_ID))
                .ForMember(x => x.Programa, map => map.MapFrom(dto => dto.PGE_DESCRIPCION))
                .ForMember(x => x.NivelEducativoId, map => map.MapFrom(dto => dto.NVE_ID))
                .ForMember(x => x.NivelEducativo, map => map.MapFrom(dto => dto.NVE_DESCRIPCION))
                .ReverseMap();

            // Model NivelEducativoDto NivelEducativo
            CreateMap<NivelEducativo, NivelEducativoDto>()
                    .ForMember(x => x.id, map => map.MapFrom(dto => dto.PRN_ID))
                    .ForMember(x => x.descripcion, map => map.MapFrom(dto => dto.NVE_DESCRIPCION))
                    .ReverseMap();


            // Model BloqueoEntidadEducativaDto BloqueoEntidadEducativa
            CreateMap<BloqueoEntidadEducativa, BloqueoEntidadEducativaDto>()
                .ForMember(x => x.IdBloqueo, map => map.MapFrom(dto => dto.ENE_BLOQUEO))
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.IdTipoOperacion, map => map.MapFrom(dto => dto.ENE_TIPO_OPERACION))
                .ForMember(x => x.IdCausalBloqueo, map => map.MapFrom(dto => dto.ENE_CAUSAL_BLOQUEO))
                .ForMember(x => x.FechaBloqueo, map => map.MapFrom(dto => dto.ENE_FECHA_BLOQUEO))
                .ForMember(x => x.FuncionarioBloqueo, map => map.MapFrom(dto => dto.ENE_FUNCIONARIO_BLOQUEO))
                .ReverseMap();
        }
    }
}
