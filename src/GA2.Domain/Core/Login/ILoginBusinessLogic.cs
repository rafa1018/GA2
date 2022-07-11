using GA2.Application.Dto;
using GA2.Application.Dto.Identity;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ILoginBusinessLogic
    {
        Task<Response<ResponseLoginDto>> LoginGA2(LoginDto loginDto);
        Task<Response<string>> LoginGA2Paa(LoginPaaDto loginPaaDto);
        Task<Response<IEnumerable<MenuDto>>> ObtenerMenu();

        Task<Response<string>> RecuperaContrasena(RecuperarContrasenaDto recuperarContrasenaDto);

        Task<Response<UsuarioDto>> validaToken(string token);


    }
}