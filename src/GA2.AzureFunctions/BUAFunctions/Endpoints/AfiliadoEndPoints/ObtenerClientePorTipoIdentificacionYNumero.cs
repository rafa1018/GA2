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

namespace GA2.BUAFunctions.Endpoints.AfiliadoEndPoints
{
    /// <summary>
    /// Endpoint function Login
    /// </summary>
    /// <date>23/07/2021</date>
    public class ObtenerClientePorTipoIdentificacionYNumero
    {
        /// <summary>
        /// logic Business Identity
        /// </summary>
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loginBusinessLogic">Service Logic Business</param>
        public ObtenerClientePorTipoIdentificacionYNumero(IClientesBusinessLogic clientsBusinessLogic, ITokenClaims tokenClaims)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint login post
        /// </summary>
        /// <param name="req">loginDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("ObtenerAfiliadoPorTipoIdentificacionYNumero")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "obtenerclienteportipoidentificationynumero/{tipoDocumentoId}/{numeroDocumento}")]
                HttpRequestData req, int tipoDocumentoId, string numeroDocumento, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BUA - ObtenerAfiliadoPorTipoIdentificacionYNumero");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await _clientsBusinessLogic.ObtenerClientePorTipoIdentificationYNumero(tipoDocumentoId, numeroDocumento, claims);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
