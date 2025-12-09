using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories.Interfaces;

public interface IListenersFactory
{
    IQueueListener<T> GetListener<T>() where T : IQueueMessage;
}
