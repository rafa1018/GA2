using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IIntegracionesGA2Vigia
    {
        Task<Response<ResultadoVerificacionTercero>> VerificacionTercero<TOutput>(Uri url, VerificacionTerceroRequest verificacionTerceroRequest, Guid correlationId, Guid userId);
        Task<object> CargaProductoTercero<TOutput>(Uri url, CargaProductoTerceroRequest cargaProductoTerceroRequest, Guid correlationId, Guid userId);
        Task<object> CargaTercero<TOutput>(Uri url, CargaTerceroRequest cargaTerceroRequest, Guid correlationId, Guid userId);
        Task<object> CargaTransaccion<TOutput>(Uri url, CargaTransaccionRequest cargaTransaccionRequest, Guid correlationId, Guid userId);

    }
}