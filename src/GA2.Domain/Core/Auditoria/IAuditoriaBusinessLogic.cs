using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IAuditoriaBusinessLogic
    {
        Task<Response<listaAuditorias>> ObtenerlogAuditoria(ConsultaAuditoriaDto parametros);

        Task<Response<IEnumerable<TablasAuditoriaDto>>> ObtenerTablasAuditoria();
    }
}
