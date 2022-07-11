using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
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
    public class ObtenerTipoActividadPorId
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
        public ObtenerTipoActividadPorId(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerTipoActividadPorId")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerTipoActividadPorId/{id}")]
            HttpRequestData req, string id, FunctionContext executionContext)
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

            var user = claims;
            var result = await _creditoBusinessLogic.ObtenerTipoActividadPorId(id);
            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<TipoActividadDto>>(result);

            return response;
        }
    }
}
