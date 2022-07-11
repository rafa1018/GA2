using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;

namespace GA2Functions.Endpoints.Credito.Simulador.Comite
{
    /// <summary>
    /// Obtener Integrantes Comite
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>28/07/2021</date>
    public class ObtenerIntegranteComite
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
        public ObtenerIntegranteComite(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerIntegranteComite")]

        [OpenApiOperation(operationId: "ComiteCredito", tags: new[] { "Comite Credito" }, Summary = "ObtenerIntegranteComite", Description = "Obtiene Integrante Comité", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<IEnumerable<IntegranteComiteDto>>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerIntegranteComite")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Comite - Crear Tema");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var result = await _creditoBusinessLogic.ObtenerIntegranteComite();
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<IEnumerable<IntegranteComiteDto>> { ReturnMessage = ex.Message });
                }
            }
            return response;
        }
    }
}
