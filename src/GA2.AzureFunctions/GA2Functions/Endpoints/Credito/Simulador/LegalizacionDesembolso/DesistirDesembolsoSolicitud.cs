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
using System.Net;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace GA2Functions.Endpoints.Credito.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Desistir de desembolso
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>29/07/2021</date>
    public class DesistirDesembolsoSolicitud
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
        public DesistirDesembolsoSolicitud(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("DesistirDesembolsoSolicitud")]
        [OpenApiOperation(operationId: "LegalizacionDesembolso", tags: new[] { "Legalizacion Desembolso" }, Summary = "DesistirDesembolsoSolicitud", Description = "Desistir Desembolso Solicitud", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityLocationType.Header)]
        [OpenApiRequestBody("application/json", typeof(DesembolsoCreditoSolicitudDto))]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<DesembolsoCreditoSolicitudDto>))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "desistirDesembolsoSolicitud")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Legalizacion y Desembolso - Desistir");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = _tokenClaims.TokenValidation(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var body = await RequestBody.ReadRquestBodyFunction(req.Body);
                    var request = JsonConvert.DeserializeObject<DesistimientoDesembolsoDto>(body);
                    var result = await _creditoBusinessLogic.DesistirDesembolsoSolicitud(request);
                    await response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(new Response<DesistimientoDesembolsoDto> { ReturnMessage = ex.Message });
                }
            }

            return response;
        }
    }
}
