using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICierreMensualRepositoryBua
    {

        Task<RespuestaCierreMensual> CierreMensual(ProgramacionCierreMensual programacion);
        Task<IEnumerable<ProgramacionCierreMensual>> ConsultarProgramacionCierreMensual();
        Task<IEnumerable<ReporteCierreMensual>> ReporteCierreMensual(Guid Id);
    }
}
