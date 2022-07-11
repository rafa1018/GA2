using GA2.Domain.Entities;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICesantiasRepository
    {
        Task<ObtenerTramiteCesantias> ObtenerTramiteCesantias(ParametrosObtenerCesantias solicitud);
    }
}
