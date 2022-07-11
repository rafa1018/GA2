using GA2.Application.Main;
using GA2.Domain.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Credito
{
    /// <summary>
    /// Aprobar comite de crédito
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>27/07/2021</date>
    public class ObtenerActividadFlujo
    {
        /// <summary>
        /// Business Logic
        /// </summary>
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerActividadFlujo(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerActividadFlujo")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerActividadFlujo")]
            HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - Functions");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await _creditoBusinessLogic.ObtenerActividadFlujo();
            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync(result);

            return response;
        }
    }
}
