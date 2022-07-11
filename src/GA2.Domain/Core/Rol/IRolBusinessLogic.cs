using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface IRolBusinessLogic
    {
        Task<Response<RolDto>> CreateRol(RolDto roldto);
        Task<Response<RolDto>> DeleteRol(RolDto roldto);
        Task<Response<IEnumerable<RolDto>>> GetAllRol();
        Task<Response<RolDto>> GetByIdRol(Guid id);
        Task<Response<RolDto>> UpdateRol(RolDto roldto);
    }
}