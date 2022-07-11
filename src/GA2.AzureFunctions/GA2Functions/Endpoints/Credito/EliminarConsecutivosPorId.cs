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
    /// <summary>
    /// Endpoint para Eliminar Consecutivos Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    class EliminarConsecutivosPorId
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
        public EliminarConsecutivosPorId(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("EliminarConsecutivosPorId")]
        public async Task<Response<ConsecutivoDto>> Run([HttpTrigger(AuthorizationLevel.User, "delete", Route = "EliminarConsecutivosPorId/{id}")] string req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Eliminar Consecutivo Id");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _creditoBusinessLogic.EliminarConsecutivoPorid(req);
        }
    }
}
