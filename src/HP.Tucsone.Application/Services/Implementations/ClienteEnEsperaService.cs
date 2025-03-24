using HP.Tucsone.Application.Services.Interfaces;
using StackExchange.Redis;

namespace HP.Tucsone.Application.Services.Implementations
{
    public class ClienteEnEsperaService : IClienteEnEsperaService
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly ISubscriber _sub;

        public ClienteEnEsperaService()
        {
            _redis = ConnectionMultiplexer.Connect("localhost");
            _sub = _redis.GetSubscriber();
        }
        public void EscucharClientesEnEspera()
        {
            _sub.Subscribe("mesa_disponible", (channel, mensaje) =>
            {
                Console.WriteLine($"Cliente en espera: La mesa {mensaje} está disponible. Puedes reservar ahora.");
            });

            Console.WriteLine("Escuchando mesas disponibles...");
        }

        public Task PonerClienteEnEspera(Domain.Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
