using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Factories.Interfaces;

public interface IQueueMessageFactory
{
    IQueueMessage CreateQueueMessage(string body);
}
