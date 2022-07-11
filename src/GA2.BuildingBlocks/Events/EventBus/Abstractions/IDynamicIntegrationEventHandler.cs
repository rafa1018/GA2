using System.Threading.Tasks;

namespace GA2.BuildingBlocks.Events.EventBus.Abstractions
{
    /// <summary>
    /// Integracion dinamica de eventos
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>10/03/2021</date>
    public interface IDynamicIntegrationEventHandler
    {
        /// <summary>
        /// Manejador dinamico de eventos
        /// </summary>
        /// <param name="eventData">evento producido (modelo)</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>10/03/2021</date>
        Task HandleAsync(dynamic eventData);
    }
}
