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
    /// Endpoint Obtener categorias
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>11/08/2021</date>
    public class ObtenerCategorias
    {
        /// <summary>
        /// Servicios
        /// </summary>
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor de Endpoint Obtener Categorias
        /// </summary>
        /// <param name="catalogsBusinessLogic">servicio catalgos</param>
        /// <param name="tokenClaims">Servicio token </param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerCategorias(ICatalogosBusinessLogic catalogsBusinessLogic, ITokenClaims tokenClaims)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint obtener catalos 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="executionContext">context functions</param>
        /// <returns>CategoriaDto</returns>
        [Function("ObtenerCategorias")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenercategorias")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CatalogoEndpoints - obtenerCatalogos");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();
            if (!_tokenClaims.EsTokenValido(token, out _))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await this._catalogsBusinessLogic.ObtenerCategorias();

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
