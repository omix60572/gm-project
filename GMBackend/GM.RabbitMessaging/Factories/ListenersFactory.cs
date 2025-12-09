using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Queues;
using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories;

public class ListenersFactory(MessagingSettings settings) : IListenersFactory
{
    private readonly MessagingSettings settings = settings;

    public IQueueListener<T> GetListener<T>() where T : IQueueMessage =>
        new QueueListener<T>(settings);
}
