using GA2.Application.Dto;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IHubNotificaciones
    {
        /// <summary>
        /// Metodo del front para signalR
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar</param>
        /// <returns></returns>
        Task RecibirNotificacionPorGrupo(MensajeNotificacionDto mensaje);
        Task RecibirNotificacionPorCliente(MensajeNotificacionDto mensaje);
        Task RecibirNotificacionParaTodos(MensajeNotificacionDto mensaje);
    }
}