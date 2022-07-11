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

namespace GA2Functions.Endpoints.Credito.Simulador.SolicitudCredito
{
    /// <summary>
    /// Crea solicitud credito financieros
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>02/08/2021</date>
    public class CrearSolicCreditoFinancieros
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
        public CrearSolicCreditoFinancieros(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("CrearSolicCreditoFinancieros")]
        public async Task<Response<CreditoFinancieroDto>> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "crearSolicCreditoFinancieros")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Solicitud Credito - Crea solic Financiera");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<CreditoFinancieroDto>(body);
            return await _creditoBusinessLogic.CrearSolicCreditoFinancieros(request);
        }
    }
}
