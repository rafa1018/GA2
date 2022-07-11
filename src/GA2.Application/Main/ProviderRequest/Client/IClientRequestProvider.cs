using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Metodo que expone la logica de negocio para consultar api y taer clientes no creados
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public interface IClientRequestProvider
    {
        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="identificationNumber">Identificacion del cliente</param>
        /// <param name="identificationType">Tipo de identificacion</param>
        /// <param name="idCLiente"></param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        Task<Response<ClienteCesantiasDto>> ObtenerInformacionClientePorDocumentoYTipo(int identificationType, string identificationNumber, int idCLiente);

        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="tipoDocumentoId">Identificacion del cliente</param>
        /// <param name="numeroDocumento">Tipo de identificacion</param>
        /// <returns></returns>
        /// <author>Ezequiel Arevalo</author>
        /// <date>05/10/2021</date>
        Task<Response<ClienteDto>> ObtenerClientePorTipoIdentificationYNumero(int tipoDocumentoId, string numeroDocumento);

        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="IdCliente">Id del cliente</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        Task<Response<ClienteDto>> ObtenerClienteInformacion(int IdCliente);

        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="identificacionCliente">Identificacion del cliente</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        Task<Response<ClienteCedulaDto>> ObtenerInformacionClienteCedula(int identificacionCliente);
        Task<Response<IEnumerable<ClienteSinCrearDTO>>> RegistrarClientesCargueNomina(string componentes);
        Task<Response<CuentaDto>> ObtenerCuentaById(string cedula);

        Task<Response<CuentaDto>> ObtenerCuentaClieteByIdNumeroCuenta(int idCilente,int numeroCuenta);

        Task<Response<IEnumerable<ClienteDto>>> ObtenerClientesById(string ids);

        Task<Response<ClienteCedulaDto>> ObtenerClientesByNumeroIdentificacion(string identificacion);

        Task<Response<IEnumerable<CuentaDto>>> ObtenerCuentaIdCuenta(string idCuenta);

        Task<Response<InfoClienteDto>> ObtenerInfoCliente(int tpo_identificacion, string num_identificacion);

        Task<Response<IEnumerable<CuentaClienteDto>>> ObtenerCuentasClienteId(int idCilente);

    }
}