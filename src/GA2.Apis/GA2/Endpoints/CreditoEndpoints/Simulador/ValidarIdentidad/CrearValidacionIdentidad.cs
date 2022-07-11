using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// 
    /// </summary>
    ///
    public class CrearValidacionIdentidad : BaseAsyncEndpoint
        .WithRequest<ValidacionIdentidadDto>.WithResponse<Response<ValidacionIdentidadDto>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Endpoint Crear validacion identidad
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public CrearValidacionIdentidad(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 

        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/CrearValidacionIdentidad")]
        [ProducesResponseType(typeof(Response<ValidacionIdentidadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crea validacion y envia codigo OTP",
            Description = "Se deben enviar las siguientes propiedades obligatorias en el request: </br>" +
            "<b>tidId</b>, <b>fechaExpedicion</b>, <b>numeroDocumento</b>, <b>numeroCelular</b>,<b> aceptaHabeas</b>,<b> aceptaTerminos</b> </br></br>" +
            "Para el control de excepciones, el modelo retornará la propiedad <b>'idError'</b> la cual en su valor: <b>0</b> representa la ejecución correcta de la logica de negocio,"+
            "o en su defecto el valor <b>1</b> respresenta errores en la logica de negocio del endpoint. </br></br>"+
            "Ejemplo: Si el response en su propiedad <b>isSuccess</b> es true y la propiedad  <b>idError</b> dentro del objeto <b>Data</b> es 1, redireccionar a la pantalla de error y mostrar el error "+
            "relacionado en la propiedad  <b>descripcionError</b>. </br></br>"+
            "La propiedad  <b>idPantalla</b> contiene la pantalla a la cual debe ser redirigido.",
            OperationId = "credito.CrearValidacionIdentidad",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ValidacionIdentidadDto>>> HandleAsync(ValidacionIdentidadDto request, CancellationToken cancellationToken = default)
        {
            return await this._identidadBusinessLogic.CreateValidacionIdentidad(request);
        }
    }
}
