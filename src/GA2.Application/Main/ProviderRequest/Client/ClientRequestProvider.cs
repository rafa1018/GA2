using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Clase que hace llamado a api BUA para consultar si existe un cliente
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class ClientRequestProvider : ProviderRequestFactory, IClientRequestProvider
    {
        private readonly IOptions<ApisOptions> _optionsApis;
        public ClientRequestProvider(ITokenClaims tokenClaims, IOptions<ApisOptions> optionsApis) : base(tokenClaims)
        {
            _optionsApis = optionsApis;
        }

        /// <summary>
        /// Metodo que consult a la api
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        public async Task<Response<IEnumerable<ClienteSinCrearDTO>>> RegistrarClientesCargueNomina(string componentes)
        {
            var response = await PostAsyncFile<Response<IEnumerable<ClienteSinCrearDTO>>>(componentes, new Uri(
                 this._optionsApis.Value.BUA + RequestProviderConstants.ApiBuaValidarClientes));

            return response;
        }

        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="identificationNumber">Identificacion del cliente</param>
        /// <param name="identificationType">Tipo de identificacion</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public async Task<Response<ClienteCesantiasDto>> ObtenerInformacionClientePorDocumentoYTipo(int IdTipoIdentificacion, string Identificacion, int IdCliente) {

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerInformacionClientePorDocumentoYTipo +
                     $"?tipoDocumentoId={IdTipoIdentificacion}&numeroDocumento={Identificacion}" + 
                     $"&idCLiente={IdCliente}";
            var response = await GetAsync<Response<ClienteCesantiasDto>>(new Uri(url));

            return response;
        }

        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="identificationNumber">Identificacion del cliente</param>
        /// <param name="identificationType">Tipo de identificacion</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public async Task<Response<ClienteDto>> ObtenerClientePorTipoIdentificationYNumero(int identificationType, string identificationNumber)
        {

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerClientePorTipoIdentificationYNumero +
                     $"?tipoDocumentoId={identificationType}&numeroDocumento={identificationNumber}";
            var response = await GetAsync<Response<ClienteDto>>(new Uri(url));

            return response;
        }



        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="IdCliente">Id del cliente</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public async Task<Response<ClienteDto>> ObtenerClienteInformacion(int IdCliente) {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerClienteInformacion +
                     $"?request={IdCliente}";
            var response = await GetAsync<Response<ClienteDto>>(new Uri(url));

            return response;
        }


        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="identificacionCliente">Identificacion del cliente</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public async Task<Response<ClienteCedulaDto>> ObtenerInformacionClienteCedula(int identificacionCliente) {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerInformacionClienteCedula +
                     $"?identificacionCliente={identificacionCliente}";
            var response = await GetAsync<Response<ClienteCedulaDto>>(new Uri(url));

            return response;
        }

        /// <summary>
        /// Metodo que consult a la api de bua, obtener cliente
        /// </summary>
        /// <param name="IdCliente">Id del cliente</param>
        /// <returns></returns>
        /// <author>Erwin Pantoja España</author>
        /// <date>05/10/2021</date>
        public async Task<Response<CuentaDto>> ObtenerCuentaById(string IdCliente)
        {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerCuentaById +
                     $"?request={IdCliente}";
            var response = await GetAsync<Response<CuentaDto>>(new Uri(url));

            return response;
        }

        public async Task<Response<CuentaDto>> ObtenerCuentaClieteByIdNumeroCuenta(int idCilente, int numeroCuenta)
        {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerCuentaClieteByIdNumeroCuenta +
                    $"?NumeroCuenta={numeroCuenta}&Idcliente={idCilente}";
            var response = await GetAsync<Response<CuentaDto>>(new Uri(url));

            return response;
        }


        public async Task<Response<IEnumerable<ClienteDto>>> ObtenerClientesById(string ids)
        {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerClientesById +$"?request={ids}";
            var response = await GetAsync<Response<IEnumerable<ClienteDto>>>(new Uri(url));

            return response;
        }

        public async Task<Response<ClienteCedulaDto>> ObtenerClientesByNumeroIdentificacion(string identificacion)
        {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerInformacionByCedula + "?identificacion=" +identificacion;
            var response = await GetAsync<Response<ClienteCedulaDto>>(new Uri(url));

            return response;
        }


        public async Task<Response<IEnumerable<CuentaDto>>> ObtenerCuentaIdCuenta(string idsCuentas)
        {
            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerCuentaIdCuenta +
                    $"?request={idsCuentas}";
            var response = await GetAsync<Response<IEnumerable<CuentaDto>>>(new Uri(url));

            return response;
        }

        public async Task<Response<InfoClienteDto>> ObtenerInfoCliente(int tpo_identificacion, string num_identificacion)
        {

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerInformacionCliente+
                    $"?tipoDocumentoId={tpo_identificacion}&numeroDocumento={num_identificacion}";
            var response = await GetAsync<Response<InfoClienteDto>>(new Uri(url));

            return response;

        }

        public async Task<Response<IEnumerable<CuentaClienteDto>>> ObtenerCuentasClienteId(int idCilente)
        {

            string url = this._optionsApis.Value.BUA + RequestProviderConstants.ObtenerCuentasClienteId +
                    $"?request={idCilente}";
            var response = await GetAsync<Response<IEnumerable<CuentaClienteDto>>>(new Uri(url));

            return response;
        
        }
    }
}
