using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public partial class IntegracionesGA2
    {
        /// <summary>
        /// Petición get Vigia Carga Producto Tercero
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>15/07/2021</date>
        /// <typeparam name="TOutput">Tipo de datos salida</typeparam>
        /// <param name="url">Url de peticion</param>
        /// <param name="cargaProductoTerceroRequest">Objeto Base endpoint</param>
        /// <param name="correlationId"></param>
        /// <param name="userId">id del usuario</param>
        /// <returns></returns>
        public async Task<object> CargaProductoTercero<TOutput>(Uri url, CargaProductoTerceroRequest cargaProductoTerceroRequest, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(cargaProductoTerceroRequest, url, headers);
        }
        /// <summary>
        /// Petición get Vigia Carga Tercero Request
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>15/07/2021</date>
        /// <typeparam name="TOutput">Tipo de datos salida</typeparam>
        /// <param name="url">Url de peticion</param>
        /// <param name="cargaTerceroRequest">Objeto Base endpoint</param>
        /// <param name="correlationId"></param>
        /// <param name="userId">id del usuario</param>
        /// <returns></returns>
        public async Task<object> CargaTercero<TOutput>(Uri url, CargaTerceroRequest cargaTerceroRequest, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(cargaTerceroRequest, url, headers);
        }
        /// <summary>
        /// Petición get Vigia carga Transaccion Request
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>15/07/2021</date>
        /// <typeparam name="TOutput">Tipo de datos salida</typeparam>
        /// <param name="url">Url de peticion</param>
        /// <param name="cargaTransaccionRequest">Objeto Base endpoint</param>
        /// <param name="correlationId"></param>
        /// <param name="userId">id del usuario</param>
        /// <returns></returns>

        public async Task<object> CargaTransaccion<TOutput>(Uri url, CargaTransaccionRequest cargaTransaccionRequest, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(cargaTransaccionRequest, url, headers);
        }
        /// <summary>
        /// Petición get Vigia verificacion Tercero Request
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>15/07/2021</date>
        /// <typeparam name="TOutput">Tipo de datos salida</typeparam>
        /// <param name="url">Url de peticion</param>
        /// <param name="verificacionTerceroRequest">Objeto Base endpoint</param>
        /// <param name="correlationId"></param>
        /// <param name="userId">id del usuario</param>
        /// <returns></returns>
        public async Task<Response<ResultadoVerificacionTercero>> VerificacionTercero<TOutput>(Uri url, VerificacionTerceroRequest verificacionTerceroRequest, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };
            var result = await PostExternalAsync<object>(verificacionTerceroRequest, url, headers);
            return await PostExternalAsync<Response<ResultadoVerificacionTercero>>(verificacionTerceroRequest, url, headers);
        }
        

    }
}
