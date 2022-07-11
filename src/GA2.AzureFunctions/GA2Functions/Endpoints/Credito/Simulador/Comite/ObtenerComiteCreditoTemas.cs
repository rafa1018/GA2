using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;

namespace GA2Functions.Endpoints.Credito.Simulador.Comite
{
    /// <summary>
    /// Obtinee los temas del comite de crédito
    /// </summary>
    public class ObtenerComiteCreditoTemas
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
        public ObtenerComiteCreditoTemas(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerComiteCreditoTemas")]
        [OpenApiOperation(operationId: "ComiteCredito", tags: new[] { "Comite Credito" }, Summary = "ObtenerComiteCreditoTemas", Description = "Obtener Temas Comité", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiRequestBody("application/json", typeof(RequestTemaComiteCreditoDto))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<TemaComiteCreditoDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "obtenerComiteCreditoTemas")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Comite - Obtener Temas Comite");
            logger.LogInformation("C# HTTP trigger function processed a request.");


            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var body = await RequestBody.ReadRquestBodyFunction(req.Body);
                    var request = JsonConvert.DeserializeObject<RequestTemaComiteCreditoDto>(body);
                    var result = await _creditoBusinessLogic.ObtenerComiteCreditoTemas(request);
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<TemaComiteCreditoDto> { ReturnMessage = ex.Message });
                }
            }

            return response;
        }
    }
}
