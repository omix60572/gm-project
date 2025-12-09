using GM.RabbitMessaging.Factories.Interfaces;
using RabbitMQ.Client;

namespace GM.RabbitMessaging.Factories;

public class ChannelsFactory : IChannelsFactory
{
    public IModel GetChannel(IConnection connection, string queueName)
    {
        throw new NotImplementedException();
    }
}
