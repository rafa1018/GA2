using AutoMapper;
using Dapper;
using GA2.Application.Dto.GrupoOpciones;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.GrupoUsuarios;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class GruposOpcionesLogic : IGruposOpcionesLogic
    {

        private readonly IGrupoOpcionesRepository _grupoOpcionesRepository;    
        private readonly IMapper _mapper;

        public GruposOpcionesLogic(
         IGrupoOpcionesRepository grupoOpcionesRepository,
         IMapper mapper)
        {
            _grupoOpcionesRepository = grupoOpcionesRepository;
            _mapper = mapper;
        }

        public async Task<Response<GrupoOpcionesDto>> CrearGruposOpciones(GrupoOpcionesDto grupo)
        {

            GrupoOpciones grupoOpciones = new GrupoOpciones();

            grupoOpciones.CODIGO = grupo.Codigo;
            grupoOpciones.NOMBRE = grupo.Nombre;
            grupoOpciones.DESCRIPCION = grupo.Descripcion;
            grupoOpciones.ESTADO = grupo.Estado;

            var gp = await this._grupoOpcionesRepository.ObtenerGrupoOpcionesById(grupo.Codigo);

            if (gp != null)
            {
                return new Response<GrupoOpcionesDto> { IsSuccess = false, ReturnMessage = "Ya existe un grupo de opciones con este código:" + grupo.Codigo };
            }
            else
            {

                var repust = await this._grupoOpcionesRepository.CrearGrupoOpciones(grupoOpciones);
                return new Response<GrupoOpcionesDto> { Data = grupo };

            }

        }

        public async Task<Response<GrupoOpcionesDto>> ActualizaGruposOpciones(GrupoOpcionesDto grupo)
        {

            GrupoOpciones grupoOpciones = new GrupoOpciones();
            grupoOpciones.ID = grupo.Id;
            grupoOpciones.CODIGO = grupo.Codigo;
            grupoOpciones.NOMBRE = grupo.Nombre;
            grupoOpciones.DESCRIPCION = grupo.Descripcion;
            grupoOpciones.ESTADO = grupo.Estado;

            await this._grupoOpcionesRepository.ActualizaGrupoOpciones(grupoOpciones);

            await this._grupoOpcionesRepository.EliminarOpcionesGrupoById(grupoOpciones.ID);

            foreach (GrupoOpcionesDto item in grupo.opciones)
            {
                await this._grupoOpcionesRepository.InsertOpcionesGrupoById(grupo.Id, item.Id);
            }


            return new Response<GrupoOpcionesDto> { Data = grupo };

        }

        public async Task<Response<GrupoOpcionesDto>> EliminarGruposOpciones(GrupoOpcionesDto grupo)
        {

            var gp = await this._grupoOpcionesRepository.EliminarGruposOpciones(grupo.Id);
            return new Response<GrupoOpcionesDto> { Data = this._mapper.Map<GrupoOpcionesDto>(gp) };
        
        }

        public async Task<Response<IEnumerable<GrupoOpcionesDto>>> ObtenerGruposOpciones()
        {     
            var grupoOpciones = this._mapper.Map<IEnumerable<GrupoOpciones>, IEnumerable<GrupoOpcionesDto>>(await this._grupoOpcionesRepository.ObtenerGrupoOpciones());

            List<GrupoOpcionesDto> OpcionList = new List<GrupoOpcionesDto>();

           

            foreach (GrupoOpcionesDto item in grupoOpciones)
            {

                var dataOpcion = await this._grupoOpcionesRepository.GetOpcionesGrupoById(item.Id);
                var maperOption = this._mapper.Map<IEnumerable<GrupoOpcionesDto>>(dataOpcion);

                item.opciones= (List<GrupoOpcionesDto>)maperOption;
                OpcionList.Add(item);
            }

            return new Response<IEnumerable<GrupoOpcionesDto>> { Data = OpcionList };

          
        }

        public async Task<Response<IEnumerable<OpcionesDto>>> ObtenerOpciones()
        {

            var dataOpcion = await this._grupoOpcionesRepository.GetAllOpciones();
            var maperOption = this._mapper.Map<IEnumerable<OpcionesDto>>(dataOpcion);

            return new Response<IEnumerable<OpcionesDto>> { Data = maperOption };

        }


       
    }
}
