namespace GM.Logging;

public static class LoggingFields
{
    public static class Http
    {
        public const string RequestPath = "request_path";
        public const string RequestBody = "request_body";
        public const string StatusCode = "status_code";
        public const string Method = "method";
    }

    public static class Sql
    {
        public const string Query = "sql_query";
        public const string ErrorCode = "sql_errorcode";
    }

    public static class Rabbit
    {
        public const string QueueName = "queue_name";
    }
}
