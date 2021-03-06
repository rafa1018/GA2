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

namespace GA2.GA2Functions.Endpoints.CargueNomina
{
    /// <summary>
    /// Obtener archivos cargados
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ObtenerArchivosCargados
    {
        /// <summary>
        /// Servicios parametros
        /// </summary>
        private readonly IMovimientoBusinessLogic _movimeintoBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="movimeintoBusinessLogic">Movimiento service</param>
        /// <param name="tokemClaims">Token service</param>
        public ObtenerArchivosCargados(IMovimientoBusinessLogic movimeintoBusinessLogic, ITokenClaims tokenClaims)
        {
            _movimeintoBusinessLogic = movimeintoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint crear usuario
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("ObtenerArchivosCargados")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "obtenerarchivoscargados/{Id}")] HttpRequestData req, int Id,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CargueNomina - obtenerarchivoscargados");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await _movimeintoBusinessLogic.ObtenerDocumentosCarga(Id);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
