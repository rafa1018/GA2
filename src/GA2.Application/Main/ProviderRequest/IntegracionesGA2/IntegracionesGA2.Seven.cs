using GA2.Application.Dto;
using GA2.Application.Dto.Seven;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public partial class IntegracionesGA2
    {
        /// <summary>
        /// Peticion Seven crear Cdp
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="correlationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> CrearCDP<TOutput>(Uri url, CrearCDPRequestDto crearCDPRequestDto, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(crearCDPRequestDto, url, headers);
        }
        
        /// <summary>
        /// Peticion Seven anular Cdp
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="correlationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> AnularCDP<TOutput>(Uri url, AnularCDPRequestDto request, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(request, url, headers);
        }

        /// <summary>
        /// Peticion Seven Obtener Cuenta Contable
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="correlationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<object> ObtenerCuentaContable<TOutput>(Uri url, GetCuentaContableRequestDto request, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(request, url, headers);
        }
    }
}
