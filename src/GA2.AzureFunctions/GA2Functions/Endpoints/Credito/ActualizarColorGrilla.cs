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

namespace GA2Functions.Endpoints.Credito
{
    /// <summary>
    /// Actualizar color grilla
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>03/08/2021</date>
    public class ActualizarColorGrilla
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
        public ActualizarColorGrilla(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ActualizarColorGrilla")]
        public async Task<Response<ColorGrillaDto>> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "actualizarColorGrilla")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Actualizar color grilla");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<ColorGrillaDto>(body);

            return await _creditoBusinessLogic.ActualizarColorGrilla(request);
        }
    }
}
