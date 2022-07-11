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

namespace GA2Functions.Endpoints.Credito.Simulador.FuenteRecursos
{
    /// <summary>
    /// Endpoint obtener fuente de recursos
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>29/07/2021</date>
    public class ObtenerFuentesRecursos
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
        public ObtenerFuentesRecursos(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerFuentesRecursos")]

        [OpenApiOperation(operationId: "FuenteRecursos", tags: new[] { "Fuente Recursos" }, Summary = "ObtenerFuentesRecursos", Description = "Obtener Fuentes Recursos", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<FuenteRecursosDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerFuentesRecursos")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Fuentes Recursos - Obtener");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var result = await _creditoBusinessLogic.ObtenerFuentesRecursos();
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<FuenteRecursosDto> { ReturnMessage = ex.Message });
                }
            }

            return response;

        }
    }
}
