using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IAfiliacionesRepository
    {
        Task<IEnumerable<Afiliacion>> ObtenerAfiliacionByIdentificacion(ConsultaAfiliacion consultaAfiliacionesRequestDTO);
        Task<Afiliacion> InsertarAfiliacion(Afiliacion consultaAfiliacionesRequestDTO);
        Task<Afiliacion> ActualizarAfiliacion(Afiliacion consultaAfiliacionesRequestDTO);
    }
}
