using GA2.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Credito.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Genera Formato de reparto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>02/08/2021</date>
    public class GenerarFormatoReparto
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
        public GenerarFormatoReparto(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("GenerarFormatoReparto")]
        public async Task<FileResult> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "generarFormatoReparto/{id}")] Guid id, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Legalizacion y Desembolso - Genera Formato Reparto");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _creditoBusinessLogic.GenerarFormatoReparto(id);
        }
    }
}
