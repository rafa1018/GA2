using GA2.BuildingBlocks.Events.EventBus.Events;
using System.Threading.Tasks;

namespace GA2.BuildingBlocks.Events.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
         where TIntegrationEvent : IntegrationEvent
    {
        Task HandleAsync(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
