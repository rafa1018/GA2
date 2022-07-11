using GA2.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Net;
using System.Threading.Tasks;
using HttpTriggerAttribute = Microsoft.Azure.Functions.Worker.HttpTriggerAttribute;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker.Http;
using System.Linq;

namespace GA2Functions.Endpoints.Credito.Simulador.Comite
{
    public class ObtenerDatosSolicComite
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
        public ObtenerDatosSolicComite(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerDatosSolicComite")]
        [OpenApiOperation(operationId: "ComiteCredito", tags: new[] { "Comite Credito" }, Summary = "ObtenerDatosSolicComite", Description = "Obtener Datos Solicitud Comité", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiParameter("id", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<DatosComiteCreditoDto>))]

        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "aprobarComiteCredito/{id}")] HttpRequestData req, string id, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Comite - Obtener Datos Solicitud");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            response.StatusCode = HttpStatusCode.OK;
            response.Headers.Remove("Content-Type");
            response.Headers.Add("Content-Type", "application/octet-stream");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    await response.WriteAsJsonAsync<FileResult>(await _creditoBusinessLogic.ObtenerDatosSolicComite(Guid.Parse(id)));
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            throw new Exception("Sin autorización");
        }
    }
}
