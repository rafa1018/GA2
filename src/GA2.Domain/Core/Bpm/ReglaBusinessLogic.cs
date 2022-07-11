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
    /// Regla business logic
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public class ReglaBusinessLogic : IReglaBusinessLogic
    {
        /// <summary>
        /// Reglas repository
        /// </summary>
        private readonly IReglasRepository _reglasRepository;
        /// <summary>
        /// Logger business logic
        /// </summary>
        private readonly ILogger<ReglaBusinessLogic> _logger;
        /// <summary>
        /// Mapper tarea to tareaDto
        /// </summary>
        private readonly IMapper _mapper;

        public ReglaBusinessLogic(IReglasRepository reglasRepository, ILogger<ReglaBusinessLogic> logger, IMapper mapper)
        {
            _reglasRepository = reglasRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Crear Reglas
        /// </summary>
        /// <param name="reglaDto">Regla a crear</param>
        /// <returns>Regla creada</returns>
        public async Task<Response<ReglasDto>> CrearReglas(ReglasDto reglaDto)
        {
            var response = new Response<ReglasDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando regla {nameof(reglaDto.RGL_NOMBRE)} ....");
            var regla = await _reglasRepository.CrearReglas(_mapper.Map<Reglas>(reglaDto));
            response.Data = _mapper.Map<ReglasDto>(regla);
            response.ReturnMessage = response.Data != null ? "Regla creada con exito" : "Error al crear la regla";
            return response;
        }

        /// <summary>
        /// Actualizar reglas
        /// </summary>
        /// <param name="reglaDto">regla a actualizar</param>
        /// <returns>regla actualizada</returns>
        public async Task<Response<ReglasDto>> ActualizarReglas(ReglasDto reglaDto)
        {
            var response = new Response<ReglasDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Creando regla {nameof(reglaDto.RGL_NOMBRE)} ....");
            var regla = await _reglasRepository.ActualizarReglas(_mapper.Map<Reglas>(reglaDto));
            response.Data = _mapper.Map<ReglasDto>(regla);
            response.ReturnMessage = response.Data != null ? "Regla actualizada con exito" : "Error al actualizar la regla";
            return response;
        }

        /// <summary>
        /// Obtener regla por id
        /// </summary>
        /// <param name="reglaDtoId"></param>
        /// <returns></returns>
        public async Task<Response<ReglasDto>> ObtenerReglasPorId(Guid reglaDtoId)
        {
            var response = new Response<ReglasDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Obteniendo reglaId {nameof(reglaDtoId)} ....");
            var regla = await _reglasRepository.ObtenerReglasPorId(reglaDtoId);
            response.Data = _mapper.Map<ReglasDto>(regla);
            response.ReturnMessage = response.Data != null ? "Regla obtenida con exito" : "Error al obtener la regla";
            return response;
        }

        /// <summary>
        /// Eliminar regla por id
        /// </summary>
        /// <param name="reglaDtoId">regla id a eliminar</param>
        /// <returns>Regla eliminada</returns>
        public async Task<Response<ReglasDto>> EliminarRegla(Guid reglaDtoId)
        {
            var response = new Response<ReglasDto>();
            response.GetCorrelation();
            _logger.LogInformation($"Elimando reglaId {nameof(reglaDtoId)} ....");
            var regla = await _reglasRepository.EliminarReglasPorId(reglaDtoId);
            response.Data = _mapper.Map<ReglasDto>(regla);
            response.ReturnMessage = response.Data != null ? "Regla eliminada con exito" : "Error al eliminar la regla";
            return response;
        }
    }
}
