using GA2.Application.Main;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Credito.Simulador.HistorialCrediticio
{
    /// <summary>
    /// Endpoint obtener historial comercial
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>29/07/2021</date>
    public class ObtenerHistorialComercialBuro
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
        public ObtenerHistorialComercialBuro(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        [Function("ObtenerHistorialComercialBuro")]
        public async Task<FileResult> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "obtenerHistorialComercialBuro/")] string id, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Historial Comercial - Obtener");
            logger.LogInformation("C# HTTP trigger function processed a request.");
            await Task.CompletedTask;
            return /*await _creditoBusinessLogic.ObtenerHistorialComercialBuro(id)*/ null;

        }
    }
}
