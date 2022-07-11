using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Anadidos business logic
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public class AnadidosBusinessLogic : IAnadidosBusinessLogic
    {
        /// <summary>
        /// mapper anadidos
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// logger anadido business logic
        /// </summary>
        private readonly ILogger<AnadidosBusinessLogic> _logger;
        /// <summary>
        /// anadido repostiroy
        /// </summary>
        private readonly IAnadidosRepository _anadidosRepository;

        /// <summary>
        /// Construcctor
        /// </summary>
        /// <param name="mapper">Mapper instance</param>
        /// <param name="logger">logger instance</param>
        /// <param name="anadidosRepository">anandido repository instance</param>
        public AnadidosBusinessLogic(IMapper mapper, ILogger<AnadidosBusinessLogic> logger, IAnadidosRepository anadidosRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _anadidosRepository = anadidosRepository;
        }

        /// <summary>
        /// Crear anadido 
        /// </summary>
        /// <param name="anadidoDto">anadido a crear</param>
        /// <returns>anadido creado</returns>
        public async Task<Response<AnadidosDto>> CrearAnadido(AnadidosDto anadidoDto)
        {
            var response = new Response<AnadidosDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando añadido {nameof(anadidoDto.AND_NOMBREANADIDO)} ....");
            var tarea = await _anadidosRepository.CrearAnidados(_mapper.Map<Anadidos>(anadidoDto));
            response.Data = _mapper.Map<AnadidosDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Añadido creado con exito" : "Error al crear el añadido";
            return response;
        }

        /// <summary>
        /// Actualizar analizado
        /// </summary>
        /// <param name="anadidoDto">anadido a actualizar</param>
        /// <returns>anadido actualizado</returns>
        public async Task<Response<AnadidosDto>> ActualizarAnadido(AnadidosDto anadidoDto)
        {
            var response = new Response<AnadidosDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando añadido {nameof(anadidoDto.AND_NOMBREANADIDO)} ....");
            var tarea = await _anadidosRepository.ActualizarAnidados(_mapper.Map<Anadidos>(anadidoDto));
            response.Data = _mapper.Map<AnadidosDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Añadido actualizado  con exito" : "Error al actualizar el añadido";
            return response;
        }

        /// <summary>
        /// Obtener por tarea id
        /// </summary>
        /// <param name="tareaId">Tarea id</param>
        /// <returns>Anadidos por tarea</returns>
        public async Task<Response<AnadidosDto>> ObtenerAnadidosPorTareaId(Guid tareaId)
        {
            var response = new Response<AnadidosDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Obtener añadidos por tarea id {tareaId} ....");
            var tarea = await _anadidosRepository.ObtenerAnadidosPorTareaId(tareaId);
            response.Data = _mapper.Map<AnadidosDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Obtener añadidos con exito" : "Error al obtener el añadido";
            return response;
        }

        /// <summary>
        /// Obtener anadido por id
        /// </summary>
        /// <param name="anadidoId">anadido id</param>
        /// <returns>anandido obtenido</returns>
        public async Task<Response<AnadidosDto>> ObtenerAnadidosPorId(Guid anadidoId)
        {
            var response = new Response<AnadidosDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Obtener añadido por  id {anadidoId} ....");
            var tarea = await _anadidosRepository.ObtenerAnadidoPorId(anadidoId);
            response.Data = _mapper.Map<AnadidosDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Obtener añadidos con exito" : "Error al obtener el añadido";
            return response;
        }

        /// <summary>
        /// Eliminar anadido por id
        /// </summary>
        /// <param name="anadidoId">anadido id</param>
        /// <returns>anandido eliminado</returns>
        public async Task<Response<AnadidosDto>> EliminarAnadidosPorId(Guid anadidoId)
        {
            var response = new Response<AnadidosDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Eliminar añadido por  id {anadidoId} ....");
            var tarea = await _anadidosRepository.EliminarAnadidos(anadidoId);
            response.Data = _mapper.Map<AnadidosDto>(tarea);
            response.ReturnMessage = response.Data != null ? "Eliminar añadidos con exito" : "Error al eliminado el añadido";
            return response;
        }
    }
}
