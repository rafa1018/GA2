using GA2.Application.Dto;
using GA2.Application.Dto.Identity;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Implementacion Interface LoginRequestProvider
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>12/04/2021</date>
    public class LoginRequestProvider : ProviderRequestFactory, ILoginRequestProvider
    {
        /// <summary>
        /// Interface configuration
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>12/04/2021</date>
        private readonly IOptions<ApisOptions> _optionsApis;

        public LoginRequestProvider(ITokenClaims tokenClaims, IOptions<ApisOptions> optionsApis) : base(tokenClaims)
        {
            _optionsApis = optionsApis;
        }

        /// <summary>
        /// Login external application
        /// </summary>
        /// <param name="loginExternal">login external credentials</param>
        /// <author>OScar Julian Rojas Garces</author>
        /// <date>25/11/2021</date>
        /// <returns>Login external confirmation</returns>
        public async Task<Response<LoginExternalDto>> LoginExternal(LoginExternalDto loginExternal)
        {
            var response = new Response<LoginExternalDto>
            {
                Data = await PostAsync<LoginExternalDto>(loginExternal, new Uri(
                    this._optionsApis.Value.LoginExternal))
            };

            return response;
        }

        /// <summary>
        /// Obtener cliente login paa metodo
        /// </summary>
        /// <param name="loginPaaDto">login Dto</param>
        /// <date>12/04/2021</date>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <returns>Cliente Dto</returns>
        public async Task<Response<ClienteDto>> ObtenerClienteLoginGA2Paa(LoginPaaDto loginPaaDto)
        {
            var response = await GetAsync<Response<ClienteDto>>(new Uri(
                this._optionsApis.Value.BUA +
                ObtenerUrlStringLoginPaa(loginPaaDto)));

            return response;
        }

        /// <summary>
        /// OBtenerUrlStringLoginPaa
        /// </summary>
        /// <param name="loginPaaDto">Login paa</param>
        /// <returns>Cadena de url direccion del servicio</returns>
        private static string ObtenerUrlStringLoginPaa(LoginPaaDto loginPaaDto)
        {
            return string.Format(
                RequestProviderConstants.UrlLoginGA2Paa,
                loginPaaDto.TipoDocumento,
                loginPaaDto.NumeroIdentificacion,
                loginPaaDto.NumeroCelular,
                loginPaaDto.FechaExpedicion.ToString("yyyy-MM-dd"));
        }
    }
}
