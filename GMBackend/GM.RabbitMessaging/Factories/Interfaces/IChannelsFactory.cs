using RabbitMQ.Client;

namespace GM.RabbitMessaging.Factories.Interfaces;

public interface IChannelsFactory
{
    IModel TryGetChannel(IConnection connection, string queueName);
}
