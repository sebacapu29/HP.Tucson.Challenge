namespace HP.Tucsone.Application.Configs
{
    public class RedisConfig
    {
        public const string HOST = "localhost";
        public const int PORT = 6379;
        public const string REDIS_KEY = "clientes_en_espera";
        public const string REDIS_CHANNEL = "clientes_en_espera";
    }
}
