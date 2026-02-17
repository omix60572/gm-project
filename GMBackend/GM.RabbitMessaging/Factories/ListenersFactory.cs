using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Providers.Interfaces;
using GM.RabbitMessaging.Queues;
using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories;

public class ListenersFactory : IListenersFactory
{
    private readonly IMessagingSettingsProvider settingsProvider;

    public ListenersFactory(IMessagingSettingsProvider settingsProvider) =>
        this.settingsProvider = settingsProvider;

    public IQueueListener<T> GetListener<T>() where T : IQueueMessage =>
        new QueueListener<T>(this.settingsProvider.GetListenerDelay());
}
