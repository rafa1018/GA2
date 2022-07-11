using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Dto.GrupoOpciones;
using GA2.Application.Dto.GrupoUsuarios;
using GA2.Application.Dto.Identity;
using GA2.Domain.Entities;
using GA2.Domain.Entities.GruposUsuarios;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper profile aplication Identity
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public class IdentityMapper : Profile
    {
        public IdentityMapper()
        {

            // Model User Dto Usuario
            CreateMap<User, UsuarioDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.USR_ID))
                .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.USR_NOMBRE))
                .ForMember(x => x.SegundoNombre, map => map.MapFrom(dto => dto.USR_SEGUNDONOMBRE))
                .ForMember(x => x.Apellido, map => map.MapFrom(dto => dto.USR_APELLIDO))
                .ForMember(x => x.SegundoApellido, map => map.MapFrom(dto => dto.USR_SEGUNDOAPELLIDO))
                .ForMember(x => x.NombreUsuario, map => map.MapFrom(dto => dto.USR_USERNAME))
                .ForMember(x => x.Correo, map => map.MapFrom(dto => dto.USR_EMAIL))
                .ForMember(x => x.Contrasena, map => map.MapFrom(dto => dto.USR_PASSWORD))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.USR_EMAIL))
                .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.USR_MODIFICADOPOR))
                .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.USR_FECHAMODIFICACION))
                .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.USR_CREADOPOR))
                .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.USR_FECHACREACION))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.USR_ESTADO))
                .ForMember(x => x.Identificacion, map => map.MapFrom(dto => dto.USR_IDENTIFICACION))
                .ForMember(x => x.TipoIdentificationCode, map => map.MapFrom(dto => dto.TID_CODIGO))   
                .ForMember(x => x.TipoIdentificationId, map => map.MapFrom(dto => dto.TID_ID))
                .ForMember(x => x.Directory, map => map.MapFrom(dto => dto.ACTIVE_DIRECTORY));


            // Model LoginCommand Dto USer
            CreateMap<LoginDto, User>()
                .ForMember(x => x.USR_USERNAME, map => map.MapFrom(dto => dto.UserName))
                .ForMember(x => x.USR_PASSWORD, map => map.MapFrom(dto => dto.Password));

            // Model LoginCommand Dto USer
            CreateMap<Cliente, LoginPaaDto>()
                .ForMember(x => x.TipoDocumento, map => map.MapFrom(dto => dto.TID_ID))
                .ForMember(x => x.NumeroIdentificacion, map => map.MapFrom(dto => dto.CLI_IDENTIFICACION))
                .ForMember(x => x.FechaExpedicion, map => map.MapFrom(dto => dto.CLI_FECHA_EXPEDICION))
                .ForMember(x => x.NumeroCelular, map => map.MapFrom(dto => dto.DTL_TELEFONO)).ReverseMap();

            CreateMap<Menu, MenuDto>()
               .ForMember(x => x.Id, map => map.MapFrom(dto => dto.MNU_ID))
               .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.MNU_DESCRIPCION))
               .ForMember(x => x.AplicacionId, map => map.MapFrom(dto => dto.APP_ID))
               .ForMember(x => x.Visible, map => map.MapFrom(dto => dto.MNU_VISIBLE))
               .ForMember(x => x.Link, map => map.MapFrom(dto => dto.MNU_LINK))
               .ForMember(x => x.Icono, map => map.MapFrom(dto => dto.MNU_ICONO))
               .ForMember(x => x.SubMenus, map => map.MapFrom(dto => dto.MNU_SUBMENUS))
               .ForMember(x => x.FormularioId, map => map.MapFrom(dto => dto.FRM_ID))
               .ForMember(x => x.Formulario, map => map.MapFrom(dto => dto.FRM_FORMULARIO))
               .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.MNU_MODIFICADOPOR))
               .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.MNU_FECHAMODIFICACION))
               .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.MNU_CREADOPOR))
               .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.MNU_FECHACREACION))
               .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.MNU_ESTADO)).ReverseMap();

            CreateMap<SubMenu, SubMenuDto>()
                   .ForMember(x => x.Id, map => map.MapFrom(dto => dto.MNU_ID))
                   .ForMember(x => x.MenuId, map => map.MapFrom(dto => dto.SBM_ID))
                   .ForMember(x => x.Link, map => map.MapFrom(dto => dto.SBM_LINK))
                   .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.SBM_DESCRIPCION))
                   .ForMember(x => x.Visible, map => map.MapFrom(dto => dto.SBM_VISIBLE))
                   .ForMember(x => x.Formulario, map => map.MapFrom(dto => dto.SBM_FORMULARIO))
                   .ForMember(x => x.FormularioId, map => map.MapFrom(dto => dto.FRM_ID))
                   .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.SBM_MODIFICADOPOR))
                   .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.SBM_FECHAMODIFICACION))
                   .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.SBM_CREADOPOR))
                   .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.SBM_FECHACREACION))
                   .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.SBM_ESTADO)).ReverseMap();

            CreateMap<Rol, RolDto>()
                .ForMember(source => source.Id, map => map.MapFrom(destino => destino.RL_ID))
                .ForMember(source => source.Descripcion, map => map.MapFrom(destino => destino.RL_DESCRIPCION))
                .ForMember(source => source.CreadoPor, map => map.MapFrom(destino => destino.RL_CREADOPOR))
                .ForMember(source => source.FechaCreacion, map => map.MapFrom(destino => destino.RL_FECHACREACION))
                .ForMember(source => source.ModificadoPor, map => map.MapFrom(destino => destino.RL_MODIFICADOPOR))
                .ForMember(source => source.FechaModificacion, map => map.MapFrom(destino => destino.RL_FECHAMODIFICACION))
                .ForMember(source => source.Estado, map => map.MapFrom(destino => destino.RL_ESTADO)).ReverseMap();

            CreateMap<Formulario, FormularioDto>()
                .ForMember(source => source.Id, map => map.MapFrom(destino => destino.FRM_ID))
                .ForMember(source => source.Descripcion, map => map.MapFrom(destino => destino.FRM_DESCRIPCION))
                .ForMember(source => source.SubMenuId, map => map.MapFrom(destino => destino.SBM_ID))
                .ForMember(source => source.Visible, map => map.MapFrom(destino => destino.FRM_VISIBLE))
                .ForMember(source => source.ModificadoPor, map => map.MapFrom(destino => destino.FRM_MODIFICADOPOR))
                .ForMember(source => source.FechaModificacion, map => map.MapFrom(destino => destino.FRM_FECHAMODIFICACION))
                .ForMember(source => source.CreadoPor, map => map.MapFrom(destino => destino.FRM_CREADOPOR))
                .ForMember(source => source.FechaCreacion, map => map.MapFrom(destino => destino.FRM_FECHACREACION))
                .ForMember(source => source.Estado, map => map.MapFrom(destino => destino.FRM_ESTADO)).ReverseMap();


            CreateMap<GrupoUsuario, GruposUsuariosDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID))
                .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
                .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.CODIGO))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.DESCRIPCION));


            CreateMap<GrupoOpciones, GrupoOpcionesDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID))
                .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
                .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.CODIGO))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.DESCRIPCION));


            CreateMap<GrupoOpciones, OpcionesDto>()
              .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID))
              .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
              .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.CODIGO))
              .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
              .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.DESCRIPCION));


           


        }
    }
}
