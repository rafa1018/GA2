using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICierreMensualBusinessLogicBua
    {
        Task<Response<RespuestaCierreMensualDto>> CierreMensual(ProgramacionCierreMensualDto request);
        Task<Response<IEnumerable<ProgramacionCierreMensualDto>>> ConsultarProgramacionCierreMensual();
        Task<Response<IEnumerable<ReporteCierreMensualDto>>> ReporteCierreMensual(Guid Id);
    }
}     
