using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class CierreAnualBusinessLogic : ICierreAnualBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ICierreAnualRepository _cierreAnualRepository;

        public CierreAnualBusinessLogic(IMapper mapper, ICierreAnualRepository cierreAnualRepository)
        {
            _mapper = mapper;
            _cierreAnualRepository = cierreAnualRepository;
        }

        private readonly ICierreAnualRequestProvider _iCierreAnualRequestProvider;

        public CierreAnualBusinessLogic(
             IMapper mapper,
             ICierreAnualRequestProvider iCierreAnualRequestProvider,
             ICierreAnualRepository iCierreAnualRepository
             )
        {
            _mapper = mapper;
            _iCierreAnualRequestProvider = iCierreAnualRequestProvider;
            _cierreAnualRepository = iCierreAnualRepository;
        }

        public async Task<Response<bool>> ValidarExisteCierre(CierreAnualDto request)
        {
            Response<bool> respuesta = new Response<bool>();
            respuesta.Data = false;
            respuesta.IsSuccess = false;
            Task<bool> existeCierre = ValidarExisteCierreAsync(request.Anio, request.Mes);

            if (existeCierre.Result == true)
            {
                respuesta.Data = false;
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "Ya existe un cierre programado para el periodo " + request.Anio + "-" + request.Mes;
                return respuesta;
            }

            return respuesta;
        }




        /// <summary>
        /// ProgramarCierreAnual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ProgramacionCierreAnualDto>> ProgramarCierreAnual(ParametrosCierreAnualDto request)
        {

            CierreAnualDto cierre = new CierreAnualDto();

            Response<IPCDto> response = new Response<IPCDto>
            {
                Data = _mapper.Map<IPCDto>(await _cierreAnualRepository.ObtenerIPCMes())
            };

            cierre.IPC = response.Data.ValorIPC;
            cierre.Anio = response.Data.Anio;
            cierre.Mes = response.Data.Mes;
            cierre.GeneraActualizacion = request.GeneraActualizacion;
            cierre.TipoProceso = request.TipoProceso;

            // 1. AHORROS
            if (request.TipoProceso == 1)
            {
                List<int> listConceptosAhorro = await _cierreAnualRepository.ObtenerCategoriaConceptos("A");
                cierre.ListConceptosAhorros = listConceptosAhorro;

                int cuentaAbonoAhorro = await _cierreAnualRepository.ObtenerCuentaAbono("A");
                cierre.CuentaAbonoAhorros = cuentaAbonoAhorro;
            }

            // 2. CESANTIAS
            if (request.TipoProceso == 2)
            {
                List<int> listConceptosCesantias = await _cierreAnualRepository.ObtenerCategoriaConceptos("C");
                cierre.ListConceptosCesantias = listConceptosCesantias;

                int cuentaAbonoCesantias = await _cierreAnualRepository.ObtenerCuentaAbono("C");
                cierre.CuentaAbonoCesantias = cuentaAbonoCesantias;
            }

            // 3. AMBOS
            if (request.TipoProceso == 3)
            {
                List<int> listConceptosAhorro = await _cierreAnualRepository.ObtenerCategoriaConceptos("A");
                cierre.ListConceptosAhorros = listConceptosAhorro;

                int cuentaAbonoAhorro = await _cierreAnualRepository.ObtenerCuentaAbono("A");
                cierre.CuentaAbonoAhorros = cuentaAbonoAhorro;

                List<int> listConceptosCesantias = await _cierreAnualRepository.ObtenerCategoriaConceptos("C");
                cierre.ListConceptosCesantias = listConceptosCesantias;

                int cuentaAbonoCesantias = await _cierreAnualRepository.ObtenerCuentaAbono("C");
                cierre.CuentaAbonoCesantias = cuentaAbonoCesantias;
            }

            Task<Response<bool>> responseValidacion = ValidarExisteCierre(cierre);

            if (responseValidacion.Result.IsSuccess == true)
            {
                ProgramacionCierreAnualDto result = _mapper.Map<ProgramacionCierreAnualDto>(await _cierreAnualRepository.
                    ProgramarCierreAnual(_mapper.Map<ParametrosCierreAnual>(request), _mapper.Map<CierreAnual>(cierre)));

                Response<RespuestaCierreAnualDto> respuestaCierreAnualDto = _mapper.Map<Response<RespuestaCierreAnualDto>>(await _iCierreAnualRequestProvider.
                    CierreAnual(_mapper.Map<ProgramacionCierreAnual>(result)));

                ProgramacionCierreAnualDto res = _mapper.Map<ProgramacionCierreAnualDto>(await _cierreAnualRepository.
                    ActualizaEstadoCierreAnual(respuestaCierreAnualDto.Data.Id, respuestaCierreAnualDto.Data.Estado));

                ProgramacionCierreAnualDto resultProgramacion = _mapper.Map<ProgramacionCierreAnualDto>(await _cierreAnualRepository.ActualizaEstadoCierreAnual(respuestaCierreAnualDto.Data.Id, respuestaCierreAnualDto.Data.Estado));

                return new Response<ProgramacionCierreAnualDto> { Data = resultProgramacion };
            }
            else
            {
                return new Response<ProgramacionCierreAnualDto> { IsSuccess = false, ReturnMessage = responseValidacion.Result.ReturnMessage };
            }

        }

        /// <summary>
        /// ObtenerIPCMes
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IPCDto>> ObtenerIPCMes()
        {
            return new Response<IPCDto>
            {
                Data = _mapper.Map<IPCDto>(await _cierreAnualRepository.ObtenerIPCMes())
            };
        }

        /// <summary>
        /// ActualizaEstadoCierreAnual
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Response<ProgramacionCierreAnualDto>> ActualizaEstadoCierreAnual(ActualizaCierreAnualDto data)
        {

            ProgramacionCierreAnualDto result = _mapper.Map<ProgramacionCierreAnualDto>(await _cierreAnualRepository.ActualizaEstadoCierreAnual(data.Id, data.Estado));
            return new Response<ProgramacionCierreAnualDto> { Data = result };

        }

        /// <summary>
        /// ActualizarGA2Async
        /// </summary>
        /// <param name="respuestaprogramacionCierresDto"></param>
        /// <returns></returns>
        public async Task ActualizarGA2Async(Response<IEnumerable<ProgramacionCierreAnualDto>> respuestaprogramacionCierresDto)
        {
            foreach (ProgramacionCierreAnualDto datos in respuestaprogramacionCierresDto.Data)
            {
                ProgramacionCierreAnualDto res = _mapper.Map<ProgramacionCierreAnualDto>(await _cierreAnualRepository.
                    ActualizaEstadoCierreAnual(datos.Id, datos.Estado));
            }
        }

        /// <summary>
        /// ConsultarProgramacionCierreAnualGA2
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnualGA2()
        {
            List<ProgramacionCierreAnualDto> list = new List<ProgramacionCierreAnualDto>();

            IEnumerable<ProgramacionCierreAnualDto> programacionCierresDto = _mapper.Map<IEnumerable<ProgramacionCierreAnualDto>>(await _cierreAnualRepository.
                ConsultarProgramacionCierreAnual());

            foreach (var programacion in programacionCierresDto)
            {
                list.Add(programacion);
            }

            return new Response<IEnumerable<ProgramacionCierreAnualDto>> { Data = list };
        }

        /// <summary>
        /// ConsultarProgramacionCierreAnual
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnual()
        {

            Response<IEnumerable<ProgramacionCierreAnualDto>> respuestaprogramacionCierresDto = _mapper.Map<Response<IEnumerable<ProgramacionCierreAnualDto>>>(await this._iCierreAnualRequestProvider.
                ConsultarProgramacionCierreAnual());

            await ActualizarGA2Async(respuestaprogramacionCierresDto);

            Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> response = ConsultarProgramacionCierreAnualGA2();

            return await response;

        }

        /// <summary>
        /// ConsultarProgramacionCierreAnualBUA
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnualBUA()
        {
            Response<IEnumerable<ProgramacionCierreAnualDto>> respuestaprogramacionCierresDto = _mapper.Map<Response<IEnumerable<ProgramacionCierreAnualDto>>>(await this._iCierreAnualRequestProvider.
                ConsultarProgramacionCierreAnual());

            return respuestaprogramacionCierresDto;
        }

        /// <summary>
        /// ValidarExisteCierreAsync
        /// </summary>
        /// <param name="anio"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        private async Task<bool> ValidarExisteCierreAsync(int anio, int mes)
        {
            bool encontroProgramacion = await _cierreAnualRepository.ValidarExisteCierre(anio, mes);
            return encontroProgramacion;
        }

        public Response<IEnumerable<ProgramacionCierreAnualDto>> ConsultarProgramacionCierreAnuallBUA()
        {
            throw new NotImplementedException();
        }
    }
}
