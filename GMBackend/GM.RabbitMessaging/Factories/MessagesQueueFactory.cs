using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Providers.Interfaces;
using GM.RabbitMessaging.Queues;
using GM.RabbitMessaging.Queues.Interfaces;
using RabbitMQ.Client;

namespace GM.RabbitMessaging.Factories;

public class MessagesQueueFactory : IMessagesQueueFactory
{
    private readonly IChannelsFactory channelsFactory;
    private readonly IMessagingSettingsProvider settingsProvider;

    private readonly Lazy<ConnectionFactory> connectionFactory;

    private readonly string connectionString;

    public MessagesQueueFactory(IChannelsFactory channelsFactory, IMessagingSettingsProvider settingsProvider)
    {
        this.settingsProvider = settingsProvider;
        this.connectionString = settingsProvider.GetConnectionString();
        this.channelsFactory = channelsFactory;

        this.connectionFactory = new Lazy<ConnectionFactory>(() =>
        {
            return new ConnectionFactory()
            {
                AutomaticRecoveryEnabled = true,
                Uri = new Uri(this.connectionString)
            };
        });
    }

    public IMessagesQueue GetMessagesQueue(string queueName) =>
        new RabbitQueue(this.channelsFactory, this.settingsProvider, this.connectionFactory.Value, queueName);
}
