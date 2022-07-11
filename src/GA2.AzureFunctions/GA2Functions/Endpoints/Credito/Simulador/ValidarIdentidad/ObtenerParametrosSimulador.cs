using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Credito.Simulador.ValidarIdentidad
{
    /// <summary>
    /// Obtiene los parametros requeridos por el simulador
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>02/08/2021</date>
    public class ObtenerParametrosSimulador
    {
        /// <summary>
        /// Business Logic
        /// </summary>
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerParametrosSimulador(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        [Function("ObtenerParametrosSimulador")]
        public async Task<Response<ParametrosSimuladorDto>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "obtenerParametrosSimulador")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Validacion Identidad - Obtener Parametros");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _identidadBusinessLogic.ObtenerParametrosSimuladorAsync();
        }
    }
}
