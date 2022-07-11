using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICuentasConceptosRepository
    {

        Task<IEnumerable<CausalBloqueoCuenta>> ObtenerCausalBloqueoCuentasConceptos();

        Task<BloqueoCuentaConcepto> InsertarBoqueoCuentaConcecto(BloqueoCuentaConcepto bloqueo);

        Task<InsertCuentaConcepto> InsertarNuevaCuenta(InsertCuentaConcepto bloqueo);
        Task<InsertCuentaConcepto> validarExisteCuenta(int num_cuenta);
        Task<InsertCuentaConcepto> validarExisteCuentaTipo(int num_cuenta, int? tipoCuenta);

        Task<InfoCliente> ObtenerInformacionCliente(int tpo_identificacion, string num_identificacion);

        Task<IEnumerable<CuentaCliente>> ObtenerCuentasCliente(int clienteId);

        Task<IEnumerable<ConceptoCuenta>> ObtenerConceptosCuentas(int cuentaId);

        Task<IEnumerable<AportesCliente>> ObtenerAportesCategoriaCliente(int clienteId);

        Task<IEnumerable<MovimientosCuenta>> ObtenerMovimientosCuentaAfiliado(int cuentaId);

        Task<IEnumerable<MovimientosCuenta>> ObtenerMovimientosConceptos(int cuentaId, int conceptoId);
    }
}
