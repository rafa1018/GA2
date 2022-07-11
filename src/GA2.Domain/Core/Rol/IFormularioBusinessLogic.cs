using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IFormularioBusinessLogic
    {
        Task<Response<FormularioDto>> ActualizarFormulario(FormularioDto formulario);
        Task<Response<FormularioDto>> CrearFormulario(FormularioDto formulario);
        Task<Response<FormularioDto>> ObtenerFormularioPorId(FormularioDto formulario);
        Task<Response<IEnumerable<FormularioDto>>> ObtenerFormularios();
    }
}