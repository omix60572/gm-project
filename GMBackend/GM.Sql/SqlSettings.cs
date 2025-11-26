using GM.Sql.Enums;

namespace GM.Sql;

public class SqlSettings
{
    public const string Section = "SqlSettings";

    public string ConnectionString { get; set; }
    public SqlProviders SqlProvider { get; set; }
}
