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

namespace GA2Functions.Endpoints.Credito.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Obtener datos de reparto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>02/08/2021</date>
    public class ObtenerDatosReparto
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
        public ObtenerDatosReparto(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerDatosReparto")]
        [OpenApiOperation(operationId: "LegalizacionDesembolso", tags: new[] { "Legalizacion Desembolso" }, Summary = "ObtenerDatosReparto", Description = "Obtener Datos Reparto", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiParameter("id", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<DatosRepartoDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerDatosReparto/{id}")] HttpRequestData req, string id, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Legalizacion y Desembolso - Obtener Datos Reparto");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var result = await _creditoBusinessLogic.ObtenerDatosReparto(Guid.Parse(id));
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<DatosRepartoDto> { ReturnMessage = ex.Message });
                }
            }

            return response;
        }
    }
}
