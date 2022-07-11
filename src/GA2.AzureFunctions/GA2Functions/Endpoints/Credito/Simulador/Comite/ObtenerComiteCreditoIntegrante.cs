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
    /// Obtener integrante por comite
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>28/07/2021</date>
    public class ObtenerComiteCreditoIntegrante
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
        public ObtenerComiteCreditoIntegrante(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerComiteCreditoIntegrante")]

        [OpenApiOperation(operationId: "ComiteCredito", tags: new[] { "Comite Credito" }, Summary = "ObtenerComiteCreditoIntegrante", Description = "Obetener Integrante Comité", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiRequestBody("application/json", typeof(IntegrantePorComiteDto))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<IntegrantePorComiteDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "obtenerComiteCreditoIntegrante")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Comite - Obtener Integrantes Comite");
            logger.LogInformation("C# HTTP trigger function processed a request.");


            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var body = await RequestBody.ReadRquestBodyFunction(req.Body);
                    var request = JsonConvert.DeserializeObject<IntegrantePorComiteDto>(body);
                    var result = await _creditoBusinessLogic.ObtenerComiteCreditoIntegrante(request);
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<IntegrantePorComiteDto> { ReturnMessage = ex.Message });
                }
            }

            return response;
        }
    }

}
