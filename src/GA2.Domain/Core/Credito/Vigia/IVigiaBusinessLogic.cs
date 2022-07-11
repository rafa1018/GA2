using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Threading.Tasks;
using static GA2.Domain.Core.VigiaBusinessLogic;

namespace GA2.Domain.Core
{
    public interface IVigiaBusinessLogic
    {
        Task<Response<ResultadoVerificacionTercero>> VertificacionTercero(VerificacionTerceroRequest request);
    }
}