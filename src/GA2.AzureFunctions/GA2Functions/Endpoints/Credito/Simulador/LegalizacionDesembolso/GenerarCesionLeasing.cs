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
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using Azure;
using System.Net;

namespace GA2Functions.Endpoints.Credito.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Genera documento cesion leasing
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>29/07/2021</date>
    public class GenerarCesionLeasing
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
        public GenerarCesionLeasing(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("GenerarCesionLeasing")]
        public async Task<FileResult> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "generarCesionLeasing/{id}")] Guid id, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Legalizacion y Desembolso - Genera Cesion Leasing");
            logger.LogInformation("C# HTTP trigger function processed a request.");
            return await _creditoBusinessLogic.GenerarCesionLeasing(id);
        }
    }
}
