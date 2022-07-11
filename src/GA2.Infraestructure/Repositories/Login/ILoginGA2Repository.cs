using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ILoginGA2Repository
    {
        Task<User> LoginUser(User user);
        Task<IEnumerable<Menu>> ObtenerMenu();
        Task<IEnumerable<SubMenu>> ObtenerSubmenu();
        Task<User> RecuperaContrasena(string tipo, string numero);

        Task<User> ActualizaTokenUser(Guid idUser, string token);

        Task<User> ValidaTokenRestablecimiento(string token);

        Task<IEnumerable<GrupoOpciones>> ObtenerOpcionesUsuariosById(Guid id);
    }
}