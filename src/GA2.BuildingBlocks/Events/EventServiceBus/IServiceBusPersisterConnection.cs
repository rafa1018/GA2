using Microsoft.Azure.ServiceBus;
using System;

namespace GA2.BuildingBlocks.Events.EventServiceBus
{
    public interface IServiceBusPersisterConnection : IDisposable
    {
        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }

        ITopicClient CreateModel();
    }
}
