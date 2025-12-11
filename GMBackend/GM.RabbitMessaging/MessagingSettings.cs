namespace GM.RabbitMessaging;

public class MessagingSettings
{
    public const string Section = "MessagingSettings";

    public int QueueListenerDelay { get; set; } = 3000;
    public string DefaultExchange { get; set; } = "gm.exchange";
    public string ConnectionString { get; set; }
}
