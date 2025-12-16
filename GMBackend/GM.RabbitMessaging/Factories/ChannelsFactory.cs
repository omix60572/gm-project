using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Providers.Interfaces;
using NLog;
using RabbitMQ.Client;

namespace GM.RabbitMessaging.Factories;

public class ChannelsFactory(IMessagingSettingsProvider settingsProvider) : IChannelsFactory
{
    private readonly IMessagingSettingsProvider settingsProvider = settingsProvider;

    public IModel TryGetChannel(IConnection connection, string queueName)
    {
        var logger = LogManager.GetLogger(queueName);
        var exchangeName = this.settingsProvider.GetDefaultExchange();
        IModel channelModel = null;

        try
        {
            channelModel = connection.CreateModel();
            channelModel.ConfirmSelect();
            channelModel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);
            channelModel.QueueDeclare(
                queue: queueName,
                durable: false, // Не пишем на диск
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channelModel.QueueBind(
                queue: queueName,
                exchange: exchangeName,
                routingKey: queueName);
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"Failed to create channel for {queueName}");
            channelModel?.Close();
        }

        return channelModel;
    }
}
