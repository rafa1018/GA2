using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{

    /// <summary>
    /// ICierreAnualRequestProvider
    /// </summary>
    public interface ICierreAnualRequestProvider
    {
        Task<Response<RespuestaCierreAnualDto>> CierreAnual(ProgramacionCierreAnual programacion);

        Task<Response<IEnumerable<ProgramacionCierreAnualDto>>> ConsultarProgramacionCierreAnual();
    }
}