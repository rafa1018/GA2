using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IMatriculasInmobiliariasRepository
    {
        Task<IEnumerable<MatriculaInmibiliaria>> FiltroMatriculaInmobiliaria(string Numero_matricula, string numero_identifiucacion, int tipo_documento);

        Task<MatriculaInmibiliaria> InformacionBasicaMatriculaInmobiliariaById(Guid id);

        Task<IEnumerable<PropietariosMatriculasInmobiliarias>> HistorialPropietariosMatriculaInmobiliariaById(Guid id);

        Task<IEnumerable<NovedadesMatriculasInmobiliarias>> InsertNovedMatriculaInmobiliaria(NovedadesMatriculasInmobiliarias novedad);

        Task<IEnumerable<HistotialNovedadesMatriculasInmobiliarias>> HistorialNovedadsMatriculaInmobiliariaById(Guid id);

        Task<IEnumerable<OperacionesMatriculas>> listarOperacionesMatriculas();

        Task<IEnumerable<CausalNovedamatricula>> listarCausalNovedamatriculaById(Guid id);
        Task<CrearMatricula> CrearMatriculaInmobiliaria(CrearMatricula crearMatricula);
        Task<MatriculaInmibiliaria> EliminarMatriculaInmobiliaria(Guid idMatricula);
        Task<MatriculaInmibiliaria> EditarInformacionBasicaMatricula(MatriculaInmibiliaria request);
        Task<PropietariosMatriculasInmobiliarias> EditarHistorialPropietarios(PropietariosMatriculasInmobiliarias request);
    }
}
