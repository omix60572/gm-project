using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Models;
using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories;

public class QueueMessageFactory : IQueueMessageFactory
{
    public IQueueMessage GetQueueMessage(string body) =>
        new QueueMessage(body);
}
