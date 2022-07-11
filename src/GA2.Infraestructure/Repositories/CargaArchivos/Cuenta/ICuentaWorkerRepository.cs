using GA2.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICuentaWorkerRepository
    {
        Task<IEnumerable<CuentaDto>> ParametrosCreacionCuenta(string json);
    }
}