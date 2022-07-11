using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IGestorIdVisionBusinessLogic
    {
        //Task<Response<ResponseTUDto>> envioCodigoOTP(RequestTUDto requestTU);
        Task<ResponseTu> EnvioCodigoOTP(RequestTuDto requestTU);
        Task<Response<ResponseTu>> obtenerScoreCliente(RequestTuDto requestTU);
        Task<Response<ResponseTu>> obtenerHistorialCliente(RequestTuDto requestTU);
        //Task<Response<ResponseTu>> reEnvioCodigoOTP(RequestTu requestTU);
        Task<ResponseTu> reEnvioCodigoOTP(RequestTuDto requestTU);
        Task<ResponseTu> validacionCodigoOTPAsync(RequestTuDto requestTU);
        Task<ResponseTu> validarCliente(RequestTuDto requestTU);
        //Task<Response<ResponseTUDto>> validarCliente(RequestTUDto requestTU);
    }
}