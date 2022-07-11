using GA2.Application.Dto;
using GA2.Application.Dto.Identity;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Interface cliente login GA2Paa
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    public interface ILoginRequestProvider
    {
        /// <summary>
        /// Obtener cliente login GA2Paa
        /// </summary>
        /// <param name="loginPaaDto">Cliente dto login</param>
        /// <author>OScar Julian Rojas Garces</author>
        /// <date>12/04/2021</date>
        /// <returns>Cliente Dto</returns>
        Task<Response<ClienteDto>> ObtenerClienteLoginGA2Paa(LoginPaaDto loginPaaDto);

        /// <summary>
        /// Login external application
        /// </summary>
        /// <param name="loginExternal">login external credentials</param>
        /// <author>OScar Julian Rojas Garces</author>
        /// <date>25/11/2021</date>
        /// <returns>Login external confirmation</returns>
        Task<Response<LoginExternalDto>> LoginExternal(LoginExternalDto loginExternal);
    }
}