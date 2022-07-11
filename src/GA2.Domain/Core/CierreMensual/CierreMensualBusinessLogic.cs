using AutoMapper;
using Dapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class CierreMensualBusinessLogic : ICierreMensualBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ICierreMensualRepository _cierreMensualRepository;

        public CierreMensualBusinessLogic(IMapper mapper, ICierreMensualRepository cierreMensualRepository)
        {
            _mapper = mapper;
            _cierreMensualRepository = cierreMensualRepository;
        }

        private readonly ICierreMensualRequestProvider _iCierreMensualRequestProvider;

        public CierreMensualBusinessLogic(
             IMapper mapper,
             ICierreMensualRequestProvider iCierreMensualRequestProvider,
             ICierreMensualRepository iCierreMensualRepository
             )
        {
            _mapper = mapper;
            _iCierreMensualRequestProvider = iCierreMensualRequestProvider;
            _cierreMensualRepository = iCierreMensualRepository;
        }

        public async Task<Response<bool>> ValidarExisteCierre(CierreMensualDto request)
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
        /// ProgramarCierreMensual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ProgramacionCierreMensualDto>> ProgramarCierreMensual(ParametrosCierreMensualDto request)
        {

            CierreMensualDto cierre = new CierreMensualDto();

            Response<IPCDto> response = new Response<IPCDto>
            {
                Data = _mapper.Map<IPCDto>(await _cierreMensualRepository.ObtenerIPCMes())
            };

            cierre.IPC = response.Data.ValorIPC;
            cierre.Anio = response.Data.Anio;
            cierre.Mes = response.Data.Mes;
            cierre.GeneraActualizacion = request.GeneraActualizacion;
            cierre.TipoProceso = request.TipoProceso;

            // 1. AHORROS
            if (request.TipoProceso == 1)
            {
                List<int> listConceptosAhorro = await _cierreMensualRepository.ObtenerCategoriaConceptos("A");
                cierre.ListConceptosAhorros = listConceptosAhorro;

                int cuentaAbonoAhorro = await _cierreMensualRepository.ObtenerCuentaAbono("A");
                cierre.CuentaAbonoAhorros = cuentaAbonoAhorro;
            }

            // 2. CESANTIAS
            if (request.TipoProceso == 2)
            {
                List<int> listConceptosCesantias = await _cierreMensualRepository.ObtenerCategoriaConceptos("C");
                cierre.ListConceptosCesantias = listConceptosCesantias;

                int cuentaAbonoCesantias = await _cierreMensualRepository.ObtenerCuentaAbono("C");
                cierre.CuentaAbonoCesantias = cuentaAbonoCesantias;
            }

            // 3. AMBOS
            if (request.TipoProceso == 3)
            {
                List<int> listConceptosAhorro = await _cierreMensualRepository.ObtenerCategoriaConceptos("A");
                cierre.ListConceptosAhorros = listConceptosAhorro;

                int cuentaAbonoAhorro = await _cierreMensualRepository.ObtenerCuentaAbono("A");
                cierre.CuentaAbonoAhorros = cuentaAbonoAhorro;

                List<int> listConceptosCesantias = await _cierreMensualRepository.ObtenerCategoriaConceptos("C");
                cierre.ListConceptosCesantias = listConceptosCesantias;

                int cuentaAbonoCesantias = await _cierreMensualRepository.ObtenerCuentaAbono("C");
                cierre.CuentaAbonoCesantias = cuentaAbonoCesantias;
            }

            Task<Response<bool>> responseValidacion = ValidarExisteCierre(cierre);

            if (responseValidacion.Result.IsSuccess == true)
            {
                ProgramacionCierreMensualDto result = _mapper.Map<ProgramacionCierreMensualDto>(await _cierreMensualRepository.
                    ProgramarCierreMensual(_mapper.Map<ParametrosCierreMensual>(request), _mapper.Map<CierreMensual>(cierre)));

                Response<RespuestaCierreMensualDto> respuestaCierreMensualDto = _mapper.Map<Response<RespuestaCierreMensualDto>>(await _iCierreMensualRequestProvider.
                    CierreMensual(_mapper.Map<ProgramacionCierreMensual>(result)));

                ProgramacionCierreMensualDto res = _mapper.Map<ProgramacionCierreMensualDto>(await _cierreMensualRepository.
                    ActualizaEstadoCierreMensual(respuestaCierreMensualDto.Data.Id, respuestaCierreMensualDto.Data.Estado));

                ProgramacionCierreMensualDto resultProgramacion = _mapper.Map<ProgramacionCierreMensualDto>(await _cierreMensualRepository.ActualizaEstadoCierreMensual(respuestaCierreMensualDto.Data.Id, respuestaCierreMensualDto.Data.Estado));

                return new Response<ProgramacionCierreMensualDto> { Data = resultProgramacion };
            }
            else
            {
                return new Response<ProgramacionCierreMensualDto> { IsSuccess = false, ReturnMessage = responseValidacion.Result.ReturnMessage };
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
                Data = _mapper.Map<IPCDto>(await _cierreMensualRepository.ObtenerIPCMes())
            };
        }

        /// <summary>
        /// ActualizaEstadoCierreMensual
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Response<ProgramacionCierreMensualDto>> ActualizaEstadoCierreMensual(ActualizaCierreMensualDto data)
        {

            ProgramacionCierreMensualDto result = _mapper.Map<ProgramacionCierreMensualDto>(await _cierreMensualRepository.ActualizaEstadoCierreMensual(data.Id, data.Estado));
            return new Response<ProgramacionCierreMensualDto> { Data = result };

        }

        /// <summary>
        /// ActualizarGA2Async
        /// </summary>
        /// <param name="respuestaprogramacionCierresDto"></param>
        /// <returns></returns>
        public async Task ActualizarGA2Async(Response<IEnumerable<ProgramacionCierreMensualDto>> respuestaprogramacionCierresDto)
        {
            foreach (ProgramacionCierreMensualDto datos in respuestaprogramacionCierresDto.Data)
            {
                ProgramacionCierreMensualDto res = _mapper.Map<ProgramacionCierreMensualDto>(await _cierreMensualRepository.
                    ActualizaEstadoCierreMensual(datos.Id, datos.Estado));
            }
        }

        /// <summary>
        /// ConsultarProgramacionCierreMensualGA2
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensualGA2()
        {
            List<ProgramacionCierreMensualDto> list = new List<ProgramacionCierreMensualDto>();

            IEnumerable<ProgramacionCierreMensualDto> programacionCierresDto = _mapper.Map<IEnumerable<ProgramacionCierreMensualDto>>(await _cierreMensualRepository.
                ConsultarProgramacionCierreMensual());

            foreach (var programacion in programacionCierresDto)
            {
                list.Add(programacion);
            }

            return new Response<IEnumerable<ProgramacionCierreMensualDto>> { Data = list };
        }

        /// <summary>
        /// ConsultarProgramacionCierreMensual
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensual()
        {

            Response<IEnumerable<ProgramacionCierreMensualDto>> respuestaprogramacionCierresDto = _mapper.Map<Response<IEnumerable<ProgramacionCierreMensualDto>>>(await this._iCierreMensualRequestProvider.
                ConsultarProgramacionCierreMensual());

            await ActualizarGA2Async(respuestaprogramacionCierresDto);

            Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> response = ConsultarProgramacionCierreMensualGA2();

            return await response;

        }

        /// <summary>
        /// ConsultarProgramacionCierreMensualBUA
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensualBUA()
        {
            Response<IEnumerable<ProgramacionCierreMensualDto>> respuestaprogramacionCierresDto = _mapper.Map<Response<IEnumerable<ProgramacionCierreMensualDto>>>(await this._iCierreMensualRequestProvider.
                ConsultarProgramacionCierreMensual());

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
            bool encontroProgramacion = await _cierreMensualRepository.ValidarExisteCierre(anio, mes);
            return encontroProgramacion;
        }

        public async Task<Response<IEnumerable<ReporteCierreMensualDto>>> ReporteCierreMensual(Guid Id)
        {
            Response<IEnumerable<ReporteCierreMensualDto>> reporteCierreMensualDto = _mapper.Map<Response<IEnumerable<ReporteCierreMensualDto>>>(await this._iCierreMensualRequestProvider.
                ReporteCierreMensual(Id));

            return reporteCierreMensualDto;

        }
    }
}
