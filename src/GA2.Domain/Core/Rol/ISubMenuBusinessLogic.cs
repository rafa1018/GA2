using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ISubMenuBusinessLogic
    {
        Task<Response<SubMenuDto>> ActualizarSubMenu(SubMenuDto subMenu);
    }
}