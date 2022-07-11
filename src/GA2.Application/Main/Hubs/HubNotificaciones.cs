using GA2.Application.Dto;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Comunicacion de signalR metods del sistema
    /// </summary>
    /// <date>27/05/2021</date>
    /// <author>Camilo Yaya</author>
    public class HubNotificaciones : Hub<IHubNotificaciones>
    {
        public async Task EnviarGrupoNotificacion(MensajeNotificacionDto mensaje, string grupoId)
        {
            await Clients.Group(grupoId).RecibirNotificacionPorGrupo(mensaje);
        }

        public async Task EnviarNotificacionUsuarioId(MensajeNotificacionDto mensaje, string userId)
        {
            await Clients.User(userId).RecibirNotificacionPorCliente(mensaje);
        }

        public async Task EnviarNotificacionTodos(MensajeNotificacionDto mensaje)
        {
            await Clients.All.RecibirNotificacionParaTodos(mensaje);
        }
    }

    /// <summary>
    /// Configuracion de los claims para obtener el usuario por el claim Name
    /// y se le passa el id del usuario o cliente
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>27/05/2021</date>
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            var claim = connection.User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value;
            return claim;
        }
    }
}
