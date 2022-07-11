using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICronogramaNovedadesBusinessLogic
    {
        Task<Response<IEnumerable<CronogramaDto>>> ObtenerUnidadesEjecutorasCronograma();
        Task<Response<IEnumerable<CronogramaDto>>> EditarFechaRegistroCronograma(CronogramaDto editarCronogramaDTO);
        Task<Response<IEnumerable<CronogramaDto>>> EliminarUnidadEjecutoraCronograma(int idCronograma);
        Task<Response<IEnumerable<CronogramaDto>>> AgregarUnidadEjecutoraCronograma(CronogramaDto cronogramaDTO);
    }
}
