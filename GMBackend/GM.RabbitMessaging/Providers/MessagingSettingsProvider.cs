using GM.RabbitMessaging.Providers.Interfaces;

namespace GM.RabbitMessaging.Providers;

public class MessagingSettingsProvider(MessagingSettings settings) : IMessagingSettingsProvider
{
    private readonly MessagingSettings settings = settings;

    public string GetDefaultExchange() =>
        this.settings.DefaultExchange;

    public int GetListenerDelay() =>
        this.settings.QueueListenerDelay;
}
