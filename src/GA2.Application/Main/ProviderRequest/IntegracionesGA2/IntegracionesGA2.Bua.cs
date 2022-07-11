using GA2.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public partial class IntegracionesGA2: IIntegracionesGA2Bua
    {
        #region Bua
        /// <summary>
        /// Peticion Get generica caja honor
        /// </summary>
        /// <typeparam name="TOutput">Tipo de datos salida</typeparam>
        /// <param name="url">Url de peticion</param>
        /// <returns>Retorno de tipos generico</returns>
        public async Task<object> ObtenerBua<TOutput>(Uri url, ObtenerBuaRequest buaDto, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<object>(buaDto, url, headers);
        }

        #endregion
    }
}
