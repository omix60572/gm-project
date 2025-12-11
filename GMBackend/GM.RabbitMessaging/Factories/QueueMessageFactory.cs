using GM.RabbitMessaging.Factories.Interfaces;
using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories;

public class QueueMessageFactory : IQueueMessageFactory
{
    public IQueueMessage CreateQueueMessage(string body)
    {
        throw new NotImplementedException();
    }
}
