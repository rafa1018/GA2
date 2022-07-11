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
    public class CrearFormulario
    {
        private readonly IFormularioBusinessLogic _formularioBusinessLogic;

        /// <summary>
        /// Ctor crear formulario
        /// </summary>
        /// <param name="formularioBusinessLogic">Business Logic formualrio</param>
        public CrearFormulario(IFormularioBusinessLogic formularioBusinessLogic)
        {
            _formularioBusinessLogic = formularioBusinessLogic;
        }

        /// <summary>
        /// Endpoint actualizar formulariodto 
        /// </summary>
        /// <param name="req">FormularioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("crearformulario")]
        public async Task<Response<FormularioDto>> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "roles/formulariocrear")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("RolPorUsuario - crearformulario");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var formularioDto = JsonConvert.DeserializeObject<FormularioDto>(body);

            return await _formularioBusinessLogic.CrearFormulario(formularioDto);
        }
    }
}
