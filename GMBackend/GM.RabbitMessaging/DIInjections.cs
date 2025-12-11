using GM.RabbitMessaging.Factories;
using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Providers;
using GM.RabbitMessaging.Providers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GM.RabbitMessaging;

public static  class DIInjections
{
    public static IServiceCollection AddRabbitMessaging(this IServiceCollection services, MessagingSettings settings) =>
        services
            .AddSingleton(settings)
            .AddSingleton<IMessagingSettingsProvider, MessagingSettingsProvider>()
            .AddSingleton<IChannelsFactory, ChannelsFactory>()
            .AddSingleton<IMessagesQueueFactory, MessagesQueueFactory>()
            .AddSingleton<IQueueMessageFactory, QueueMessageFactory>()
            .AddSingleton<IListenersFactory, ListenersFactory>();
}
