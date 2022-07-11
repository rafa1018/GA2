using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// SubMenu logica de negocio
    /// </summary>
    /// <author>OScar Julian Rojas</author>
    /// <date>29/04/2021</date>
    public class SubMenuBusinessLogic : ISubMenuBusinessLogic
    {
        /// <summary>
        /// SubMenu inyeccion de repository
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        private readonly ISubMenuRepository _subMenuRepository;

        /// <summary>
        /// Mapper de submenu to submenudto
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor inyectando SubMenureposutory
        /// </summary>
        /// <param name="subMenuRepository"></param>
        public SubMenuBusinessLogic(ISubMenuRepository subMenuRepository, IMapper mapper)
        {
            _subMenuRepository = subMenuRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Actualizar Sub Menu
        /// </summary>
        /// <param name="subMenu">Submenu a actualizar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Submenu actualizado</returns>
        public async Task<Response<SubMenuDto>> ActualizarSubMenu(SubMenuDto subMenu)
        {
            return new Response<SubMenuDto>
            {
                Data = this._mapper.Map<SubMenuDto>(await this._subMenuRepository.ActualizarSubMenu(this._mapper.Map<SubMenu>(subMenu)))
            };
        }

        /// <summary>
        /// Crear Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a crear</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Submenu creado</returns>
        public async Task<Response<SubMenuDto>> CrearSubMenu(SubMenuDto subMenu)
         => new Response<SubMenuDto>
         {
             Data = this._mapper.Map<SubMenuDto>(await this._subMenuRepository.CrearSubMenu(this._mapper.Map<SubMenu>(subMenu)))
         };

        /// <summary>
        /// Eliminar Submenu
        /// </summary>
        /// <param name="subMenu">Submenu a eliminar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date<29/04/2021
        /// <returns>Submenu eliminado</returns>
        public async Task<Response<SubMenuDto>> EliminarSubMenu(SubMenuDto subMenu)
             => new Response<SubMenuDto>
             {
                 Data = this._mapper.Map<SubMenuDto>(await this._subMenuRepository.CrearSubMenu(this._mapper.Map<SubMenu>(subMenu)))
             };

        /// <summary>
        /// Obtener submenus por menu id
        /// </summary>
        /// <param name="MenuId">Menu id</param>
        /// <returns>Lista de submenus por menu</returns>
        public async Task<Response<IEnumerable<SubMenuDto>>> ObtenerSubMenusPorMenuId(Guid MenuId)
            => new Response<IEnumerable<SubMenuDto>>
            {
                Data = this._mapper.Map<IEnumerable<SubMenuDto>>(await this._subMenuRepository.ObtenerSubMenusPorMenuId(MenuId))
            };
    }
}
