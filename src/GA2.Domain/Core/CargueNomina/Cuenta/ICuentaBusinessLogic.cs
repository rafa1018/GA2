using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICuentaBusinessLogic
    {
        Task<Response<CuentaDto>> ActualizarCuenta(CuentaDto cuenta);
        Task<Response<CuentaDto>> CrearCuenta(CuentaDto cuenta);
        Task<Response<CuentaDto>> EliminarCuenta(CuentaDto cuenta);
        Task<Response<AfiliadoporIdentificacionDTO>> ObtenerAfiliadoporIdentificacion(string idafiliado);
        Task<Response<CuentaDto>> ObtenerCuentaPorEstado(Guid cuentaId);
        Task<Response<CuentaDto>> ObtenerCuentaPorId(Guid cuentaId);
        Task<Response<VerificarAfiliadoDTO>> VerificarAfiliado(VerificarAfiliadoDTO verificarafiliado);
    }
}