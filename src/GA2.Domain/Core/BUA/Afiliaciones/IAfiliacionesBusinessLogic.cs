using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IAfiliacionesBusinessLogic
    {
        Task<Response<IEnumerable<AfiliacionDto>>> ObtenerAfiliacionByIdentificacion(ConsultaAfiliacionesRequestDTO consultaAfiliacion);
        Task<Response<AfiliacionDto>> InsertarAfiliacion(AfiliacionDto afiliacion);
        Task<Response<AfiliacionDto>> ActualizarAfiliacion(AfiliacionDto afiliacion);
    }
}
