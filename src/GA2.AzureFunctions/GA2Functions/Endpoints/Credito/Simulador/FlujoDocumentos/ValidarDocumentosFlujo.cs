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
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using System.Net;

namespace GA2Functions.Endpoints.Credito.Simulador.FlujoDocumentos
{
    /// <summary>
    /// Endpoint validar los documentos en el flujo credito
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>26/07/2021</date>
    public class ValidarDocumentosFlujo
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
        public ValidarDocumentosFlujo(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ValidarDocumentosFlujo")]
        [OpenApiOperation(operationId: "DocumentosFlujo", tags: new[] { "Documentos Flujo" }, Summary = "ValidarDocumentosFlujo", Description = "Validar Documentos", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiRequestBody("application/json", typeof(ValidacionDocumentosDto))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<ValidacionDocumentosDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "validarDocumentosFlujo")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Documentos Flujo - Validar Documentos");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var body = await RequestBody.ReadRquestBodyFunction(req.Body);
                    var request = JsonConvert.DeserializeObject<ValidacionDocumentosDto>(body);
                    var result = await _creditoBusinessLogic.ValidarDocumentosFlujo(request);
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<ValidacionDocumentosDto> { ReturnMessage = ex.Message });
                }
            }

            return response;
            
        }

    }
}
