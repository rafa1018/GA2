using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ISubMenuRepository
    {
        Task<SubMenu> ActualizarSubMenu(SubMenu subMenu);
        Task<SubMenu> CrearSubMenu(SubMenu subMenu);
        Task<SubMenu> EliminarSubMenu(SubMenu subMenu);
        Task<IEnumerable<SubMenu>> ObtenerSubMenusPorMenuId(Guid MenuId);
    }
}