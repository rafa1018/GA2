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

namespace GA2Functions.Endpoints.CatalogoEnpoints
{
    public class ObtenerTiposIdentificacion
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor de Endpoint Tipos Identificacion
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerTiposIdentificacion(ICatalogosBusinessLogic catalogsBusinessLogic, ITokenClaims token)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
            _tokenClaims = token;
        }

        /// <summary>
        /// Endpoint obtener catalos 
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>TipoViviendaDto</returns>
        [Function("ObtenerTiposIdentificacion")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "ObtenerTiposIdentificacion")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CatalogoEndpoints - ObtenerTiposIdentificacion");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse(HttpStatusCode.OK);

            if (!_tokenClaims.EsTokenValido(token, out _))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result =  await _catalogsBusinessLogic.ObtenerTiposIdentificacion();

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
