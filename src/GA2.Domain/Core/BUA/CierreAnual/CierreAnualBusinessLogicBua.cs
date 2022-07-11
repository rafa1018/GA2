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
    public class CierreAnualBusinessLogicBua : ICierreAnualBusinessLogicBua
    {

        private readonly IMapper _mapper;
        private readonly ICierreAnualRepositoryBua _cierreAnualRepositoryBua;

        public CierreAnualBusinessLogicBua(
            ICierreAnualRepositoryBua cierreAnualRepositoryBua,
            IMapper mapper)
        {
            _cierreAnualRepositoryBua = cierreAnualRepositoryBua;
            _mapper = mapper;

        }

        public async Task<Response<RespuestaCierreAnualDto>> CierreAnual(ProgramacionCierreAnualDto programacion)
        {

            ProgramacionCierreAnual cierre = new ProgramacionCierreAnual();
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

            RespuestaCierreAnualDto cierreRespuesta = _mapper.Map<RespuestaCierreAnualDto>(await _cierreAnualRepositoryBua.
                CierreAnual(cierre));

            return new Response<RespuestaCierreAnualDto>
            {
                Data = cierreRespuesta,
            };

        }

        public async Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnual()
        {
            List<ProgramacionCierreAnualDto> list = new List<ProgramacionCierreAnualDto>();

            IEnumerable<ProgramacionCierreAnualDto> respuestaprogramacionCierresDto = _mapper.Map<IEnumerable<ProgramacionCierreAnualDto>>(await this._cierreAnualRepositoryBua.
                ConsultarProgramacionCierreAnual());

            foreach (var programacion in respuestaprogramacionCierresDto)
            {
                list.Add(programacion);
            }

            return new Response<IEnumerable<ProgramacionCierreAnualDto>> { Data = list };

        }
    }
}
