using GA2.Application.Dto.Haberes;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IIntegracionesGA2Haberes
    {
        Task<Response<String>> GenerarReporteHaberes<TOutput>(Uri url, HaberesRequestDto request, Guid correlationId, Guid userId);
    }
}
