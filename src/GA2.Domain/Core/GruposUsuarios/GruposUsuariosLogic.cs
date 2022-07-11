using AutoMapper;

using GA2.Application.Dto.GrupoUsuarios;
using GA2.Domain.Entities.GruposUsuarios;
using GA2.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA2.Transversals.Commons;
using GA2.Application.Dto.GrupoOpciones;

namespace GA2.Domain.Core
{
    public class GruposUsuariosLogic : IGruposUsuariosLogic
    {
        private readonly IGruposUsuariosRepository _gruposUsuariosRepository;
        private readonly IMapper _mapper;
        private readonly IGrupoOpcionesRepository _grupoOpcionesRepository;

        public GruposUsuariosLogic(
            IGruposUsuariosRepository gruposUsuariosRepository,
            IGrupoOpcionesRepository grupoOpcionesRepository,
            IMapper mapper)
        {
            _gruposUsuariosRepository = gruposUsuariosRepository;
            _grupoOpcionesRepository = grupoOpcionesRepository;
            _mapper = mapper;
        }

        public async Task<Response<GruposUsuariosDto>> CreateGroupUser(GruposUsuariosDto grupo)
        {
            GrupoUsuario grupoUser=new GrupoUsuario();

            grupoUser.CODIGO = grupo.Codigo;
            grupoUser.NOMBRE = grupo.Nombre;
            grupoUser.DESCRIPCION = grupo.Descripcion;
            grupoUser.ESTADO = grupo.Estado;

            var gp= await this._gruposUsuariosRepository.ObtenerGrupoUsuarioById(grupo.Codigo);

            if (gp != null)
            {
                return new Response<GruposUsuariosDto> { IsSuccess = false, ReturnMessage = "Ya existe un grupo de usuario con este código:" + grupo.Codigo };
            }
            else {

                var repust = await this._gruposUsuariosRepository.CreateGroupUser(grupoUser);
                foreach (GrupoOpcionesDto item in grupo.opciones)
                {
                    await this._gruposUsuariosRepository.InsertGrupoOpciones(item.Id,repust.ID);       
                }

               return new Response<GruposUsuariosDto> { Data = grupo };

            }
        }

        public async Task<Response<GruposUsuariosDto>> DeleteGrupoUsuario(GruposUsuariosDto grupo)
        {  
            var gp = await this._gruposUsuariosRepository.DeleteGrupoUsuarioById(grupo.Id);
            return new Response<GruposUsuariosDto> { Data = this._mapper.Map<GruposUsuariosDto>(gp) };
        }

        public async Task<Response<IEnumerable<GruposUsuariosDto>>> ObtenerGruposUsuarios()
        {


            var grupousuarios = this._mapper.Map<IEnumerable<GrupoUsuario>, IEnumerable<GruposUsuariosDto>>(await this._gruposUsuariosRepository.ObtenerGruposUsuarios());

            List<GruposUsuariosDto> OpcionList = new List<GruposUsuariosDto>();

            foreach (GruposUsuariosDto item in grupousuarios)
            {

                var dataOpcion = await this._grupoOpcionesRepository.GetGrupoOpcionesGrupoById(item.Id);
                var maperOption = this._mapper.Map<IEnumerable<GrupoOpcionesDto>>(dataOpcion);

                item.opciones= (List<GrupoOpcionesDto>)maperOption;
                OpcionList.Add(item);
            }

            return new Response<IEnumerable<GruposUsuariosDto>> { Data = OpcionList };

        }

        public async Task<Response<GruposUsuariosDto>> UpdateGrupoUsuario(GruposUsuariosDto grupo)
        {
            GrupoUsuario gpo=new GrupoUsuario();
            gpo.ID = grupo.Id;
            gpo.NOMBRE = grupo.Nombre;
            gpo.DESCRIPCION = grupo.Descripcion;
            gpo.CODIGO = grupo.Codigo;
            gpo.ESTADO = grupo.Estado;

            var gr = await this._gruposUsuariosRepository.ActualizaGroupUser(gpo);


            await this._grupoOpcionesRepository.EliminarGruposOpcionesGrupoById(grupo.Id);

            foreach (GrupoOpcionesDto item in grupo.opciones)
            {
                await this._grupoOpcionesRepository.InsertGruposOpcionesGrupoById(grupo.Id,item.Id);    
            }

            return new Response<GruposUsuariosDto> { Data = grupo };

        }
    }
}
