using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ActualizarTasasSimulacion
{
    public class ActualizarTasasSimulacion
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public ActualizarTasasSimulacion(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        [Function("ActualizarTasaSimulacionFunction")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Cartera - ActualizarTasasSimulacion");
            logger.LogInformation($"Actualizar Tasas {req.Body}");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var tasaActualizada = await this._carteraBusinessLogic.ActualizarTasasSimulacion(JsonConvert.DeserializeObject<TasaSimuladorDto>(body));
            var result = JsonConvert.SerializeObject(tasaActualizada, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(result);

            return response;
        }
    }
}
