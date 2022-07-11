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

namespace ObtenerProductoCliente
{
    public class ObtenerProductoClienteFunction
    {
        private readonly ICarteraBusinessLogic _carteraBusinnesLogic;


        public ObtenerProductoClienteFunction(ICarteraBusinessLogic carteraBusinnesLogic)
        {
            _carteraBusinnesLogic = carteraBusinnesLogic;
        }

        [Function("ObtenerProductoClienteFunction")]
        public async  Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Cartera - ObtenerProductoClienteFunction");
            logger.LogInformation($"Obtiene producto por cliente req {req.Body}");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var solicitudProductoPorCliente = JsonConvert.DeserializeObject<SolicitudProductoPorClienteDto>(body);

           await response.WriteAsJsonAsync(await _carteraBusinnesLogic.ObtenerProductoCliente(solicitudProductoPorCliente));

            return response;
        }
    }
}
