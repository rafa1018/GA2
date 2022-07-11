using GA2.Application.Dto;
using GA2.Application.Dto.Seven;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IIntegracionesGA2SevenBusinessLogic
    {
        Task<Response<object>> CrearCDP(Uri url, CrearCDPRequestDto crearCDPRequestDto, Guid userId);
        Task<Response<object>> AnularCDP(Uri uri, AnularCDPRequestDto request, Guid newGuid);
        Task<Response<object>> ObtenerCuentaContable(Uri uri, GetCuentaContableRequestDto request, Guid guid);
    }
}