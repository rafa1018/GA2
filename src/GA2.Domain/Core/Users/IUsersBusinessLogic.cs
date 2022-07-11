using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GA2.Domain.Core
{
    public interface IUsersBusinessLogic
    {
        Task<Response<UsuarioDto>> CreateUser(UsuarioDto usuario,Guid idUser);
        Task<Response<UsuarioDto>> UpdateUserPassword(UsuarioDto usuario);
        Task<Response<UsuarioDto>> DeleteUser(Guid user);
        Task<Response<IEnumerable<UsuarioDto>>> GetUsers();
        Task<Response<UsuarioDto>> UpdateUser(UsuarioDto usuario);
    }
}