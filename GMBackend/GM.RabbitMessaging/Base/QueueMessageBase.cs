using GM.RabbitMessaging.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace GM.RabbitMessaging.Base;

public abstract class QueueMessageBase
{
    protected BasicGetResult result;

    public override string ToString()
    {
        var str = JsonConvert.SerializeObject(this);
        var queueMessage = new QueueMessage
        {
            ContentType = this.GetType(),
            Content = str
        };

        return JsonConvert.SerializeObject(queueMessage);
    }
}
