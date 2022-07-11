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
    /// Endpoint obtener direcciones tipos
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>11/08/2021</date>
    public class ObtenerDireccionesTipos
    {
        /// <summary>
        /// Servicios
        /// </summary>
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor de Endpoint Obtener Direcciones Tipos
        /// </summary>
        /// <param name="catalogsBusinessLogic">Servicio catalogos</param>
        /// <param name="tokenClaims">Token servicio</param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerDireccionesTipos(ICatalogosBusinessLogic catalogsBusinessLogic, ITokenClaims tokenClaims)
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
        [Function("ObtenerDireccionesTipos")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerdireccionestipos")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CatalogoEndpoints - obtenerdireccionestipos");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out _))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await _catalogsBusinessLogic.ObtenerDireccionesTipos();

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
