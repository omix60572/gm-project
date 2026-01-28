using GM.Remote.Enums;

namespace GM.Remote.Settings;

public class RemoteSearchSettings
{
    public const string Section = "RemoteSearchSettings";

    public ImageSearchProviders SearchProvider { get; set; }
}
