using AutoMapper;
using GA2.Application.Dto;
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
    public class CierreMensualBusinessLogicBua : ICierreMensualBusinessLogicBua
    {

        private readonly IMapper _mapper;
        private readonly ICierreMensualRepositoryBua _cierreMensualRepositoryBua;

        public CierreMensualBusinessLogicBua(
            ICierreMensualRepositoryBua cierreMensualRepositoryBua,
            IMapper mapper)
        {
            _cierreMensualRepositoryBua = cierreMensualRepositoryBua;
            _mapper = mapper;

        }

        public async Task<Response<RespuestaCierreMensualDto>> CierreMensual(ProgramacionCierreMensualDto programacion)
        {

            ProgramacionCierreMensual cierre = new ProgramacionCierreMensual();
            cierre.ID = programacion.Id;
            cierre.ANIO = programacion.Anio;
            cierre.MES = programacion.Mes;
            cierre.IPC = programacion.IPC;
            cierre.TIPO_PROCESO = programacion.TipoProceso;
            cierre.CONCEPTOS_AHORRO = programacion.ConceptosAhorro;
            cierre.CONCEPTOS_CESANTIAS = programacion.ConceptosCesantias;
            cierre.CUENTA_ABONO_AHORRO = programacion.CuentaAbonoAhorro;
            cierre.CUENTA_ABONO_CESANTIAS = programacion.CuentaAbonoCesantias;
            cierre.ESTADO = programacion.Estado;
            cierre.FECHA_CARGUE = programacion.FechaCargue;
            cierre.FECHA_PROCESAMIENTO = programacion.FechaProcesamiento;
            cierre.GENERA_ACTUALIZACION = programacion.GeneraActualizacion;
            cierre.USUARIO_PROCESAMIENTO = programacion.UsuarioProcesamiento;

            RespuestaCierreMensualDto cierreRespuesta = _mapper.Map<RespuestaCierreMensualDto>(await _cierreMensualRepositoryBua.
                CierreMensual(cierre));

            return new Response<RespuestaCierreMensualDto>
            {
                Data = cierreRespuesta,
            };

        }

        public async Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensual()
        {
            List<ProgramacionCierreMensualDto> list = new List<ProgramacionCierreMensualDto>();

            IEnumerable<ProgramacionCierreMensualDto> respuestaprogramacionCierresDto = _mapper.Map<IEnumerable<ProgramacionCierreMensualDto>>(await this._cierreMensualRepositoryBua.
                ConsultarProgramacionCierreMensual());

            foreach (var programacion in respuestaprogramacionCierresDto)
            {
                list.Add(programacion);
            }

            return new Response<IEnumerable<ProgramacionCierreMensualDto>> { Data = list };

        }

        public async Task<Response<IEnumerable<ReporteCierreMensualDto>>> ReporteCierreMensual(Guid Id)
        {
            List<ReporteCierreMensualDto> list = new List<ReporteCierreMensualDto>();

            IEnumerable<ReporteCierreMensualDto> respuestareporteCierresDto = _mapper.Map<IEnumerable<ReporteCierreMensualDto>>(await this._cierreMensualRepositoryBua.
                ReporteCierreMensual(Id));

            foreach (var programacion in respuestareporteCierresDto)
            {
                list.Add(programacion);
            }

            return new Response<IEnumerable<ReporteCierreMensualDto>> { Data = list };

        }
    }
}
