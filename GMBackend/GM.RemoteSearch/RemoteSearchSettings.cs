using GM.Remote.Enums;

namespace GM.Remote;

public class RemoteSearchSettingsBase
{
    public const string BaseSection = "RemoteSearchSettingsBase";

    public ImageSearchProviders SearchProvider { get; set; }
}

public class GoogleSearchSettings : RemoteSearchSettingsBase
{
    public const string Section = "GoogleSearchSettings";

    public string BaseUrl { get; set; }
    public string APIKey { get; set; }
    public string CsxKey { get; set; }
}
