using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IProcesoBusinessLogic
    {
        Task<Response<ProcesoDto>> ActualizarProceso(ProcesoDto proceso);
        Task<Response<ProcesoDto>> CrearProceso(ProcesoDto proceso);
        Task<Response<ProcesoDto>> EliminarProceso(Guid procesoId);
        Task<Response<ProcesoDto>> ObtenerProcesoPorId(Guid procesoId);
        /// <summary>
        /// ObtenerProceso Todos los procesos
        /// </summary>
        /// <returns>Lista de Procesos</returns>
        Task<Response<IEnumerable<ProcesoDto>>> ObtenerProcesos();
    }
}