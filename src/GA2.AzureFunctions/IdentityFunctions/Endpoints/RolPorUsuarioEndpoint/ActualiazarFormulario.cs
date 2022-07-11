using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.RolPorUsuarioEndpoint
{
    public class ActualiazarFormulario
    {
        private readonly IFormularioBusinessLogic _formularioBusinessLogic;

        /// <summary>
        /// Ctor Actualizar formulario
        /// </summary>
        /// <param name="formularioBusinessLogic">Business Logic formualrio</param>
        public ActualiazarFormulario(IFormularioBusinessLogic formularioBusinessLogic)
        {
            _formularioBusinessLogic = formularioBusinessLogic;
        }

        /// <summary>
        /// Endpoint actualizar formulariodto 
        /// </summary>
        /// <param name="req">FormularioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("actualiazarformulario")]
        public async Task<Response<FormularioDto>> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "roles/formularioactualizar")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("RolPorUsuario - ActualiazarFormulario");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var formularioDto = JsonConvert.DeserializeObject<FormularioDto>(body);

            return await _formularioBusinessLogic.ActualizarFormulario(formularioDto);
        }
    }
}
