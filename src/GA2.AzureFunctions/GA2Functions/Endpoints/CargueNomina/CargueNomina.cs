using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
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
    /// Cargue de nomina endpoint
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>10/08/2021</date>
    public class CargueNomina
    {
        /// <summary>
        /// Servicios inyectados
        /// </summary>
        private readonly IMovimientoBusinessLogic _movimeintoBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="movimeintoBusinessLogic">Logica movimiento service</param>
        /// <param name="tokenClaims">servicio tokens aplicacion</param>
        public CargueNomina(IMovimientoBusinessLogic movimeintoBusinessLogic, ITokenClaims tokenClaims)
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
        [Function("CargueNomina")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "cargarchivonomina")] HttpRequestData req, IFormFile form,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CargueNomina - CargueNomina");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var id = claims.Where(x => x.Type == "USR_ID").FirstOrDefault().Value;

            var result = await _movimeintoBusinessLogic.CargarArchivoNomina(form, Guid.Parse(id));

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
