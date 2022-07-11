using GA2.Application.Dto;
using GA2.Application.Dto.Identity;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GA2.BUAFunctions.Endpoints.AfiliadoEndPoints
{
    /// <summary>
    /// Obtiene Cliente Paa
    /// </summary>
    public class ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular 
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor e inyección de dependencias
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(IClientesBusinessLogic clientsBussinesLogic, ITokenClaims tokenClaims)
        {
            _clientsBusinessLogic = clientsBussinesLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint login post
        /// </summary>
        /// <param name="req">loginDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular/{tipoDocumento}/{numeroIdentificacion}/{numeroCelular}/{fechaExpedicion}")]
            HttpRequestData req, string tipoDocumento, string numeroIdentificacion, string numeroCelular, DateTime fechaExpedicion, FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - Functions");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }
         
            var result = await _clientsBusinessLogic.ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(tipoDocumento, numeroIdentificacion, numeroCelular, fechaExpedicion);

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<ClienteDto>>(result);

            return response;
        }
    }
}
