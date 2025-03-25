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

        public async Task EliminarClienteEnEspera(Domain.Cliente cliente)
        {
            RedisValue clienteEnEspera = new RedisValue($"{cliente.Numero};{cliente?.Nombre?.ToLower()};{cliente?.Categoria?.Nombre.ToLower()}");
            await _dbRedis.ListRemoveAsync(RedisConfig.REDIS_KEY, clienteEnEspera);
        }

        public async Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera()
        {
            List<GetClienteEsperaResponse> listaClientesEnEspera = new();
            var keys = _redis.GetServer( RedisConfig.HOST, RedisConfig.PORT).Keys();
            var listKeys = keys.Select(k=> k.ToString()).ToList();
            var cantidadClientesEnEspera = await ObtenerCantidadDeClientes();
            for (int i = 0; i < cantidadClientesEnEspera; i++)
            {
                var clienteEnEspera = await ObtenerClienteEnEsperaByIndex(i);
                var clienteSplit = clienteEnEspera!.ToString()!.Split(';') ?? [];
                var clienteNombre = clienteSplit != null ? clienteSplit[1] : "-";
                var clienteNumero = clienteSplit != null ? int.Parse(clienteSplit[0]) : 0;
                var clienteCategoria = clienteSplit != null ? clienteSplit[2] : "-";
                listaClientesEnEspera.Add(new GetClienteEsperaResponse { Nombre = clienteNombre, NumeroCliente = clienteNumero, Categoria = clienteCategoria });
            }
            return listaClientesEnEspera;
        }

        public async Task PonerClienteEnEspera(Domain.Cliente cliente)
        {
            var cantidadDeClientes = await ObtenerCantidadDeClientes();
            RedisValue redisValue = new RedisValue($"{cliente.Numero};{cliente?.Nombre?.ToLower()};{cliente?.Categoria?.Nombre.ToLower()}");

            await _dbRedis.ListSetByIndexAsync(RedisConfig.REDIS_KEY, cantidadDeClientes + 1, redisValue);
        }
        private async Task<long> ObtenerCantidadDeClientes()
        {
            return await _dbRedis.ListLengthAsync(RedisConfig.REDIS_KEY);
        }
        private async Task<RedisValue> ObtenerClienteEnEsperaByIndex(int indice)
        {
            return await _dbRedis.ListGetByIndexAsync(RedisConfig.REDIS_KEY, indice);
        }
    }
}
