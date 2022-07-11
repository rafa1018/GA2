using GA2.Application.Main;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using System.IO;
using GA2.Transversals.Commons;
using System.Net.Http;

namespace GA2Functions.Endpoints.Credito.Simulador.Comite
{
    /// <summary>
    /// Genera Acta de Comite de Crédito
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>04/08/2021</date>
    public class GenerarActaComite
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
        public GenerarActaComite(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("GenerarActaComite")]

        [OpenApiOperation(operationId: "ComiteCredito", tags: new[] { "Comite Credito" }, Summary = "GenerarActaComite", Description = "Genera Acta Comité", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiParameter("id", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/octet-stream", typeof(Stream))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "generarActaComite/{id}")] HttpRequestData req, string id, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Comite - Aprobar Comite");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            response.StatusCode = HttpStatusCode.OK;
            response.Headers.Remove("Content-Type");
            //response.Headers.Add("Content-Type", "application/octet-stream");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var file= (await _creditoBusinessLogic.GenerarActaComite(int.Parse(id)));
                    return response;
                }
                catch (Exception ex)
                {
                    await response.WriteAsJsonAsync(new Response<object>() { ReturnMessage = ex.Message });
                    return response;
                }
            }

            return response;

        }
    }
}
