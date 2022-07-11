using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Dto.Catalogs;
using GA2.Application.Main;
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
    public class CuentasClientesBusinessLogic : ICuentasClientesBusinessLogic
    {

        private readonly IMapper _mapper;
        private readonly IClientRequestProvider _iClientRequestProvider;
        private readonly ICuentasClientesRepository _cuentasClientesRepository;

        public CuentasClientesBusinessLogic(IMapper mapper, IClientRequestProvider iClientRequestProvider, ICuentasClientesRepository cuentasClientesRepository)
        {
            _mapper = mapper;
            _iClientRequestProvider = iClientRequestProvider;
            _cuentasClientesRepository = cuentasClientesRepository;
        }

        public async Task<Response<InfoClienteDto>> ObtenerInformacionCliente(int tpo_identificacion, string num_identificacion)
        {
            Response<InfoClienteDto> clienteDto = await _iClientRequestProvider.ObtenerInfoCliente(tpo_identificacion, num_identificacion);
            Response<InfoClienteDto> respuesta = new Response<InfoClienteDto>();

            if (clienteDto.Data != null)
            {

                InfoDetalleCliente detalleCliente = await _cuentasClientesRepository.ObtenerDetalleInfoCliente(_mapper.Map<InfoCliente>(clienteDto.Data));
                InfoClienteDto cliente = clienteDto.Data;

                IEnumerable<TipoCuentaCDto> tipoCuentaCDto = this._mapper.Map<IEnumerable<TipoCuentaCDto>>(await _cuentasClientesRepository.ObtenerTipoCuentaC());
                IEnumerable<PorcentajeDescuentoDto> porcentajeDescuentos = this._mapper.Map<IEnumerable<PorcentajeDescuentoDto>>(await _cuentasClientesRepository.ObtenerPorcentajesDescuento());
                IEnumerable<CausalEstadoCuentaDto> causalEstadoCuentas = this._mapper.Map<IEnumerable<CausalEstadoCuentaDto>>(await _cuentasClientesRepository.ObtenerCausalEstadoCuenta());

                cliente.Categoria = detalleCliente.CATEGORIA;
                cliente.Grado = detalleCliente.GRADO;
                cliente.Fuerza = detalleCliente.FUERZA;
                cliente.TipoIdentificacion = detalleCliente.TIPO_IDENTIFICACION;
                cliente.UnidadEjecutora = detalleCliente.UNIDADE_EJECUTORA;
                cliente.TipoAfiliacion = detalleCliente.TIPO_AFILIACION;
                cliente.causalEstadoCuenta = causalEstadoCuentas.ToList<CausalEstadoCuentaDto>();
                cliente.tipoCuentaC = tipoCuentaCDto.ToList<TipoCuentaCDto>();
                cliente.porcentajeDescuentos = porcentajeDescuentos.ToList<PorcentajeDescuentoDto>();

                return new Response<InfoClienteDto> { Data = cliente };

            }
            else
            {

                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El cliente no existe";
                return respuesta;

            }


        }
    }
}
