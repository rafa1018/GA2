using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;





namespace GA2.Infraestructure.Repositories
{
    public interface IGrupoOpcionesRepository
    {
        Task<IEnumerable<GrupoOpciones>> ObtenerGrupoOpciones();
        Task<GrupoOpciones> CrearGrupoOpciones(GrupoOpciones grupo);
        Task<GrupoOpciones> ObtenerGrupoOpcionesById(string codigo);
        Task<GrupoOpciones> EliminarGruposOpciones(int id);

        Task<GrupoOpciones> ActualizaGrupoOpciones(GrupoOpciones grupo);
        Task<IEnumerable<GrupoOpciones>> GetGrupoOpcionesGrupoById(int grupoId);

        Task<GrupoOpciones> EliminarGruposOpcionesGrupoById(int grupoId);
        Task<GrupoOpciones> InsertGruposOpcionesGrupoById(int grupoId, int opId);

        Task<IEnumerable<GrupoOpciones>> GetOpcionesGrupoById(int grupoId);

        Task<IEnumerable<GrupoOpciones>> GetAllOpciones();

        Task<GrupoOpciones> EliminarOpcionesGrupoById(int grupoId);

        Task<GrupoOpciones> InsertOpcionesGrupoById(int grupoId, int opId);

    }
}
