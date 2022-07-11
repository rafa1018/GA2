using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class MatriculasInmobilariasLogic : IMatriculasInmobiliariasLogic
    {

        private readonly IMatriculasInmobiliariasRepository _matriculasInmobiliariasRepository;
        private readonly IMapper _mapper;

        public MatriculasInmobilariasLogic(IMatriculasInmobiliariasRepository matriculasInmobiliariasRepository, IMapper mapper)
        {
            _matriculasInmobiliariasRepository = matriculasInmobiliariasRepository;
            _mapper = mapper;
        }

        public async Task<Response<CrearMatriculaDto>> CrearMatriculaInmobiliaria(CrearMatriculaDto crearMatricula)
        {
            var gp = this._mapper.Map<CrearMatriculaDto>(await this._matriculasInmobiliariasRepository.CrearMatriculaInmobiliaria(this._mapper.Map<CrearMatricula>(crearMatricula)));
            return new Response<CrearMatriculaDto> { Data = gp };
        }

        public async Task<Response<PropietariosMatriculasInmobiliariasDto>> EditarHistorialPropietarios(PropietariosMatriculasInmobiliariasDto request)
        {
            var gp = this._mapper.Map<PropietariosMatriculasInmobiliariasDto>(await this._matriculasInmobiliariasRepository.EditarHistorialPropietarios(this._mapper.Map<PropietariosMatriculasInmobiliarias>(request)));
            return new Response<PropietariosMatriculasInmobiliariasDto> { Data = gp };
        }

        public async Task<Response<MatriculaInmibiliariaDto>> EditarInformacionBasicaMatricula(MatriculaInmibiliariaDto request)
        {
            var gp = this._mapper.Map<MatriculaInmibiliariaDto>(await this._matriculasInmobiliariasRepository.EditarInformacionBasicaMatricula(this._mapper.Map<MatriculaInmibiliaria>(request)));
            return new Response<MatriculaInmibiliariaDto> { Data = gp };
        }

        public async Task<Response<MatriculaInmibiliariaDto>> EliminarMatriculaInmobiliaria(MatriculaInmibiliariaDto request)
        {
            var result = await this._matriculasInmobiliariasRepository.EliminarMatriculaInmobiliaria(request.MaiId);
            return new Response<MatriculaInmibiliariaDto> { Data = request };
        }

        public async Task<Response<IEnumerable<MatriculaInmibiliariaDto>>> FilterMatriculasInmobiliarias(FiltroMatriculasInmobiliariasDto filto)
        {
            var gp = await this._matriculasInmobiliariasRepository.FiltroMatriculaInmobiliaria(filto.NumeroMatricula, filto.NumeroIdentificacion, filto.TipoIdentificacion);
            var result=  this._mapper.Map<IEnumerable<MatriculaInmibiliaria>, IEnumerable<MatriculaInmibiliariaDto>>(gp);
            return new Response<IEnumerable<MatriculaInmibiliariaDto>> { Data = result };

        }

        public async Task<Response<IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>> HistorialNovedadsMatriculaInmobiliariaById(Guid id)
        {
            var gp = await this._matriculasInmobiliariasRepository.HistorialNovedadsMatriculaInmobiliariaById(id);
           var result = this._mapper.Map<IEnumerable<HistotialNovedadesMatriculasInmobiliarias>, IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>(gp);
            return new Response<IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>> { Data = result };
        }

        public async Task<Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>> HistorialPropietariosMatriculaInmobiliariaById(Guid id)
        {
            var gp = await this._matriculasInmobiliariasRepository.HistorialPropietariosMatriculaInmobiliariaById(id);
            var result = this._mapper.Map<IEnumerable<PropietariosMatriculasInmobiliarias>, IEnumerable<PropietariosMatriculasInmobiliariasDto>>(gp);
            return new Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>> { Data = result };

        }

        public async Task<Response<MatriculaInmibiliariaDto>> InformacionBasicaMatriculaInmobiliariaById(Guid id)
        {
            var resulBasica = await this._matriculasInmobiliariasRepository.InformacionBasicaMatriculaInmobiliariaById(id);
            var resultInfoMatricula = this._mapper.Map<MatriculaInmibiliariaDto>(resulBasica);

            

            var resultPropi = await this._matriculasInmobiliariasRepository.HistorialPropietariosMatriculaInmobiliariaById(id);
            var resultPropietarios = this._mapper.Map<IEnumerable<PropietariosMatriculasInmobiliarias>, IEnumerable<PropietariosMatriculasInmobiliariasDto>>(resultPropi);

            resultInfoMatricula.Propietarios = (List<PropietariosMatriculasInmobiliariasDto>)resultPropietarios;

            var resultnovedades = await this._matriculasInmobiliariasRepository.HistorialNovedadsMatriculaInmobiliariaById(id);
            var resultNovedadesMatricula = this._mapper.Map<IEnumerable<HistotialNovedadesMatriculasInmobiliarias>, IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>(resultnovedades);
            resultInfoMatricula.Novedades = (List<HistotialNovedadesMatriculasInmobiliariasDto>)resultNovedadesMatricula;

            return new Response<MatriculaInmibiliariaDto> { Data = resultInfoMatricula };

        }

        public async Task<Response<IEnumerable<NovedadesMatriculasInmobiliariasDto>>> InsertNovedMatriculaInmobiliaria(NovedadesMatriculasInmobiliariasDto novedad)
        {

            var nov = this._mapper.Map<NovedadesMatriculasInmobiliarias>(novedad);
            var gp = await this._matriculasInmobiliariasRepository.InsertNovedMatriculaInmobiliaria(nov);

            var result = this._mapper.Map<IEnumerable<NovedadesMatriculasInmobiliariasDto>>(gp);
            return new Response<IEnumerable<NovedadesMatriculasInmobiliariasDto>> { Data = result };
        }

        public async Task<Response<IEnumerable<CausalNovedamatriculaDto>>> listarCausalNovedamatriculaById(Guid id)
        {
            var gp = await this._matriculasInmobiliariasRepository.listarCausalNovedamatriculaById(id);
            var result = this._mapper.Map<IEnumerable<CausalNovedamatricula>, IEnumerable<CausalNovedamatriculaDto>>(gp);
            return new Response<IEnumerable<CausalNovedamatriculaDto>> { Data = result };
        }

        public async Task<Response<IEnumerable<OperacionesMatriculasDto>>> listarOperacionesMatriculas()
        {
            var gp = await this._matriculasInmobiliariasRepository.listarOperacionesMatriculas();
            var result = this._mapper.Map<IEnumerable<OperacionesMatriculas>, IEnumerable<OperacionesMatriculasDto>>(gp);


            return new Response<IEnumerable<OperacionesMatriculasDto>> { Data = result };

        }

       
    }
}
