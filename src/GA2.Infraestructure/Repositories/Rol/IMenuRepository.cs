using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IMenuRepository
    {
        Task<Menu> ActualizarMenu(Menu menu);
        Task<Menu> CrearMenu(Menu menu);
        Task<Menu> EliminarMenu(Menu menu);
        Task<Menu> ObteneterMenu(Guid Id);
        Task<IEnumerable<Menu>> ObteneterMenusPorAppId(Guid Id);


    }
}