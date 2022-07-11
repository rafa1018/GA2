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
    /// Endpoint para Eliminar Alerta Automaticas Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    public class EliminarAlertaAutomaticasPorId
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
        public EliminarAlertaAutomaticasPorId(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("EliminarAlertaAutomaticasPorId")]
        public async Task<Response<AlertaAutomaticasDto>> Run([HttpTrigger(AuthorizationLevel.User, "delete", Route = "eliminarAlertaAutomaticasPorId/{id}")] string req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Eliminar Alerta Automatica Id");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _creditoBusinessLogic.EliminarAlertaAutomaticasPorid(req);
        }
    }
}
