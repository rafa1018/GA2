using System;
using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IMatriculasInmobiliariasLogic
    {

        Task<Response<IEnumerable<MatriculaInmibiliariaDto>>> FilterMatriculasInmobiliarias(FiltroMatriculasInmobiliariasDto filto);

        Task<Response<MatriculaInmibiliariaDto>> InformacionBasicaMatriculaInmobiliariaById(Guid id);

        Task<Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>> HistorialPropietariosMatriculaInmobiliariaById(Guid id);

        Task<Response<IEnumerable<NovedadesMatriculasInmobiliariasDto>>> InsertNovedMatriculaInmobiliaria(NovedadesMatriculasInmobiliariasDto novedad);

        Task<Response<IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>> HistorialNovedadsMatriculaInmobiliariaById(Guid id);


        Task<Response<IEnumerable<OperacionesMatriculasDto>>> listarOperacionesMatriculas();

        Task<Response<IEnumerable<CausalNovedamatriculaDto>>> listarCausalNovedamatriculaById(Guid id);
        Task<Response<CrearMatriculaDto>> CrearMatriculaInmobiliaria(CrearMatriculaDto crearMatricula);
        Task<Response<MatriculaInmibiliariaDto>> EliminarMatriculaInmobiliaria(MatriculaInmibiliariaDto request);
        Task<Response<MatriculaInmibiliariaDto>> EditarInformacionBasicaMatricula(MatriculaInmibiliariaDto request);
        Task<Response<PropietariosMatriculasInmobiliariasDto>> EditarHistorialPropietarios(PropietariosMatriculasInmobiliariasDto request);
        
    }
}
