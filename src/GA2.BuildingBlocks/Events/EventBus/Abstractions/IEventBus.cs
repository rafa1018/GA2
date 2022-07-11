using GA2.BuildingBlocks.Events.EventBus.Events;

namespace GA2.BuildingBlocks.Events.EventBus.Abstractions
{
    /// <summary>
    /// Interface evento modelo
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>10/03/2021</date>
    public interface IEventBus
    {
        /// <summary>
        /// Publicar evento
        /// </summary>
        /// <param name="event"></param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>10/03/2021</date>
        void Publish(IntegrationEvent @event);


        /// <summary>
        /// Subscribir Evento
        /// </summary>
        /// <typeparam name="T">Modelo integracion</typeparam>
        /// <typeparam name="TH">Evento manejador</typeparam>
        /// <author>Osca Julian Rojas</author>
        /// <date>10/03/2021</date>
        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;


        /// <summary>
        /// Subscribir Evento
        /// </summary>
        /// <typeparam name="eventName">nombre evento</typeparam>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>10/03/2021</date>
        void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        /// <summary>
        /// Des Subscribir Evento dinamico
        /// </summary>
        /// <typeparam name="eventName">Nombre evento</typeparam>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>10/03/2021</date>
        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        /// <summary>
        /// Des Subscribir Evento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;
    }
}
