using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IIntegracionesGA2Fenix
    {
        Task<Response<ResponseBiometriaDto>> ValidarBiometria<TOutput>(Uri url, int request, Guid correlationId, Guid userId);
    }
}