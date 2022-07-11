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
    /// Restriccion BusinessLogic
    /// </summary>
    /// <author>Oscar Julain Rojas</author>
    /// <date>17/08/2021</date>
    public class RestriccionesBusinessLogic : IRestriccionesBusinessLogic
    {
        /// <summary>
        /// Restriccion respository 
        /// </summary>
        private readonly IRestriccionesRepository _restriccionesRepository;
        /// <summary>
        /// Mapper restricciones to restriccionesDto
        /// </summary>
        private IMapper _mapper;
        /// <summary>
        /// Logger BusinessLogic
        /// </summary>
        private readonly ILogger<RestriccionesBusinessLogic> _logger;

        /// <summary>
        /// Construcctor
        /// </summary>
        /// <param name="restriccionesRepository">Restricciones repository</param>
        /// <param name="mapper">Mapper instance</param>
        /// <param name="logger">Logger instance</param>
        public RestriccionesBusinessLogic(IRestriccionesRepository restriccionesRepository,
                                          IMapper mapper,
                                          ILogger<RestriccionesBusinessLogic> logger)
        {
            _restriccionesRepository = restriccionesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Crear Restricciones 
        /// </summary>
        /// <param name="restriccionesDto">Restricciones a crear</param>
        /// <returns>Restricciones Creadas</returns>
        public async Task<Response<RestriccionesDto>> CreateRestricciones(RestriccionesDto restriccionesDto)
        {
            var response = new Response<RestriccionesDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando restricciones {nameof(restriccionesDto.RTC_NOMBRE)} ....");
            var restriccion = await _restriccionesRepository.CrearRestricciones(_mapper.Map<Restricciones>(restriccionesDto));
            response.Data = _mapper.Map<RestriccionesDto>(restriccion);
            response.ReturnMessage = response.Data != null ? "Restriccion creada con exito" : "Error al crear la restriccion";
            return response;
        }

        /// <summary>
        /// ActualizarRestricciones 
        /// </summary>
        /// <param name="restriccionesDto">Restricciones a actualizar</param>
        /// <returns>Actualizar Restricciones</returns>
        public async Task<Response<RestriccionesDto>> ActualizarRestricciones(RestriccionesDto restriccionesDto)
        {
            var response = new Response<RestriccionesDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Actualizar restricciones {nameof(restriccionesDto.RTC_NOMBRE)} ....");
            var restriccion = await _restriccionesRepository.CrearRestricciones(_mapper.Map<Restricciones>(restriccionesDto));
            response.Data = _mapper.Map<RestriccionesDto>(restriccion);
            response.ReturnMessage = response.Data != null ? "Restriccion actualizar con exito" : "Error al actualizar la restriccion";
            return response;
        }

        /// <summary>
        /// Obtener restricciones id
        /// </summary>
        /// <param name="restriccionesDtoId">restricciones Id</param>
        /// <returns>restricciones obtenida</returns>
        public async Task<Response<RestriccionesDto>> ObtenerRestriccionesPorId(Guid restriccionesDtoId)
        {
            var response = new Response<RestriccionesDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Obtener restricciones {nameof(restriccionesDtoId)} ....");
            var restriccion = await _restriccionesRepository.ObtenerRestriccionesId(restriccionesDtoId);
            response.Data = _mapper.Map<RestriccionesDto>(restriccion);
            response.ReturnMessage = response.Data != null ? "Restriccion obtenida con exito" : "Error al obtener la restriccion";
            return response;
        }

        /// <summary>
        /// Eliminar restricciones por id
        /// </summary>
        /// <param name="restriccionesDtoId">restricciones id</param>
        /// <returns>restriccioens eliminado</returns>
        public async Task<Response<RestriccionesDto>> EliminarRestriccionesPorId(Guid restriccionesDtoId)
        {
            var response = new Response<RestriccionesDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Eliminar restricciones {nameof(restriccionesDtoId)} ....");
            var restriccion = await _restriccionesRepository.EliminarRestricciones(restriccionesDtoId);
            response.Data = _mapper.Map<RestriccionesDto>(restriccion);
            response.ReturnMessage = response.Data != null ? "Restriccion eliminada con exito" : "Error al obtener la eliminada";
            return response;
        }
    }
}
