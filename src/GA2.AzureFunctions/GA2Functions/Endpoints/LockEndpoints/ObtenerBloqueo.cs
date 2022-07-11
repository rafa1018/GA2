using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.LockEndpoints
{
    public class ObtenerBloqueo
    {
        private readonly IBloqueoBusinessLogic _lockBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockBusinessLogic"></param>
        public ObtenerBloqueo(IBloqueoBusinessLogic lockBusinessLogic)
        {
            _lockBusinessLogic = lockBusinessLogic;
        }

        /// <summary>
        /// Endpoint EliminarBloqueo
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("ObtenerBloqueo")]
        public async Task<Response<IEnumerable<BloqueoDto>>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "bloqueo/ObtenerBloqueo")] HttpRequest req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("LockEnpoints - bloqueo/ObtenerBloqueo");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _lockBusinessLogic.ObtenerBloqueoAsync();
        }
    }
}
