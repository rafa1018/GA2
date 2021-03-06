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
    /// Actualización de la información ingresada por el usuario del codigo OTP
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>02/08/2021</date>
    public class ActualizarInformacionOtp
    {
        /// <summary>
        /// Business Logic
        /// </summary>
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizarInformacionOtp(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        [Function("ActualizarInformacionOtp")]
        public async Task<Response<ValidacionIdentidadDto>> Run([HttpTrigger(AuthorizationLevel.User, "put", Route = "actualizarInformacionOtp")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Validacion Identidad - Validar");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<ValidacionIdentidadDto>(body);
            return await _identidadBusinessLogic.ActualizarValidacionOTP(request);
        }
    }
}
