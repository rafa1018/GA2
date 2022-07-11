using GA2.Application.Dto.GrupoUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA2.Transversals.Commons;

namespace GA2.Domain.Core
{
    public interface IGruposUsuariosLogic
    {
        Task<Response<IEnumerable<GruposUsuariosDto>>> ObtenerGruposUsuarios();
        Task<Response<GruposUsuariosDto>> CreateGroupUser(GruposUsuariosDto grupo);

        Task<Response<GruposUsuariosDto>> DeleteGrupoUsuario(GruposUsuariosDto grupo);

        Task<Response<GruposUsuariosDto>> UpdateGrupoUsuario(GruposUsuariosDto grupo);

    }
}
