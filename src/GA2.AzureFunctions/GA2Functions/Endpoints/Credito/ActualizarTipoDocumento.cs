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

namespace GA2Functions.Endpoints.Credito
{
    /// <summary>
	/// Endpoint para Actualizar Tipo Documento
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    public class ActualizarTipoDocumento
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
        public ActualizarTipoDocumento(ICreditoBusinessLogic creditoBusinessLogic, ITokenClaims tokenClaims)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ActualizarTipoDocumento")]
        public async Task<Response<TipoDocumentoDto>> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "actualizarTipoDocumento")] HttpRequestData req, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Credito - Actualizar Estado Actividad");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var request = JsonConvert.DeserializeObject<TipoDocumentoDto>(body);

            return await _creditoBusinessLogic.ActualizarTipoDocumento(request);
        }
    }
}
