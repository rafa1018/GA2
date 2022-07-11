using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IGestorTransUnionBusinessLogic
    {
        //Task<Response<int>> ActualizarOtpValidacion(VLI_VALIDACION_IDENTIDADDto valida);
        Task<Response<SolicitudCreditoProductoDto>> CrearLogTu(SolicitudCreditoProductoDto datosLog);
        Task<Response<SolicitudCreditoProductoDto>> RegistroLogTU(SolicitudCreditoProductoDto datosLog);
        Task<Response<VLL_VALIDACION_LOG_OTPDto>> CrearLogOTP(VLL_VALIDACION_LOG_OTPDto datosLog);
        //Task<Response<Guid>> CrearValidacion(VLI_VALIDACION_IDENTIDADDto valida);
    }
}