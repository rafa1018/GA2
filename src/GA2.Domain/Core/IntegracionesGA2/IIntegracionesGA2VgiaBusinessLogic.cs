using GA2.Application.Dto;
using System.Threading.Tasks;
using GA2.Transversals.Commons;
using System;
namespace GA2.Domain.Core
{
    public interface IIntegracionesGA2VgiaBusinessLogic
    {
        Task<Response<ResultadoVerificacionTercero>> VerificacionTercero(Uri url, VerificacionTerceroRequest verificacionTerceroRequest, Guid userId);
        Task<Response<object>> CargaProductoTercero(Uri url, CargaProductoTerceroRequest cargaProductoTerceroRequest, Guid userId);
        Task<Response<object>> CargaTercero(Uri url, CargaTerceroRequest cargaTerceroRequest, Guid userId);
        Task<Response<object>> CargaTransaccion(Uri url, CargaTransaccionRequest cargaTransaccionRequest, Guid userId);
    }
}
