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

namespace GA2Functions.Endpoints.Credito.Simulador.ValidarIdentidad
{
    /// <summary>
    /// Validar score cliente
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>03/08/2021</date>
    public class ValidacionScoreCliente
    {
        /// <summary>
        /// Business Logic
        /// </summary>
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ValidacionScoreCliente(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        [Function("ValidacionScoreCliente")]
        public async Task<Response<ValidacionIdentidadDto>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "validacionScoreCliente")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Validacion Identidad - Selecciona Credito");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<ValidacionIdentidadDto>(body);

            return await _identidadBusinessLogic.ValidacionScoreCliente(request);
        }
    }
}
