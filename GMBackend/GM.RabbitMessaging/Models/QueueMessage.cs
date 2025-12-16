using GM.RabbitMessaging.Base;
using GM.RabbitMessaging.Queues.Interfaces;
using RabbitMQ.Client;

namespace GM.RabbitMessaging.Models;

public class QueueMessage : QueueMessageBase, IQueueMessage
{
    public Type ContentType { get; set; }
    public string Content { get; set; }

    public QueueMessage(BasicGetResult getResult) : base(getResult) { }

    public QueueMessage(string body) : base(body) { }
}
