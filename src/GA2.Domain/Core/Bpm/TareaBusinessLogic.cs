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
    /// <summary>
    /// Tareas businesslogic 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public class TareaBusinessLogic : ITareaBusinessLogic
    {
        /// <summary>
        /// Tarea repository
        /// </summary>
        private readonly ITareaRepository _tareaRepository;
        /// <summary>
        /// Mapper to tarea to tareaDto
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Logger business
        /// </summary>
        private readonly ILogger<TareaBusinessLogic> _logger;

        /// <summary>
        /// Construcctor
        /// </summary>
        /// <param name="tareaRepository">Tarea repository</param>
        /// <param name="mapper">mapper</param>
        /// <param name="logger">logger</param>
        public TareaBusinessLogic(ITareaRepository tareaRepository, IMapper mapper, ILogger<TareaBusinessLogic> logger)
        {
            _tareaRepository = tareaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Crear Tarea
        /// </summary>
        /// <param name="tareaDto">Tarea dto</param>
        /// <returns>Tarea creada</returns>
        public async Task<Response<TareaDto>> CrearTarea(TareaDto tareaDto)
        {
            var response = new Response<TareaDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando tarea {nameof(tareaDto.TRA_NOMBRE)} ....");
            var tarea = await _tareaRepository.CrearTarea(_mapper.Map<Tarea>(tareaDto));
            response.Data = _mapper.Map<TareaDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Tarea creada con exito" : "Error al crear la tarea";
            return response;
        }

        /// <summary>
        /// Actualizar tarea
        /// </summary>
        /// <param name="tareaDto">Tarea a actualizar</param>
        /// <returns>Tarea actualizada</returns>
        public async Task<Response<TareaDto>> ActualizarTarea(TareaDto tareaDto)
        {
            var response = new Response<TareaDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Actualizar tarea {nameof(tareaDto.TRA_NOMBRE)} ....");
            var tarea = await _tareaRepository.ActualizarTarea(_mapper.Map<Tarea>(tareaDto));
            response.Data = _mapper.Map<TareaDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Tarea actualizada con exito" : "Error al actualizar la tarea";
            return response;
        }

        /// <summary>
        /// Obtener Tarea por proceso id
        /// </summary>
        /// <param name="procesoId">Proceso id</param>
        /// <returns>Tareas del proceso</returns>
        public async Task<Response<IReadOnlyList<TareaDto>>> ObtenerTareasPorProcesoId(Guid procesoId)
        {
            var response = new Response<IReadOnlyList<TareaDto>>();
            response.GetCorrelation();
            _logger.LogInformation($"Obteniendo tareas por proceso: {procesoId} ....");
            var tareas = await _tareaRepository.ObtenerTareasPorProcesoId(procesoId);
            response.Data = _mapper.Map<IReadOnlyList<TareaDto>>(tareas);
            response.ReturnMessage = response.Data != null ? "Tareas obtenidas con exito" : "Error al traer las tareas";
            return response;
        }

        /// <summary>
        /// Obtener tareas por id
        /// </summary>
        /// <param name="tareaId">tarea id</param>
        /// <returns>Tarea obtenida</returns>
        public async Task<Response<TareaDto>> ObtenerTareasPorId(Guid tareaId)
        {
            var response = new Response<TareaDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Obteniendo tarea por id: {tareaId} ....");
            var tareas = await _tareaRepository.ObtenerTareaPorId(tareaId);
            response.Data = _mapper.Map<TareaDto>(tareas);
            response.ReturnMessage = response.Data != null ? "Tarea obtenida con exito" : "Error al traer la tarea";
            return response;
        }

        /// <summary>
        /// Eliminar tareas por id
        /// </summary>
        /// <param name="tareaId">Tarea id</param>
        /// <returns>Tarea eliminada</returns>
        public async Task<Response<TareaDto>> EliminarTareasPorId(Guid tareaId)
        {
            var response = new Response<TareaDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Elimiando tarea por id: {tareaId} ....");
            var tareas = await _tareaRepository.EliminarTareaPorId(tareaId);
            response.Data = _mapper.Map<TareaDto>(tareas);
            response.ReturnMessage = response.Data != null ? "Tarea elimnada con exito" : "Error al eliminar la tarea";
            return response;
        }

        /// <summary>
        /// Obtener todas las Tareas
        /// </summary>
        /// <returns>Lista de Tareas</returns>
        public async Task<Response<IEnumerable<TareaDto>>> ObtenerTareas() {
            var response = new Response<IEnumerable<TareaDto>>();
            _logger.LogInformation($"Obtener todas las tareas");
            IEnumerable<Tarea> tareas = await _tareaRepository.ObtenerTareas();
            response.Data = _mapper.Map<IEnumerable<TareaDto>>(tareas);
            return response;
        }
    }
}
