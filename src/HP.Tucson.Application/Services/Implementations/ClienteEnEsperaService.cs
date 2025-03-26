using HP.Tucson.Application.FeatureCliente.Models.Responses;
using HP.Tucson.Application.Configs;
using HP.Tucson.Application.Services.Interfaces;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace HP.Tucson.Application.Services.Implementations
{
    public class ClienteEnEsperaService : IClienteEnEsperaService
    {
        private readonly ConnectionMultiplexer _redis;
        private IDatabase _dbRedis;
        private IConfiguration _configuration;
        private RedisConfig redisConfig;
        public ClienteEnEsperaService(IConfiguration configuration)
        {
            _configuration = configuration;
            redisConfig = new RedisConfig
            {
                Host = _configuration["RedisConfig:Host"] ?? string.Empty,
                Port = int.Parse(_configuration["RedisConfig:Port"] ?? string.Empty),
                RedisChannel = _configuration["RedisConfig:RedisChannel"] ?? string.Empty,
                RedisKey = _configuration["RedisConfig:RedisKey"] ?? string.Empty
            };
            _redis = ConnectionMultiplexer.Connect($"{ redisConfig.Host }:{ redisConfig.Port },abortConnect=false");
            _dbRedis = _redis.GetDatabase();
        }

        public async Task EliminarClienteEnEspera(Domain.Entities.Cliente cliente)
        {
            RedisValue clienteEnEspera = new RedisValue($"{cliente.Numero};{cliente?.Nombre?.ToLower()};{cliente?.Categoria?.Nombre.ToLower()}");
            await _dbRedis.ListRemoveAsync(redisConfig.RedisKey, clienteEnEspera);
        }

        public async Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera()
        {
            try
            {
                
                List<GetClienteEsperaResponse> listaClientesEnEspera = new();
                var keys = _redis.GetServer(redisConfig.Host, redisConfig.Port).Keys();
                var listKeys = keys.Select(k => k.ToString()).ToList();
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
            catch (Exception ex)
            {
                throw new RedisException("Se produjo un error al obtener clientes en espera", ex);
            }
        }

        public async Task PonerClienteEnEspera(Domain.Entities.Cliente cliente)
        {
            try
            {
                var cantidadDeClientes = await ObtenerCantidadDeClientes();
                RedisValue redisValue = new RedisValue($"{cliente.Numero};{cliente?.Nombre?.ToLower()};{cliente?.Categoria?.Nombre.ToLower()}");

                await _dbRedis.ListSetByIndexAsync(redisConfig.RedisKey, cantidadDeClientes + 1, redisValue);
            }
            catch (Exception ex)
            {
                throw new RedisException("Se produhi un error al poner cliente en espera", ex);
            }

        }
        private async Task<long> ObtenerCantidadDeClientes()
        {
            return await _dbRedis.ListLengthAsync(redisConfig.RedisKey);
        }
        private async Task<RedisValue> ObtenerClienteEnEsperaByIndex(int indice)
        {
            return await _dbRedis.ListGetByIndexAsync(redisConfig.RedisKey, indice);
        }
    }
}
