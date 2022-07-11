using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICuentasConceptosBusinessLogic
    {
        Task<Response<IEnumerable<CausalBloqueoCuentaDto>>> ObtenerCausalBloqueoCuentasConceptos();
        
        Task<Response<BloqueoCuentaConceptoDto>> InsertarBoqueoCuentaConcecto(BloqueoCuentaConceptoDto bloqueo);

        Task<Response<InfoClienteDto>> ObtenerDatosAdministracionCuentas(int tpo_identificacion, string num_identificacion);

        Task<Response<IEnumerable<CuentaClienteDto>>> ObtenerCuentasCliente(int id);


    }
}
