using HP.Tucsone.Application.Cliente.Models.Responses;
using HP.Tucsone.Application.Services.Interfaces;
using StackExchange.Redis;
using System.Collections.Generic;

namespace HP.Tucsone.Application.Services.Implementations
{
    public class ClienteEnEsperaService : IClienteEnEsperaService
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly ISubscriber _subscriber;

        public ClienteEnEsperaService()
        {
            _redis = ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false");
            _subscriber = _redis.GetSubscriber();
        }
        public void EscucharClientesEnEspera()
        {
            _subscriber.Subscribe("cliente_en_espera", (channel, mensaje) =>
            {
                Console.WriteLine($"Cliente en espera: La mesa {mensaje} está disponible.");
            });

            Console.WriteLine("Escuchando mesas disponibles...");
        }

        public async Task<List<GetClienteEsperaResponse>> ObtenerClientesEnEspera()
        {
            IDatabase db = _redis.GetDatabase();
            List<GetClienteEsperaResponse> listaClientesEnEspera = new();
            var keys = _redis.GetServer("localhost", 6379).Keys();
            var listKeys = keys.Select(k=> (string)k).ToList();
            var cantidadClientesEnEspera = await db.ListLengthAsync("clientes_en_espera");
            for (int i = 0; i < cantidadClientesEnEspera; i++)
            {
                var clienteEnEspera = await db.ListGetByIndexAsync("clientes_en_espera", i);
                listaClientesEnEspera.Add(new GetClienteEsperaResponse { Nombre = clienteEnEspera});
            }
            return listaClientesEnEspera;
        }

        public Task PonerClienteEnEspera(Domain.Cliente cliente)
        {
            IDatabase db = _redis.GetDatabase();

            db.StringSet("cliente_en_espera", $"valor prueba {cliente.Numero}");
            string valor = db.StringGet("prueba");

            Console.WriteLine($"Valor recuperado desde Redis: {valor}");
            return Task.CompletedTask;
        }
    }
}
