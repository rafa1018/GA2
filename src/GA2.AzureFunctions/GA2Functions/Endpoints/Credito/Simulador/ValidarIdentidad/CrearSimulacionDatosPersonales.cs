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
    /// Crear simulacion datos Personales
    /// </summary>
    /// <author>Nicolas FLorez Sarrazola</author>
    /// <date>02/08/2021</date>
    public class CrearSimulacionDatosPersonales
    {
        /// <summary>
        /// Business Logic
        /// </summary>
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSimulacionDatosPersonales(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        [Function("CrearSimulacionDatosPersonales")]
        public async Task<Response<object>> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "crearSimulacionDatosPersonales")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Validacion Identidad - Validar");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<SimulacionDatosPersonalesDto>(body);
            return null;//await _identidadBusinessLogic.CrearSimulacionDatosPersonales(request);
        }
    }
}
