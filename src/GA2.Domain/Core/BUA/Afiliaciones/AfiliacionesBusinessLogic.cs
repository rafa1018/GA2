using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class AfiliacionesBusinessLogic : IAfiliacionesBusinessLogic
    {
        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IAfiliacionesRepository _afiliacionesRepository;

        /// <summary>
        /// Constructor Negocio Clients
        /// </summary>
        /// <param name="mapper">Instancia mapper</param>
        /// <param name="clientsRepository">Instancia repositorio usuarios</param>
        public AfiliacionesBusinessLogic(
            IMapper mapper,
            IAfiliacionesRepository afiliacionesRepository
        )
        {
            _mapper = mapper;
            _afiliacionesRepository = afiliacionesRepository;
        }

        public async Task<Response<AfiliacionDto>> ActualizarAfiliacion(AfiliacionDto afiliacion)
        {
            var afiliacionRequest = this._mapper.Map<Afiliacion>(afiliacion);
            return new Response<AfiliacionDto> { Data = this._mapper.Map<AfiliacionDto>(await _afiliacionesRepository.ActualizarAfiliacion(afiliacionRequest)) };
        }

        public async Task<Response<AfiliacionDto>> InsertarAfiliacion(AfiliacionDto afiliacion)
        {
            var afiliacionRequest = this._mapper.Map<Afiliacion>(afiliacion);
            return new Response<AfiliacionDto> { Data = this._mapper.Map<AfiliacionDto>(await _afiliacionesRepository.InsertarAfiliacion(afiliacionRequest)) };
        }

        public async Task<Response<IEnumerable<AfiliacionDto>>> ObtenerAfiliacionByIdentificacion(ConsultaAfiliacionesRequestDTO consultaAfiliacionesRequestDTO)
        {
            var afiliacionRequest = this._mapper.Map<ConsultaAfiliacion>(consultaAfiliacionesRequestDTO);
            return new Response<IEnumerable<AfiliacionDto>> { Data = this._mapper.Map<IEnumerable<AfiliacionDto>>(await _afiliacionesRepository.ObtenerAfiliacionByIdentificacion(afiliacionRequest)) };
        }
    }
}
