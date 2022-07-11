using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;
using GA2.Domain.Core;
using Microsoft.Azure.Functions.Worker.Http;
using GA2.Application.Main;
using System.Net;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using GA2.Transversals.Commons;
using GA2.Application.Dto;

namespace ConsultarTasasSimulacion
{
    public class ConsultarTasasFunction
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public ConsultarTasasFunction(ICarteraBusinessLogic carteraBusinessLogic, ITokenClaims tokenClaims)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ConsultarTasasFunction")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "ObtenerParametrosTasas")] HttpRequestData req,
             FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("ConsultarTasaFunction");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var result = await this._carteraBusinessLogic.ObtenerTasasSimulador();

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var solicitudTasasSimulador = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(solicitudTasasSimulador);

            return response;

           
           
        }
    }
}
