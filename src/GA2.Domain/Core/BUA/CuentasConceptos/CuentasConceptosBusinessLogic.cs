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
    public class CuentasConceptosBusinessLogic: ICuentasConceptosBusinessLogic
    {

        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        private readonly IMapper _mapper;
        private readonly ICuentasConceptosRepository _cuentasConceptosRepository;

        public CuentasConceptosBusinessLogic(IMapper mapper, ICuentasConceptosRepository cuentasConceptosRepository)
        {
            _mapper = mapper;
            _cuentasConceptosRepository = cuentasConceptosRepository;
        }

        public async Task<Response<BloqueoCuentaConceptoDto>> InsertarBoqueoCuentaConcecto(BloqueoCuentaConceptoDto bloqueo)
        {
            BloqueoCuentaConcepto param =this._mapper.Map<BloqueoCuentaConcepto>(bloqueo);
            BloqueoCuentaConceptoDto result= _mapper.Map<BloqueoCuentaConceptoDto>(await _cuentasConceptosRepository.InsertarBoqueoCuentaConcecto(param));
              
            return new Response<BloqueoCuentaConceptoDto> { Data = result };
        }

        public async Task<Response<IEnumerable<CausalBloqueoCuentaDto>>> ObtenerCausalBloqueoCuentasConceptos()
        {
            IEnumerable<CausalBloqueoCuentaDto> causalesBloqueos = _mapper.Map<IEnumerable<CausalBloqueoCuentaDto>>(await _cuentasConceptosRepository.ObtenerCausalBloqueoCuentasConceptos());
            return new Response<IEnumerable<CausalBloqueoCuentaDto>> { Data = causalesBloqueos };
        }

        

        public async Task<Response<InfoClienteDto>> ObtenerDatosAdministracionCuentas(int tpo_identificacion, string num_identificacion)
        {

            InfoCliente reult = await _cuentasConceptosRepository.ObtenerInformacionCliente(tpo_identificacion, num_identificacion);

            InfoClienteDto cliente= _mapper.Map<InfoClienteDto>(reult);

            Response<InfoClienteDto> respuesta = new Response<InfoClienteDto>();

            if (cliente != null)
            {

                IEnumerable<AportesClienteDto> aportes = _mapper.Map<IEnumerable<AportesClienteDto>>(await _cuentasConceptosRepository.ObtenerAportesCategoriaCliente(cliente.ClienteId));
                IEnumerable<CuentaClienteDto> cuentasDto = _mapper.Map<IEnumerable<CuentaClienteDto>>(await _cuentasConceptosRepository.ObtenerCuentasCliente(cliente.ClienteId));

                cliente.Aportes = (List<AportesClienteDto>)aportes;

                List<CuentaClienteDto> listCuentas = new List<CuentaClienteDto>();

                foreach (CuentaClienteDto cuenta in cuentasDto)
                {

                    IEnumerable<ConceptoCuentaDto> conceptos = _mapper.Map<IEnumerable<ConceptoCuentaDto>>(await _cuentasConceptosRepository.ObtenerConceptosCuentas(cuenta.CuentaId));
                    IEnumerable<MovimientosCuentaDto> movimientos = _mapper.Map<IEnumerable<MovimientosCuentaDto>>(await _cuentasConceptosRepository.ObtenerMovimientosCuentaAfiliado(cuenta.CuentaId));

                    List <ConceptoCuentaDto> listConceptos= new List<ConceptoCuentaDto>();
                    foreach (ConceptoCuentaDto concepto in conceptos) {

                        IEnumerable<MovimientosCuentaDto> movimientosconceptos = _mapper.Map<IEnumerable<MovimientosCuentaDto>>(await _cuentasConceptosRepository.ObtenerMovimientosConceptos(concepto.CuentaId, concepto.ConceptoId));
                        concepto.Movimientos = (List<MovimientosCuentaDto>)movimientosconceptos;
                        listConceptos.Add(concepto);

                    }
                 
                    cuenta.Conceptos = listConceptos;
                    cuenta.Movimientos = (List<MovimientosCuentaDto>)movimientos;
                    listCuentas.Add(cuenta);
                }

                cliente.Cuentas = listCuentas;

                return new Response<InfoClienteDto> { Data = cliente };
            }
            else {

                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El cliente no existe";
                return respuesta;

            }

        }

        public async Task<Response<IEnumerable<CuentaClienteDto>>> ObtenerCuentasCliente(int id)
        {

            IEnumerable<CuentaClienteDto> cuentasDto = _mapper.Map<IEnumerable<CuentaClienteDto>>(await _cuentasConceptosRepository.ObtenerCuentasCliente(id));

            return new Response<IEnumerable<CuentaClienteDto>> { Data = cuentasDto };
          
        }
    }
}
