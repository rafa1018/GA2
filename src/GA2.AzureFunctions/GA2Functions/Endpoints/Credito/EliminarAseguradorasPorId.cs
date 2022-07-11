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
    /// Endpoint para Eliminar Aseguradoras Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    public class EliminarAseguradorasPorId
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
        public EliminarAseguradorasPorId(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("EliminarAseguradorasPorId")]
        public async Task<Response<AseguradorasDto>> Run([HttpTrigger(AuthorizationLevel.User, "delete", Route = "eliminarAseguradorasPorId/{id}")] string req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Eliminar Aseguradoras Flujo Id");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _creditoBusinessLogic.EliminarAseguradorasPorid(req);
        }
    }
}
