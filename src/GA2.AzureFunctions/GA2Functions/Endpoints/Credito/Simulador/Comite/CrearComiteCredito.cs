using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Credito.Simulador.Comite
{
    /// <summary>
    /// Crea comite de crédito
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>28/07/2021</date>
    public class CrearComiteCredito
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
        public CrearComiteCredito(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("CrearComiteCredito")]

        [OpenApiOperation(operationId: "ComiteCredito", tags: new[] { "Comite Credito" }, Summary = "CrearComiteCredito", Description = "Crea Comité", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiRequestBody("application/json", typeof(DatosComiteCreditoDto))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<DatosComiteCreditoDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "crearComiteCredito")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Comite - Crear Comite");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var body = await RequestBody.ReadRquestBodyFunction(req.Body);
                    var request = JsonConvert.DeserializeObject<DatosComiteCreditoDto>(body);
                    var result = await _creditoBusinessLogic.CrearComiteCredito(request);
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<DatosComiteCreditoDto> { ReturnMessage = ex.Message });
                }
            }
            
            return response;
        }


    }
}
