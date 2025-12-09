using GM.RabbitMessaging.Base;
using GM.RabbitMessaging.Queues.Interfaces;

namespace GM.RabbitMessaging.Models;

public class QueueMessage : QueueMessageBase, IQueueMessage
{
    public Type ContentType { get; set; }
    public string Content { get; set; }
}
