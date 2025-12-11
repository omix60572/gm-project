namespace GM.RabbitMessaging.Providers.Interfaces;

public interface IMessagingSettingsProvider
{
    string GetDefaultExchange();
    int GetListenerDelay();
}
