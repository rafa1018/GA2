using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICuentasClientesRepository
    {

        Task<InfoDetalleCliente> ObtenerDetalleInfoCliente(InfoCliente cliente);

        Task<IEnumerable<TipoCuentaC>> ObtenerTipoCuentaC();

        Task<IEnumerable<CausalEstadoCuenta>> ObtenerCausalEstadoCuenta();

        Task<IEnumerable<PorcentajeDescuento>> ObtenerPorcentajesDescuento();

    }
}
