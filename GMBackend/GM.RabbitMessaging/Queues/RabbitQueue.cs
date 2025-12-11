using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Providers.Interfaces;
using GM.RabbitMessaging.Queues.Interfaces;
using NLog;
using RabbitMQ.Client;
using System.Text;

namespace GM.RabbitMessaging.Queues;

// TODO: Add polly and retry policy
public class RabbitQueue : IMessagesQueue
{
    public string QueueName { get; }

    private readonly Logger logger;

    private readonly ConnectionFactory connectionFactory;

    private readonly IChannelsFactory channelsFactory;
    private readonly IMessagingSettingsProvider settingsProvider;

    private IConnection connection;

    public RabbitQueue(
        IChannelsFactory channelsFactory,
        IMessagingSettingsProvider settingsProvider,
        ConnectionFactory connectionFactory,
        string queueName)
    {
        this.connectionFactory = connectionFactory;
        this.channelsFactory = channelsFactory;
        this.settingsProvider = settingsProvider;

        this.QueueName = queueName;

        this.logger = LogManager.GetCurrentClassLogger();
    }

    public Task<IQueueMessage> GetMessageAsync(CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task SendMessageAsync(IQueueMessage message, CancellationToken cancellation) =>
        Task.Run(() => this.SendMessage(message.ToString()), cancellation);

    private void SendMessage(string content)
    {
        using var channel = this.TryGetChannel();
        if (channel == null)
        {
            this.logger.Error($"Failed to send message to {this.QueueName}, channel is null");
            return;
        }

        channel.BasicPublish(
            exchange: this.settingsProvider.GetDefaultExchange(),
            routingKey: this.QueueName,
            body: Encoding.UTF8.GetBytes(content));
    }

    private IModel TryGetChannel()
    {
        IModel channel = null;

        lock (connectionFactory)
        {
            try
            {
                if (this.connection == null || !this.connection.IsOpen)
                    this.connection = this.connectionFactory.CreateConnection(this.QueueName);

                channel = this.channelsFactory.TryGetChannel(this.connection, this.QueueName);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, "Failed to get channel because create connection to rabbitmq failed");
                return null;
            }
        }

        return channel;
    }
}
