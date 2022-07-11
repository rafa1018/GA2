using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Interfaz
    /// <author>Erwin Pantoja España</author>
    /// <date>20/10/2021</date>
    /// </summary>
    /// 
    public interface ISolicitudRepository
    {
        Task<ObtenerTramiteSolicitud> CrearSolicitud(CrearSolicitud crearSolicitudDto);
        Task<ObtenerTramiteSolicitud> ConsultarExisteSolicitud(ConsultarSolicitud consultareSolicitudDto);
        Task<SolicitudMatricula> InsertarSolicitudMatricula(SolicitudMatricula solicitudMatricula);
        Task<SolicitudPropietario> InsertarSolicitudPropietario(SolicitudPropietario solicitudPropietario);
        Task<SolicitudTerceroApoderado> InsertarSolicitudTerceroApoderado(SolicitudTerceroApoderado solicitudTerceroApoderado);
        Task<SolicitudTerceroBeneficiario> InsertarSolicitudTerceroBeneficiario(SolicitudTerceroBeneficiario solicitudTerceroBeneficiario);
        Task<SolicitudTerceroConstructor> InsertarSolicitudTerceroConstructor(SolicitudTerceroConstructor solicitudTerceroConstructor);
        Task<SolicitudTerceroVendedor> InsertarSolicitudTerceroVendedor(SolicitudTerceroVendedor solicitudTerceroVendedor);
        Task<InsertarArchivo> InsertarArchivoPorSolicitudTarea(InsertarArchivo insertarArchivo);
        Task<bool> ActualizarSolicitudTarea(ActualizarSolicitudTarea actualizarSolicitudTarea);
        Task<IEnumerable<RespuestaMatricula>> ConsultarSolicitudMatricula(Guid solicitudId);
        Task<IEnumerable<RespuestaPropietario>> ConsultarSolicitudPropietario(Guid solicitudId);
        Task<IEnumerable<RespuestaTerceroVendedor>> ConsultarTerceroVendedor(Guid solicitudId, int tipoTercero);
        Task<IEnumerable<RespuestaTerceroBeneficiario>> ConsultarTerceroBeneficiario(Guid solicitudId, int tipoTercero);
        Task<IEnumerable<RespuestaTerceroApoderado>> ConsultarTerceroApoderado(Guid solicitudId, int tipoTercero);
        Task<IEnumerable<RespuestaTerceroBeneficiarioEstudio>> ConsultarTerceroBeneficiarioEstudio(Guid solicitudId, int tipoTercero);
        Task<RespuestaTerceroEntidadEducativa> ConsultarTerceroEntidadEducativa(Guid solicitudId, int tipoTercero);
        Task<RespuestaTerceroApoderado> ConsultarTerceroRazonSocial(string numeroDocumento);
        Task<SolicitudPropietario> ConsultarPropietarioIntegridad(string numeroIdentificacion);
        Task<RespuestaTerceroEntidadSeguroEducativo> ConsultarTerceroEntidadSeguroEducativo(Guid solicitudId, int tipoTercero);
        Task<RespuestaTerceroTenedorAcciones> ConsultarTerceroTenedorAcciones(Guid solicitudId, int tipoTercero);
        Task<SolicitudTerceroAutorizado> InsertarSolicitudTerceroAutorizado(SolicitudTerceroAutorizado solicitudTerceroAutorizado);
        Task<SolicitudPropietarioMatricula> InsertarSolicitudPropietarioMatricula(SolicitudPropietarioMatricula solicitudPropietarioMatricula);
        Task<SolicitudTerceroEntidadEducativa> InsertarSolicitudTerceroEntidadEducativa(SolicitudTerceroEntidadEducativa solicitudTerceroEntidadEducativa);
        Task<SolicitudTerceroBeneficiarioEstudio> InsertarSolicitudTerceroBeneficiarioEstudio(SolicitudTerceroBeneficiarioEstudio solicitudTerceroBeneficiarioEstudio);
        // Task<SolicitudTerceroBeneficiarioEstudioEntidadEducativa> InsertarSolicitudTerceroBeneficiarioEstudioEntidadEducativa(SolicitudTerceroBeneficiarioEstudioEntidadEducativa solicitudTerceroBeneficiarioEstudioEntidadEducativa);
        Task<SolicitudTerceroEntidadSeguroEducativo> InsertarSolicitudTerceroEntidadSeguroEducativo(SolicitudTerceroEntidadSeguroEducativo solicitudTerceroEntidadSeguroEducativo);
        Task<SolicitudTerceroTenedorAcciones> InsertarSolicitudTerceroTenedorAcciones(SolicitudTerceroTenedorAcciones solicitudTerceroTenedorAcciones);
        Task<bool> EliminarTerceroSolicitud(Guid solicitudId);
        Task<bool> EliminarMatriculaPropietarioSolicitud(Guid solicitudId);
        Task<bool> EliminarPropietarioSolicitud(Guid solicitudId);
        Task<bool> EliminarMatriculaInmobiliaria(Guid solicitudId);
        Task<ObtenerTramiteSolicitud> AprobarSolicitudTarea(AprobarSolicitudTarea aprobarSolicitudTarea);
        Task<bool> RechazarSolicitudTarea(RechazarSolicitudTarea rechazarSolicitudTarea);
        Task<IEnumerable<RespuestaDocumentosPorSubModalidad>> ConsultarDocumentosPorSubModalidad(Guid idSubModalidad, Guid idSolicitudtarea);
        Task<IEnumerable<ConsultarArchivoPorSolicitud>> ConsultarArchivoPorSolicitud(Guid solicitudId);
        Task <bool> EliminarArchivoPorSolicitud(EliminarArchivoPorSolicitud eliminarArchivoPorSolicitud);
        Task <bool> ActualizarSolicitud(ActualizarSolicitud actualizarSolicitud);
        Task<InconsistenciaSolicitud> InsertarInconsistenciaSolicitud(InconsistenciaSolicitud insertarInconsistenciaSolicitud);
        Task<InconsistenciaSolicitud> ActualizarInconsistenciaSolicitud(InconsistenciaSolicitud actualizarInconsistenciaSolicitud);
        Task<IEnumerable<InconsistenciaSolicitud>> ConsultarInconsistenciaSolicitud(Guid solicitudId);
        Task<IEnumerable<RespuestaConsultarSolicitudCesantias>> ConsultarSolicitudCesantias(PeticionConsultarSolicitudCesantias solicitud);
    }
}
