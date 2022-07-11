using GA2.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ITransUnionRepository
    {
        Task<Guid> CrearValidacion(VLI_VALIDACION_IDENTIDAD validacion);
        Task<int> ActualizarOtpValidacion(VLI_VALIDACION_IDENTIDAD valida);
        Task<SolicitudCreditoProductoGral> CrearLogTu(SolicitudCreditoProductoGral datosLog);
        Task<SolicitudCreditoProductoGral> RegistroLogTU(SolicitudCreditoProductoGral datosLog);
        Task<VLL_VALIDACION_LOG_OTP> CrearLogOTP(VLL_VALIDACION_LOG_OTP datosLog);
    }
}