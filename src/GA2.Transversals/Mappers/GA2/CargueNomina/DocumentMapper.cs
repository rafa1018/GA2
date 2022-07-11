using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    /// <summary>
    /// Mapper del documento a la tabla DCT
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    /// </summary>
    public class DocumentMapper : Profile
    {
        public DocumentMapper()
        {
            //Model DocumentoDto a Document
            CreateMap<DocumentoDto, Documento>()
                .ForMember(x => x.DCT_ID, map => map.MapFrom(dto => dto.DocumentoId))
                .ForMember(x => x.TDC_ID, map => map.MapFrom(dto => dto.TipoDocumentoId))
                .ForMember(x => x.DCT_NOMBRE, map => map.MapFrom(dto => dto.Nombre))
                .ForMember(x => x.DCT_FECHA_INICIAL, map => map.MapFrom(dto => dto.FechaInicialDocumento))
                .ForMember(x => x.ESD_ID, map => map.MapFrom(dto => dto.EstadoDocumento))
                .ForMember(x => x.CED_ID, map => map.MapFrom(dto => dto.CausalEstadoDocumento))
                .ForMember(x => x.UEJ_ID, map => map.MapFrom(dto => dto.UnidadEjecutora))
                .ForMember(x => x.DCT_FECHA_FINAL, map => map.MapFrom(dto => dto.FechaFinalDocumento))
                .ForMember(x => x.DCT_ID_ANULA, map => map.MapFrom(dto => dto.AnulaId))
                .ForMember(x => x.DCT_ALERTA, map => map.MapFrom(dto => dto.Alerta))
                .ForMember(x => x.DCT_CREADOPOR, map => map.MapFrom(dto => dto.CreadoPor))
                .ForMember(x => x.DCT_FECHACREACION, map => map.MapFrom(dto => dto.FechaCreacion))
                .ForMember(x => x.DCT_FECHAMODIFICACION, map => map.MapFrom(dto => dto.FechaModificacion))
                .ForMember(x => x.DCT_MODIFICADOPOR, map => map.MapFrom(dto => dto.ModificadoPor))
                .ReverseMap();
        }
    }
}
