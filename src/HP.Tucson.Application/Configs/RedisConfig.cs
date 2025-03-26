namespace HP.Tucson.Application.Configs
{
    public class RedisConfig
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? RedisKey { get; set; }
        public string? RedisChannel { get; set; }
    }
}
