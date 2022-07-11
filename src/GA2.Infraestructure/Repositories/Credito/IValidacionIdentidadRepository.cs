using GA2.Domain.Entities;
using GA2.Domain.Entities.Credito.Simulador;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IValidacionIdentidadRepository
    {
        Task<ValidacionIdentidad> CreateValidacionIdentidad(ValidacionIdentidad valida);
        Task<int> ActualizarValidacionOTP(ValidacionIdentidad valida);
        Task<SimulacionDatosFinancieros> ObtenerDatosFinancierosAsync(string numeroDocumento);
        Task<SimulacionDatosPersonales> ObtenerDatosPersonalesAsync(string nuemroDocumento);
        Task<List<SimulacionSolicitud>> ConsultarPreAprobado(string numeroDocumento);
        Task<SimulacionDatosPersonales> CrearSimulacionDP(SimulacionDatosPersonales datos);
        Task<SimulacionDatosFinancieros> CrearSimulacionDF(SimulacionDatosFinancieros datos);
        Task<ParametrosSimulador> ObtenerParametrosSimulador();
        Task<ConsultaBuroCliente> CrearConsultaBuro(ConsultaBuroCliente consulta);
        #region Revisar
        Task<List<SocSolicitudCredito>> ConsultarSolicitudCredito(string numeroDocumento);
        Task<ValidacionIdentidad> GetByIdSolicitudSimulacion(Guid id);
        Task<ValidacionIdentidad> GetByDocumentoSolicitudSimulacion(string noDocumento);
        #endregion
    }
}
