using RabbitMQ.Client;

namespace GM.RabbitMessaging.Factories.Interfaces;

public interface IChannelsFactory
{
    IModel GetChannel(IConnection connection, string queueName);
}
