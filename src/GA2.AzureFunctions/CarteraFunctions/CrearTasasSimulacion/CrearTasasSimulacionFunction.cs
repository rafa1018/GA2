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

namespace CrearTasasSimulacion
{
    public class CrearTasasSimulacionFunction
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public CrearTasasSimulacionFunction(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        [Function("CrearTasasSimulacionFunction")]
        public async Task <HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Cartera - CrearTasasSimulacionFunction");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);


            var tasa = JsonConvert.DeserializeObject<TasaSimuladorDto>(body);
            var crearTasa = await this._carteraBusinessLogic.CrearTasasSimulacion(tasa);
            var result = JsonConvert.SerializeObject(crearTasa, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(result);            

            return response;
        }
    }
}
