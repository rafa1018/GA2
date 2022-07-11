using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IMenuBusinessLogic
    {
        Task<Response<MenuDto>> ActualizarMenu(MenuDto menu);
        Task<Response<MenuDto>> CrearMenu(MenuDto menu);
        Task<Response<MenuDto>> EliminarMenu(MenuDto menu);
        Task<Response<MenuDto>> ObteneterMenu(Guid Id);
        Task<Response<IEnumerable<MenuDto>>> ObteneterMenusPorAppId(Guid AppId);
    }
}