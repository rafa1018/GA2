using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICronogramaRepository
    {
        Task<IEnumerable<Domain.Entities.Cronograma>> ObtenerUnidadesEjecutorasCronograma();
        Task<IEnumerable<Domain.Entities.Cronograma>> EditarFechaReporteCronograma(Domain.Entities.Cronograma cronograma);
        Task<IEnumerable<Domain.Entities.Cronograma>> EliminarUnidadEjecutoraCronograma(int idCronograma);
        Task<IEnumerable<Domain.Entities.Cronograma>> AgregarUnidadEjecutoraCronograma(Domain.Entities.Cronograma cronograma);
    }
}
