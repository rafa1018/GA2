using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICierreAnualBusinessLogicBua
    {
        Task<Response<RespuestaCierreAnualDto>> CierreAnual(ProgramacionCierreAnualDto request);
        Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnual();
    }
}     
