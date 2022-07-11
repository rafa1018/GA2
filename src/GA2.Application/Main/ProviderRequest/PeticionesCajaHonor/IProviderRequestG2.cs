using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IProviderRequestG2
    {
        Task<CHResponse<ClienteDto>> PeticionUsuariosPostCHAsync(dynamic obj, Uri url);
        Task<UsuarioDto> PruebaEjemploGetCHAsync<TOutput>(Uri url);
    }
}