using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Provedor de peticiones Caja Honor
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/05/2021</date>
    /// </summary>
    public class ProviderRequestG2 : ProviderRequestFactory, IProviderRequestG2
    {
        /// <summary>
        /// Instancias de configuracion y claims
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>02/05/2021</date>
        private readonly IOptions<CHKeysOptions> _configuration;
        private readonly ICryptoGA2 _cryptoGA2;

        /// <summary>
        /// Constructor inyectando tokenclaims y configuracion de aplicacion
        /// </summary>
        /// <param name="configuration">Configuracion de aplicacion</param>
        /// <param name="cryptoGA2">Criptografia de aplicacion</param>
        /// <param name="tokenClaims">Tokem claims</param>
        public ProviderRequestG2(IOptions<CHKeysOptions> configuration, ICryptoGA2 cryptoGA2, ITokenClaims tokenClaims) : base(tokenClaims)
        {
            _configuration = configuration;
            _cryptoGA2 = cryptoGA2;
        }

        /// <summary>
        /// Obtener token de caja hohor
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>02/05/2021</date>
        /// <returns>Token caja honor</returns>
        private async Task<Response<string>> ObtenerToken()
        {
            var jsonPayload = this.CreatePayloadLoginAplicacion();
            var urlLogin = new Uri($"{_configuration.Value.UrlCajaHonor}{_configuration.Value.LoginCajaHonor}");
            return await PostExternalAsync<Response<string>>(jsonPayload, urlLogin);
        }

        /// <summary>
        /// Crear payload loging applicacion para obtener token
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>02/05/2021</date>
        /// <returns></returns>
        private JObject CreatePayloadLoginAplicacion()
        {

            var aplicacion = _configuration.Value.NombreAplicacion;
            var palabraClave = _configuration.Value.PhraseKey;
            var hash = _configuration.Value.HashAplicacion;
            var cadenaCifrar = $"{aplicacion}#~{hash}#~{DateTime.Now.Ticks}";
            var tokenCifrado = this._cryptoGA2.EncryptMD5(cadenaCifrar, palabraClave, true);

            dynamic payload = new JObject();
            payload.Token = tokenCifrado;
            payload.Username = _configuration.Value.NombreAplicacion;
            payload.Password = string.Empty;
            payload.Objectos = null;

            return payload;
        }

        /// <summary>
        /// Crear payload para obtener CHGUID
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>02/05/2021</date>
        /// <returns>Obtiene payload de CHGUID</returns>
        private JObject CreatePayloadRequestCHGUID(dynamic content, string tokenResult, string Extras = null)
        {
            var token = new JwtSecurityToken(tokenResult);
            string guidSession = token.Payload["ChGuid"].ToString();
            string cadenaRequest = content.ToString(Formatting.None) + "#~" + guidSession + "#~" + DateTime.Now.Ticks.ToString();
            var palabraClave = _configuration.Value.PhraseKey;
            string requestBody1 = this._cryptoGA2.EncryptMD5(cadenaRequest, palabraClave, true);
            string requestBody2 = this._cryptoGA2.GenerarHashString(cadenaRequest);

            dynamic payload = new JObject();
            payload.CHToken = requestBody1;
            payload.CHHash = requestBody2;
            payload.CHApplicacion = _configuration.Value.NombreAplicacion;
            payload.CHExtras = Extras;

            return payload;
        }

        /// <summary>
        /// Peticion Get generica caja honor
        /// </summary>
        /// <typeparam name="TOutput">Tipo de datos salida</typeparam>
        /// <param name="url">Url de peticion</param>
        /// <returns>Retorno de tipos generico</returns>
        public async Task<UsuarioDto> PruebaEjemploGetCHAsync<TOutput>(Uri url)
        {
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {this.ObtenerToken()}" }
            };
            return await GetExternalAsync<UsuarioDto>(url, headers);
        }

        /// <summary>
        /// Peticion Post caja honor
        /// </summary>
        /// <typeparam name="TOutput">Tipo de parametro a obtener</typeparam>
        /// <param name="obj">Objeto enviado como body</param>
        /// <param name="url">Url de peticion</param>
        /// <returns></returns>
        public async Task<CHResponse<ClienteDto>> PeticionUsuariosPostCHAsync(dynamic obj, Uri url)
        {
            var token = await this.ObtenerToken();
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {token}" }
            };

            var payload = this.CreatePayloadRequestCHGUID(obj, token.ToString());

            return await PostExternalAsync(payload, url, headers);
        }
    }
}
