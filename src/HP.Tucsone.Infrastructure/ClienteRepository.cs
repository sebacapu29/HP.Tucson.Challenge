using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IEnumerable<Cliente> clientesEnEspera;
        private readonly IReservaRepository reservaRepository;
        public Task<IEnumerable<Cliente>> GetClienteEspera()
        {
            return Task.FromResult(this.clientesEnEspera);
        }
        public async Task AsignarReservaAClienteEspera()
        {
            var clientesEnEspera = await this.GetClienteEspera();
            var ultimoClienteEnEspera = clientesEnEspera.LastOrDefault();
            var fechaHora = new DateTime();
            var reservas = await reservaRepository.ListarReservas();
            var ultimaReserva = reservas.LastOrDefault();
            var nuevoId = 0;

            if (ultimaReserva != null)
            {
                nuevoId = ultimaReserva!.Id + 1;
            }
            if (ultimoClienteEnEspera != null)
            {
                var reserva = new Reserva(nuevoId, fechaHora, ultimoClienteEnEspera);
                await this.reservaRepository.CrearReserva(reserva);
            }
        }
    }
}
