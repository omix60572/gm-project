namespace GM.Services.Settings;

public class JwtSettings
{
    public const string Section = "JwtSettings";

    public string Key { get; set; }
    public uint ExpireHours { get; set; } = 168;
}
