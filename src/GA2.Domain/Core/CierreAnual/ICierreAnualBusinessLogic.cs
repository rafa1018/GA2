using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICierreAnualBusinessLogic
    {
        Task<Response<IPCDto>> ObtenerIPCMes();
        Task<Response<ProgramacionCierreAnualDto>> ProgramarCierreAnual(ParametrosCierreAnualDto request);
        Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnual();
        Task<Response<ProgramacionCierreAnualDto>> ActualizaEstadoCierreAnual(ActualizaCierreAnualDto data);
        Response<IEnumerable<ProgramacionCierreAnualDto>> ConsultarProgramacionCierreAnuallBUA();
    }
}