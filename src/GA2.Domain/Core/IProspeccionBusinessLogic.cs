using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IProspeccionBusinessLogic
    {
        Task<Response<DataClienteProspeccionDto>> ObtenerClienteProspeccion(DataClienteProspeccionDto request);
        Task<Response<DatosProspeccionDto>> GenerarDatosProspeccion(DatosProspeccionDto request);
        Task<Response<IEnumerable<object>>> ObtenerExcepcionesPlazoTipoActor(int simId, int v);
        Task<Response<IEnumerable<object>>> ObtenerExcepcionesPlazoUEj(int simId, int v);
        Task<Response<IEnumerable<SimulacionDto>>> CrearSimulacionCliente(CreacionSimulacionClienteDto request);
        Task<Response<object>> LlamadoIntegracionesAfiliado(RequestIntegracionesAfiliadoDto request);
        Task<Response<SolicitudSimulacionDto>> CrearPreAprobado(SolicitudSimulacionDto request);
        Task<Response<SolicitudCreditoDto>> CrearSolicitudCredito(SolicitudCreditoDto request);
    }
}