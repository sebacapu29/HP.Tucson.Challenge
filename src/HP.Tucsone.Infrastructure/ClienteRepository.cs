using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Constants;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IEnumerable<Cliente> clientes;
        private readonly IReservaRepository reservaRepository;

        public ClienteRepository()
        {
            clientes = MockCliente.GetClientesMock();
        }
        public Task<IEnumerable<Cliente>> GetClientes()
        {
            return Task.FromResult(this.clientes);
        }
        public async Task AsignarReservaAClienteEspera()
        {
            var clientesEnEspera = await this.GetClientes();
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

        public Task<Cliente> GetClienteByNumero(int numero)
        {
            return Task.FromResult(this.clientes.FirstOrDefault(c => c.Id == numero));
        }
    }
}
