using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{

    /// <summary>
    /// ICierreMensualRequestProvider
    /// </summary>
    public interface ICierreMensualRequestProvider
    {
        Task<Response<RespuestaCierreMensualDto>> CierreMensual(ProgramacionCierreMensual programacion);
        Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensual();
        Task<Response<IEnumerable<ReporteCierreMensualDto>>> ReporteCierreMensual(Guid Id);
    }
}