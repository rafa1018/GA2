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

namespace EliminarRegistroSimuladorPorId
{
    public  class EliminarRegistroSimuladorPorId
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public EliminarRegistroSimuladorPorId(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        [Function("EliminarRegistroSimuladorPorId")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function,"post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("EliminarRegistroSimuladorPorId");
            logger.LogInformation($"Eliminar registro segun ID {req.Body}" );

            var response = req.CreateResponse(HttpStatusCode.OK);
            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var tasaEliminada = await this._carteraBusinessLogic.EliminarRegistroSimuladorPorId(JsonConvert.DeserializeObject<TasaSimuladorDto>(body));
            var result = JsonConvert.SerializeObject(tasaEliminada, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(result);

            return response;
        }
    }
}
