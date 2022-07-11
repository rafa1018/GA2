using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GA2.Domain.Core
{

    /// <summary>
    /// Interfaz
    /// <author>Erwin Pantoja España</author>
    /// <date>20/10/2021</date>
    /// </summary>
    /// 
    public interface ISolicitudBusinessLogic
    {
        Task<Response<ObtenerTramiteSolicitudDto>> CrearSolicitud(CrearSolicitudDto crearSolicitudDto);
        Task<Response<ObtenerTramiteSolicitudDto>> ConsultarExisteSolicitud(ConsultarSolicitudDto consultareSolicitudDto);
        Task<Response<TerceroApoderadoRespuestaDto>> ConsultarExistePersona(string numeroDocumento);
        Task<Response<TerceroApoderadoRespuestaDto>> ConsultarExistePropProv(string numeroIdentificacion);
        Task<Response<bool>> CrearSolicitudTarea(CrearSolicitudTareaDto crearSolicitudCompraViviendaDto);
        Task<Response<bool>> ActualizarSolicitudTarea(CrearSolicitudTareaDto crearSolicitudCompraViviendaDto);
        Task<Response<ObtenerTramiteSolicitudDto>> AprobarSolicitudTarea(AprobarSolicitudTareaDto aprobarSolicitudTareaDto);
        Task<Response<bool>> RechazarSolicitudTarea(RechazarSolicitudTareaDto rechazarSolicitudTareaDto);
        Task<Response<IEnumerable<DocumentosPorSubModalidadDto>>> ConsultarDocumentosPorSubModalidad(ConsultaDocumentoSubModalidadTarea consultaDocumentoSubModalidadTarea);
        Task<Response<bool>> CargarDocumentosSolicitud(List<CargarDocumentosSolicitudDto> CargarDocumentosSolicitudDto, Guid IdSolicitud);
        Task<Response<IEnumerable<ConsultarArchivoPorSolicitudDto>>> ConsultarArchivoPorSolicitud(Guid IdSolicitud);
        Task<Response<bool>> EliminarArchivoPorSolicitud(EliminarArchivoPorSolicitudDto eliminarArchivoPorSolicitudDto);
        Task<FileResult> DescargarArchivoPorSolicitud(string rutaStorage);
        Task<Response<InconsistenciaSolicitudDto>> InsertarInconsistenciaSolicitud(InconsistenciaSolicitudDto insertarInconsistenciaSolicitud);
        Task<Response<InconsistenciaSolicitudDto>> ActualizarInconsistenciaSolicitud(InconsistenciaSolicitudDto actualizarInconsistenciaSolicitud);
        Task<Response<IEnumerable<InconsistenciaSolicitudDto>>> ConsultarInconsistenciaSolicitud(Guid IdSolicitud);
        Task<Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>>> ConsultarSolicitudCesantias(PeticionConsultarSolicitudCesantiasDto solicitud);
    }
}
