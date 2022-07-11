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

namespace GA2Functions.Endpoints.Credito.Simulador
{
    /// <summary>
    /// Endpoint para actualizar aseguradoras
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>03/08/2021</date>
    public class ActualizarAseguradoras
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
        public ActualizarAseguradoras(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ActualizarAseguradoras")]
        public async Task<Response<AseguradorasDto>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "actualizarAseguradoras")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Actualizar aseguradoras");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<AseguradorasDto>(body);

            return await _creditoBusinessLogic.ActualizarAseguradoras(request);
        }
    }
}
