using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class ProcesoBusinessLogic : IProcesoBusinessLogic
    {
        private readonly IProcesoRepository _procesoRepository;
        private readonly ILogger<ProcesoBusinessLogic> _logger;
        private readonly IMapper _mapper;

        public ProcesoBusinessLogic(IProcesoRepository procesoRepository, ILogger<ProcesoBusinessLogic> logger, IMapper mapper)
        {
            _procesoRepository = procesoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<ProcesoDto>> CrearProceso(ProcesoDto proceso)
        {
            var response = new Response<ProcesoDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando proceso  {nameof(proceso.PCS_NOMBRE)}...");
            var procesoNew = await _procesoRepository.CrearProceso(_mapper.Map<Procesos>(proceso));
            response.Data = _mapper.Map<ProcesoDto>(procesoNew);
            response.ReturnMessage = response.Data != null ? "Proceso creado con exito" : "Error al crear el proceso";
            return response;
        }

        public async Task<Response<ProcesoDto>> ActualizarProceso(ProcesoDto proceso)
        {
            var response = new Response<ProcesoDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Actualizando proceso  {nameof(proceso.PCS_NOMBRE)}...");
            var procesoNew = await _procesoRepository.ActualizarProceso(_mapper.Map<Procesos>(proceso));
            response.Data = _mapper.Map<ProcesoDto>(procesoNew);
            response.ReturnMessage = response.Data != null ? "Proceso actualizado con exito" : "Error al actaulizar el proceso";
            return response;
        }

        public async Task<Response<ProcesoDto>> EliminarProceso(Guid procesoId)
        {
            var response = new Response<ProcesoDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Eliminando proceso: {procesoId}...");
            var procesoNew = await _procesoRepository.EliminarProcesoProId(procesoId);
            response.Data = _mapper.Map<ProcesoDto>(procesoNew);
            response.ReturnMessage = response.Data != null ? "Proceso eliminado con exito" : "Error al eliminar el proceso";
            return response;
        }

        public async Task<Response<ProcesoDto>> ObtenerProcesoPorId(Guid procesoId)
        {
            var response = new Response<ProcesoDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Obtener proceso: {procesoId}...");
            var procesoNew = await _procesoRepository.ObtenerProcesoPorId(procesoId);
            response.Data = _mapper.Map<ProcesoDto>(procesoNew);
            response.ReturnMessage = response.Data != null ? "Proceso obtenido con exito" : "Error al obtener el proceso";
            return response;
        }


        /// <summary>
        /// ObtenerProceso Todos los procesos
        /// </summary>
        /// <returns>Lista de Procesos</returns>
        public async Task<Response<IEnumerable<ProcesoDto>>> ObtenerProcesos() {
            var response = new Response<IEnumerable<ProcesoDto>>();
            response.GetCorrelation();
            _logger.LogInformation($"Obtener todos los procesos...");
            IEnumerable<Procesos> procesoNew = await _procesoRepository.ObtenerProcesos();
            response.Data = _mapper.Map<IEnumerable<ProcesoDto>>(procesoNew);
            return response;
        }

    }
}
