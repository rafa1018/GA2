using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GA2.GA2Functions.Endpoints.CatalogoEnpoints
{
    /// <summary>
    /// Endpoint Crear tipo credito
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class CrearTipoCredito
    {
        /// <summary>
        /// Servicios
        /// </summary>
        private readonly ICatalogosBusinessLogic _tipocreditoBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor del Endpoint Crear Tipo Credito
        /// </summary>
        /// <param name="tipocreditoBusinessLogic"></param>
        /// <param name="tokenClaims">Toekn servicio</param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearTipoCredito(ICatalogosBusinessLogic tipocreditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _tipocreditoBusinessLogic = tipocreditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint CrearTipoCredito
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>TipoViviendaDto</returns>
        [Function("CrearTipoCredito")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "actualizartipocredito")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CatalogoEndpoints - CrearTipoCredito");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var tipoCredito = JsonConvert.DeserializeObject<TipoCreditoDto>(body);

            var result = await _tipocreditoBusinessLogic.CrearTipoCredito(tipoCredito);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
