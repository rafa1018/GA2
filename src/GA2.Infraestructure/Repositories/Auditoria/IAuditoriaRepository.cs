using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IAuditoriaRepository
    {

       Task<IEnumerable<Auditoria>> ObtenerlogAuditoria(ConsultaAuditoria parametros);

       Task<IEnumerable<TablasAuditoria>> ObtenerTablasAuditoria();

        Task<int> ObtenerNumeroRegistrologAuditoria(ConsultaAuditoria parametros);

    }
}
