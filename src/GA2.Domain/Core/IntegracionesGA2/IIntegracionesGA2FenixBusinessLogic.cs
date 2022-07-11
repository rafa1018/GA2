using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IIntegracionesGA2FenixBusinessLogic
    {
        Task<Response<ResponseBiometriaDto>> ValidarBiometria(Uri url, int request, Guid userId);
    }
}