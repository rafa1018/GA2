using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Transversals.Mappers.GA2
{
    public class AuditoriaMapper : Profile
    {
        public AuditoriaMapper()
        {

            CreateMap<Auditoria, AuditoriaDto>()
              .ForMember(x => x.UsurioId, map => map.MapFrom(dto => dto.USR_ID))
              .ForMember(x => x.NombreColumna, map => map.MapFrom(dto => dto.NOMBRE_COLUMNA))
              .ForMember(x => x.NombreTabla, map => map.MapFrom(dto => dto.NOMBRE_TABLA))
              .ForMember(x => x.NombreUsuario, map => map.MapFrom(dto => dto.NOMBRE_USUARIO))
              .ForMember(x => x.ValorNuevo, map => map.MapFrom(dto => dto.VALOR_NUEVO))
              .ForMember(x => x.ValorAnterior, map => map.MapFrom(dto => dto.VALOR_ANTERIOR))
              .ForMember(x => x.Agrupador, map => map.MapFrom(dto => dto.AGRUPADOR))
              .ForMember(x => x.FechaRegistro, map => map.MapFrom(dto => dto.FECHA_REGISTRO))
              .ForMember(x => x.TipoAccion, map => map.MapFrom(dto => dto.TIPO_ACCION))
              .ReverseMap();

            CreateMap<TablasAuditoria, TablasAuditoriaDto>()
             .ForMember(x => x.NombreTabla, map => map.MapFrom(dto => dto.NOMBRE_TABLA))  
             .ReverseMap();

            
        }
    }
}
