using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class CronogramaNovedadesBusinessLogic : ICronogramaNovedadesBusinessLogic
    {
        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        private readonly IMapper _mapper;
        private readonly ICronogramaRepository _repositoryRepository;

        /// <summary>
        /// Constructor Negocio Clients
        /// </summary>
        /// <param name="mapper">Instancia mapper</param>
        /// <param name="clientsRepository">Instancia repositorio usuarios</param>
        public CronogramaNovedadesBusinessLogic(
            IMapper mapper,
            ICronogramaRepository repositoryRepository
            )
        {
            _mapper = mapper;
            _repositoryRepository = repositoryRepository;
        }

        public async Task<Response<IEnumerable<CronogramaDto>>> AgregarUnidadEjecutoraCronograma(CronogramaDto cronogramaDTO)
        {
            var cronograma = this._mapper.Map<CronogramaDto, Cronograma>(cronogramaDTO);
            var cronogramaUnidadesEjecutoras = this._mapper.Map<IEnumerable<Cronograma>, IEnumerable<CronogramaDto>>(await _repositoryRepository.AgregarUnidadEjecutoraCronograma(cronograma));
            return new Response<IEnumerable<CronogramaDto>> { Data = cronogramaUnidadesEjecutoras };
        }

        public async Task<Response<IEnumerable<CronogramaDto>>> EditarFechaRegistroCronograma(CronogramaDto editarCronogramaDTO)
        {
            var cronograma = this._mapper.Map<CronogramaDto, Cronograma>(editarCronogramaDTO);
            var cronogramaUnidadesEjecutoras = this._mapper.Map<IEnumerable<Cronograma>, IEnumerable<CronogramaDto>>(await _repositoryRepository.EditarFechaReporteCronograma(cronograma));
            return new Response<IEnumerable<CronogramaDto>> { Data = cronogramaUnidadesEjecutoras };
        }

        public async Task<Response<IEnumerable<CronogramaDto>>> EliminarUnidadEjecutoraCronograma(int idCronograma)
        {
            var cronograma = this._mapper.Map<IEnumerable<Cronograma>, IEnumerable<CronogramaDto>>(await _repositoryRepository.EliminarUnidadEjecutoraCronograma(idCronograma));
            return new Response<IEnumerable<CronogramaDto>> { Data = cronograma };
        }

        /// <summary>
        /// Metodo obtener info cliente
        /// </summary>
        /// <param name="Cliente">Modelo dto cliente</param>
        /// <uthor>ONicolas Florez Sarraola</uthor>
        /// <date>12/03/2021</date>
        /// <returns>Modelo dto de un cliente</returns>
        public async Task<Response<IEnumerable<CronogramaDto>>> ObtenerUnidadesEjecutorasCronograma()
        {
            var cronogramaUnidadesEjecutoras = this._mapper.Map<IEnumerable<Cronograma>, IEnumerable<CronogramaDto>>(await _repositoryRepository.ObtenerUnidadesEjecutorasCronograma());
            return new Response<IEnumerable<CronogramaDto>> { Data = cronogramaUnidadesEjecutoras };
        }
    }
}
