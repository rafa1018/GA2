using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// BusinessLogic de Notificacion 
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>17/05/2021</date>
    /// </summary>
    public class NotificacionBusinessLogic : INotificacionBusinessLogic
    {
        private readonly INotificacionRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<HubNotificaciones, IHubNotificaciones> _hubNotificaciones;

        public NotificacionBusinessLogic(INotificacionRepository notificationRepository,
                                         IMapper mapper,
                                         IHubContext<HubNotificaciones,
                                             IHubNotificaciones> hubNotificaciones)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _hubNotificaciones = hubNotificaciones;
        }

        /// <summary>
        /// Metodo Obtener Notificacion
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <returns></returns>
        public async Task<Response<IEnumerable<NotificacionDto>>> ObtenerNotificacionAsync(Guid userId)
        {
            IEnumerable<NotificacionDto> Notificacions = this._mapper.Map<IEnumerable<NotificacionDto>>(
                await this._notificationRepository.ObtenerNotificaciones(userId));
            return new Response<IEnumerable<NotificacionDto>> { Data = Notificacions };
        }

        /// <summary>
        /// Metodo Crear Notificacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <param name="parametrizacionNotificacionDto"></param>
        /// <returns></returns>
        public async Task CrearNotificacionGrupo(NotificacionDto parametrizacionNotificacionDto)
        {
            var notificacion = await this._notificationRepository.CrearNotificacion(this._mapper.Map<Notificacion>(parametrizacionNotificacionDto));
            if (notificacion != null)
            {
                await this._hubNotificaciones.Clients.Group(parametrizacionNotificacionDto.Receptor.ToString()).RecibirNotificacionPorGrupo(new MensajeNotificacionDto
                {
                    Mensaje = notificacion.MOD_N_MENSAJE,
                });
            }
        }

        /// <summary>
        /// Metodo  Actualizar Notificacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <param name="parametrizacionNotificacionDto"></param>
        /// <returns></returns>
        public async Task CrearNotificacionClienteId(NotificacionDto parametrizacionNotificacionDto)
        {
            var notificacion = await this._notificationRepository.CrearNotificacion(this._mapper.Map<Notificacion>(parametrizacionNotificacionDto));
            if (notificacion != null)
            {
                await this._hubNotificaciones.Clients.User(parametrizacionNotificacionDto.Receptor.ToString()).RecibirNotificacionPorCliente(new MensajeNotificacionDto
                {
                    Mensaje = notificacion.MOD_N_MENSAJE
                });
            }
        }
    }
}
