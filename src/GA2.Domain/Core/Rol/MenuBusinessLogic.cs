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
    /// Menu logica de negocio
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/04/2021</date>
    public class MenuBusinessLogic : IMenuBusinessLogic
    {
        /// <summary>
        /// IMenuRepository inyeccion dependencia
        /// </summary>
        /// <author>OScar Julian Rojas Garces</author>
        /// <date>29/04/2021</date>
        private readonly IMenuRepository _menuRepository;

        /// <summary>
        /// Mapper de menu to menudto
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor inyectando menurepository
        /// </summary>
        /// <param name="menuRepository">Menurepository</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        public MenuBusinessLogic(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Actualizar Menu
        /// </summary>
        /// <param name="menu">Menu a actualizar</param>
        /// <returns>Menu actualizado</returns>
        public async Task<Response<MenuDto>> ActualizarMenu(MenuDto menu)
        {
            return new Response<MenuDto>
            {
                Data = this._mapper.Map<MenuDto>(await this._menuRepository.ActualizarMenu(this._mapper.Map<Menu>(menu)))
            };
        }

        /// <summary>
        /// Crear Menu
        /// </summary>
        /// <param name="menu">Menu a crear</param>
        /// <returns>Menu creado</returns>
        /// <author>Oscar Julian Rojas </author>
        /// <date>29/04/2021</date>
        public async Task<Response<MenuDto>> CrearMenu(MenuDto menu)
        {
            return new Response<MenuDto>
            {
                Data = this._mapper.Map<MenuDto>(await this._menuRepository.CrearMenu(this._mapper.Map<Menu>(menu)))
            };
        }

        /// <summary>
        /// Eliminar Menu
        /// </summary>
        /// <param name="menu">Menu a eliminar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Menu eliminado</returns>
        public async Task<Response<MenuDto>> EliminarMenu(MenuDto menu)
        {
            return new Response<MenuDto>
            {
                Data = this._mapper.Map<MenuDto>(await this._menuRepository.EliminarMenu(this._mapper.Map<Menu>(menu)))
            };
        }

        /// <summary>
        /// Obtener Menu por aplicacion
        /// </summary>
        /// <param name="menu">Menu obtenido</param>
        /// <returns>Menu buscado</returns>
        public async Task<Response<MenuDto>> ObteneterMenu(Guid Id)
        {
            return new Response<MenuDto>
            {
                Data = this._mapper.Map<MenuDto>(await this._menuRepository.ObteneterMenu(Id))
            };
        }

        /// <summary>
        /// Obtiene el menu por aplicacion Id
        /// </summary>
        /// <param name="AppId">Aplicacion Id</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>29/04/2021</date>
        /// <returns>Lista de menus de aplicacion</returns>
        public async Task<Response<IEnumerable<MenuDto>>> ObteneterMenusPorAppId(Guid AppId)
        {
            return new Response<IEnumerable<MenuDto>>
            {
                Data = this._mapper.Map<IEnumerable<MenuDto>>(await this._menuRepository.ObteneterMenusPorAppId(AppId))
            };
        }
    }
}
