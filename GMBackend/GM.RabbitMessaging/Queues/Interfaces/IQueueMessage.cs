using RabbitMQ.Client;

namespace GM.RabbitMessaging.Queues.Interfaces;

public interface IQueueMessage
{
    string GetAsString();
    BasicGetResult GetResult();
}
