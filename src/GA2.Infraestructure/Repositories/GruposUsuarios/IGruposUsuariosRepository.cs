using GA2.Domain.Entities.GruposUsuarios;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IGruposUsuariosRepository
    {

        Task<IEnumerable<GrupoUsuario>> ObtenerGruposUsuarios();
        Task<UsuariosPorGrupos> InsertGruposPorUsuarios(Guid userId, int grupoId);
        Task<GrupoUsuario> CreateGroupUser(GrupoUsuario grupo);
        Task<GruposPorOpciones> InsertGrupoOpciones(int opcionId, int grupoId);
        Task<GrupoUsuario> ObtenerGrupoUsuarioById(string codigo);

        Task<GrupoUsuario> DeleteGrupoUsuarioById(int grupoId);

        Task<GrupoUsuario> ActualizaGroupUser(GrupoUsuario grupo);

    }
}
