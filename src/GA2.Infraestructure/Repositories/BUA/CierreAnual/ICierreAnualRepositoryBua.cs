using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICierreAnualRepositoryBua
    {

        Task<RespuestaCierreAnual> CierreAnual(ProgramacionCierreAnual programacion);
        Task<IEnumerable<ProgramacionCierreAnual>> ConsultarProgramacionCierreAnual();
    }
}
