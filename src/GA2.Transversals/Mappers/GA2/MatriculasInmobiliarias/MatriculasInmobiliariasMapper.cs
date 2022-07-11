using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Transversals.Mappers
{ 
    public class MatriculasInmobiliariasMapper : Profile
    {

        public MatriculasInmobiliariasMapper() {

            CreateMap<MatriculaInmibiliaria, MatriculaInmibiliariaDto>()
                .ForMember(x => x.MaiId, map => map.MapFrom(dto => dto.MAI_ID))
                .ForMember(x => x.MaiNumeroMatricula, map => map.MapFrom(dto => dto.MAI_NUMERO_MATRICULA))
                .ForMember(x => x.MaiDireccion, map => map.MapFrom(dto => dto.MAI_DIRECCION))
                .ForMember(x => x.MaiFechaRegistro, map => map.MapFrom(dto => dto.MAI_FECHA_REGISTRO))
                .ForMember(x => x.DpdId, map => map.MapFrom(dto => dto.DPD_ID_FK))
                .ForMember(x => x.DcpId, map => map.MapFrom(dto => dto.DPC_ID_FK))
                .ForMember(x => x.PrpNombreRazonSocial, map => map.MapFrom(dto => dto.PRP_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.PrpNumeroIdentificacion, map => map.MapFrom(dto => dto.PRP_NUMERO_IDENTIFICACION))
                .ForMember(x => x.PrpTipoIdentificacion, map => map.MapFrom(dto => dto.PRP_TIPO_IDENTIFICACION))
                .ReverseMap();

            CreateMap<PropietariosMatriculasInmobiliarias, PropietariosMatriculasInmobiliariasDto>()
                .ForMember(x => x.MaiId, map => map.MapFrom(dto => dto.MAI_ID))
                .ForMember(x => x.PrpId, map => map.MapFrom(dto => dto.PRP_ID))
                .ForMember(x => x.PrpNombreRazonSocial, map => map.MapFrom(dto => dto.PRP_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.PrpIdTipoIdentificacion, map => map.MapFrom(dto => dto.TID_ID))
                .ForMember(x => x.PrpTipoIdentificacion, map => map.MapFrom(dto => dto.PRP_TIPO_IDENTIFICACION))
                .ForMember(x => x.PrpNumeroIdentificacion, map => map.MapFrom(dto => dto.PRP_NUMERO_IDENTIFICACION))
                .ForMember(x => x.Correo, map => map.MapFrom(dto => dto.CORREO))
                .ForMember(x => x.Telefono, map => map.MapFrom(dto => dto.TELEFONO))
                .ReverseMap();


            CreateMap<NovedadesMatriculasInmobiliarias, NovedadesMatriculasInmobiliariasDto>()
                .ForMember(x => x.MatriculaId, map => map.MapFrom(dto => dto.MAI_ID))
                .ForMember(x => x.FechaNovedad, map => map.MapFrom(dto => dto.NVM_FECHA_NOVEDAD))
                .ForMember(x => x.CausalId, map => map.MapFrom(dto => dto.CAN_ID))
                .ForMember(x => x.SolicitudId, map => map.MapFrom(dto => dto.SOL_ID))
                .ForMember(x => x.UserCreadorId, map => map.MapFrom(dto => dto.NVM_CREATEDOPOR))
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.NVM_ID))
                .ForMember(x => x.TipoOperacionId, map => map.MapFrom(dto => dto.TOP_ID))
                .ForMember(x => x.TipoSolicitudId, map => map.MapFrom(dto => dto.TSN_ID))
                .ReverseMap();

            CreateMap<HistotialNovedadesMatriculasInmobiliarias, HistotialNovedadesMatriculasInmobiliariasDto>()
              .ForMember(x => x.CausalId, map => map.MapFrom(dto => dto.CAUSAL_ID))
              .ForMember(x => x.FechaNovedad, map => map.MapFrom(dto => dto.FECHA_NOVEDAD))
              .ForMember(x => x.Causal, map => map.MapFrom(dto => dto.CAUSAL))
              .ForMember(x => x.TipoSolicitud, map => map.MapFrom(dto => dto.TIPO_SOLICITUD))
              .ForMember(x => x.TipoOperacion, map => map.MapFrom(dto => dto.TIPO_OPERACION))
              .ForMember(x => x.TipoSolicitudId, map => map.MapFrom(dto => dto.TIPO_SOLICITUD_ID))
              .ForMember(x => x.NumeroMatricula, map => map.MapFrom(dto => dto.NUMERO_MATRICULA))
              .ForMember(x => x.CreatePorId, map => map.MapFrom(dto => dto.CREATEDOPOR_ID))
              .ForMember(x => x.CreatePor, map => map.MapFrom(dto => dto.CREATEDOPOR))
              .ForMember(x => x.FechaRegistro, map => map.MapFrom(dto => dto.FECHA_REGISTRO))
              .ForMember(x => x.IdTipoOperacion, map => map.MapFrom(dto => dto.ID_TIPO_OPERACION))
              .ForMember(x => x.IdTipoSolicitud, map => map.MapFrom(dto => dto.TSN_ID))
              .ForMember(x => x.DescripcionTipoSolicitud, map => map.MapFrom(dto => dto.TSN_DESCRIPCION))
              .ReverseMap();


            CreateMap<OperacionesMatriculas, OperacionesMatriculasDto>()
             .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TOP_ID))
             .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
             .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
             .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.DESCRIPCION))     
             .ReverseMap();


            CreateMap<CausalNovedamatricula, CausalNovedamatriculaDto>()
             .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CAN_ID))
             .ForMember(x => x.Top_Id, map => map.MapFrom(dto => dto.TOP_ID))
             .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ESTADO))
             .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.NOMBRE))
             .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.DESCRIPCION))
             .ReverseMap();


            CreateMap<CrearMatriculaDto, CrearMatricula>()
             .ForMember(x => x.CORREO, map => map.MapFrom(dto => dto.Correo))
             .ForMember(x => x.DPC_NOMBRE_CIUDAD, map => map.MapFrom(dto => dto.Cuidad))
             .ForMember(x => x.DPD_DEPARTAMENTO, map => map.MapFrom(dto => dto.Departamento))
             .ForMember(x => x.MAI_DIRECCION, map => map.MapFrom(dto => dto.Direccion))
             .ForMember(x => x.MAI_FECHA_REGISTRO, map => map.MapFrom(dto => dto.FechaRegistro))
             .ForMember(x => x.MAI_NUMERO_MATRICULA, map => map.MapFrom(dto => dto.NumeroMatricula))
             .ForMember(x => x.PRP_NOMBRE_RAZON_SOCIAL, map => map.MapFrom(dto => dto.RazonSocial))
             .ForMember(x => x.PRP_NUMERO_IDENTIFICACION, map => map.MapFrom(dto => dto.NumeroIdentificacion))
             .ForMember(x => x.PRP_TIPO_IDENTIFICACION, map => map.MapFrom(dto => dto.TipoIdentificacion))
             .ForMember(x => x.TELEFONO, map => map.MapFrom(dto => dto.Celular))
             .ReverseMap();

        }
    }
}
