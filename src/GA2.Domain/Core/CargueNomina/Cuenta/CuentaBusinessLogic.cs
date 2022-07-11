using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class CuentaBusinessLogic : ICuentaBusinessLogic
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;

        public CuentaBusinessLogic(ICuentaRepository cuentaRepository, IMapper mapper)
        {
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// GenerarCuenta
        /// </summary>
        /// <author>cristian gonzalez</author>
        /// <date>04/08/2021</date>
          public async Task<Response<VerificarAfiliadoDTO>> VerificarAfiliado(VerificarAfiliadoDTO verificarafiliado)
        {      
            return new Response<VerificarAfiliadoDTO> { Data = _mapper.Map<VerificarAfiliadoDTO>(await _cuentaRepository.VerificarAfiliado(_mapper.Map<VerificarAfiliado>(verificarafiliado))) };
        }


        public async Task<Response<CuentaDto>> CrearCuenta(CuentaDto cuenta)
        {      
            return new Response<CuentaDto> { Data = _mapper.Map<CuentaDto>(await _cuentaRepository.CrearCuenta(_mapper.Map<Cuenta>(cuenta))) };
        }

        public async Task<Response<CuentaDto>> ActualizarCuenta(CuentaDto cuenta)
        {
            return new Response<CuentaDto> { Data = _mapper.Map<CuentaDto>(await _cuentaRepository.ActualizarCuenta(_mapper.Map<Cuenta>(cuenta))) };
        }

        public async Task<Response<CuentaDto>> EliminarCuenta(CuentaDto cuenta)
        {
            return new Response<CuentaDto> { Data = _mapper.Map<CuentaDto>(await _cuentaRepository.EliminarCuenta(_mapper.Map<Cuenta>(cuenta))) };
        }

        public async Task<Response<CuentaDto>> ObtenerCuentaPorId(Guid cuentaId)
        {
            return new Response<CuentaDto> { Data = _mapper.Map<CuentaDto>(await _cuentaRepository.ObtenerCuentaPorCuentaId((cuentaId))) };
        }
        public async Task<Response<CuentaDto>> ObtenerCuentaPorEstado(Guid cuentaId)
        {
            return new Response<CuentaDto> { Data = _mapper.Map<CuentaDto>(await _cuentaRepository.ObtenerCuentaPorEstado(cuentaId)) };
        }

        /// <summary>
        /// ObtenerConsecutivoPorId
        /// </summary>
        /// <param name="idafiliado"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>19/08/2021</date>
        /// 
        public async Task<Response<AfiliadoporIdentificacionDTO>> ObtenerAfiliadoporIdentificacion(string idafiliado)
        {
            return new Response<AfiliadoporIdentificacionDTO>
            { 
                Data = this._mapper.Map<AfiliadoporIdentificacionDTO>(
                    await this._cuentaRepository.ObtenerAfiliadoporIdentificacion(idafiliado)) 
            };

        }
       
    }
}
