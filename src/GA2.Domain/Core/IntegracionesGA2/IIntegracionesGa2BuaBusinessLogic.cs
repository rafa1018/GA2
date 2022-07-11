using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IIntegracionesGa2BuaBusinessLogic
    {
        Task<Response<string>> ObtenerBua(Uri url, ObtenerBuaRequest bua, Guid userId);
    }
}
