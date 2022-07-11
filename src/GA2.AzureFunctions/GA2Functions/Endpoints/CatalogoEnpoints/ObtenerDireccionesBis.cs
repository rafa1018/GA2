using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GA2.GA2Functions.Endpoints.CatalogoEnpoints
{
    /// <summary>
    /// Endpoint obtener direcciones bis
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>11/08/2021</date>
    public class ObtenerDireccionesBis
    {
        /// <summary>
        /// Servicios
        /// </summary>
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// logica catalogos
        /// </summary>
        /// <param name="catalogsBusinessLogic">Catalogo servicio</param>
        /// <param name="tokenClaims">Token servicio</param>
        public ObtenerDireccionesBis(ICatalogosBusinessLogic catalogsBusinessLogic, ITokenClaims tokenClaims)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint obtener catalos 
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>TipoViviendaDto</returns>
        [Function("ObtenerDireccionesBis")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerdireccionesbis")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CatalogoEndpoints - obtenerdireccionesbis");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out _))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await this._catalogsBusinessLogic.ObtenerDireccionesBis();

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
