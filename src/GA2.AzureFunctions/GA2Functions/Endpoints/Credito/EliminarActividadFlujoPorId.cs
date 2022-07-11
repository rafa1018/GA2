using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Credito
{
    class EliminarActividadFlujoPorId
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
        public EliminarActividadFlujoPorId(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("EliminarActividadFlujoPorId")]
        public async Task<Response<ActividadFlujoDto>> Run([HttpTrigger(AuthorizationLevel.User, "delete", Route = "eliminarActividadFlujoPorId/{id}")] string req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Eliminar Actividad Flujo Id");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _creditoBusinessLogic.EliminarActividadFlujoPorid(req);
        }
    }
}
