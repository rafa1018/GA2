using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICierreMensualBusinessLogic
    {
        Task<Response<IPCDto>> ObtenerIPCMes();

        Task<Response<ProgramacionCierreMensualDto>> ProgramarCierreMensual(ParametrosCierreMensualDto request);
        Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensual();
        Task<Response<ProgramacionCierreMensualDto>> ActualizaEstadoCierreMensual(ActualizaCierreMensualDto data);
        Task<Response<IEnumerable<ReporteCierreMensualDto>>> ReporteCierreMensual(Guid Id);
    }
}