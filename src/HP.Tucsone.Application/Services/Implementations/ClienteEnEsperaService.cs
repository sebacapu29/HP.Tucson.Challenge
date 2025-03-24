using HP.Tucsone.Application.Cliente.Models.Responses;
using HP.Tucsone.Application.Configs;
using HP.Tucsone.Application.Services.Interfaces;
using StackExchange.Redis;

namespace HP.Tucsone.Application.Services.Implementations
{
    public class ClienteEnEsperaService : IClienteEnEsperaService
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly ISubscriber _subscriber;
        private IDatabase _dbRedis;
        
        public ClienteEnEsperaService()
        {
            _redis = ConnectionMultiplexer.Connect($"{ RedisConfig.HOST }:{ RedisConfig.PORT },abortConnect=false");
            _subscriber = _redis.GetSubscriber();
            _dbRedis = _redis.GetDatabase();
        }
        public void EscucharClientesEnEspera()
        {
            RedisChannel channelWithLiteral = new RedisChannel("cliente_en_espera", RedisChannel.PatternMode.Literal);
            _subscriber.SubscribeAsync(channelWithLiteral, (channel, mensaje) =>
            {
                Console.WriteLine($"Cliente en espera: La mesa {mensaje} está disponible.");
            });

            Console.WriteLine("Escuchando mesas disponibles...");
        }

        public async Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera()
        {
            List<GetClienteEsperaResponse> listaClientesEnEspera = new();
            var keys = _redis.GetServer( RedisConfig.HOST, RedisConfig.PORT).Keys();
            var listKeys = keys.Select(k=> k.ToString()).ToList();
            var cantidadClientesEnEspera = await _dbRedis.ListLengthAsync(RedisConfig.REDIS_KEY);
            for (int i = 0; i < cantidadClientesEnEspera; i++)
            {
                var clienteEnEspera = await _dbRedis.ListGetByIndexAsync(RedisConfig.REDIS_KEY, i);
                var clienteSplit = clienteEnEspera!.ToString()!.Split(';') ?? [];
                var clienteNombre = clienteSplit != null ? clienteSplit[1] : "-";
                var clienteNumero = clienteSplit != null ? int.Parse(clienteSplit[0]) : 0;
                listaClientesEnEspera.Add(new GetClienteEsperaResponse { Nombre = clienteNombre, NumeroCliente = clienteNumero });
            }
            return listaClientesEnEspera;
        }

        public async Task PonerClienteEnEspera(Domain.Cliente cliente)
        {
            var cantidadDeClientes = await _dbRedis.ListLengthAsync(RedisConfig.REDIS_KEY);
            RedisValue redisValue = new RedisValue($"{cliente.Numero};{cliente.Nombre}");

            await _dbRedis.ListSetByIndexAsync(RedisConfig.REDIS_KEY, cantidadDeClientes + 1, redisValue);
        }
    }
}
