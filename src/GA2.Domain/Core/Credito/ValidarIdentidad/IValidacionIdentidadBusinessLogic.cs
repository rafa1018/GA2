using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Interface Logica de Negocio Validacion de Identidad
    /// </summary>
    public interface IValidacionIdentidadBusinessLogic
    {
        Task<Response<ValidacionIdentidadDto>> CreateValidacionIdentidad(ValidacionIdentidadDto validaDto);
        Task<Response<ValidacionIdentidadDto>> ActualizarValidacionOTP(ValidacionIdentidadDto validaDto);
        Task<Response<ValidacionIdentidadDto>> ReenvioCodigoOtp(ValidacionIdentidadDto validaDto);
        Task<SimulacionDatosPersonalesDto> ObtenerDatosPersonalesAsync(string numeroDocumento);
        Task<SimulacionDatosFinancierosDto> ObtenerDatosFinancierosAsync(string numeroDocumento);
        Task<Response<ValidacionIdentidadDto>> SeleccionarTipoCredito(ValidacionIdentidadDto tipoCredito);
        Task<Response<SimulacionDatosPersonalesDto>> CrearSimulacionDatosPersonales(SimulacionDatosPersonalesDto datosPersonales);
        Task<Response<SimulacionDatosFinancierosDto>> CrearSimulacionDatosFinancieros(SimulacionDatosFinancierosDto datosFinancieros);
        Task<Response<ParametrosSimuladorDto>> ObtenerParametrosSimuladorAsync();
        Task<Response<ValidacionIdentidadDto>> ValidacionScoreCliente(ValidacionIdentidadDto validaDto);
        Task<Response<ValidacionIdentidadDto>> GetByIdValidacionIdentidad(Guid id);
        Task<Response<ValidacionIdentidadDto>> GetByDocumentoValidacionIdentidad(string noDocumento);
        Task<Response<string>> ObtenerOtpCliente(string request);
    }
}
