using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface INotificacionBusinessLogic
    {
        Task CrearNotificacionClienteId(NotificacionDto parametrizacionNotificacionDto);
        Task CrearNotificacionGrupo(NotificacionDto parametrizacionNotificacionDto);
        Task<Response<IEnumerable<NotificacionDto>>> ObtenerNotificacionAsync(Guid userId);
    }
}