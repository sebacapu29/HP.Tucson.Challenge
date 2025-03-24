using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Constants;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IEnumerable<Cliente> clientes;
        private readonly IReservaRepository _reservaRepository;
        private readonly IMesaRepository _mesaRepository;

        public ClienteRepository(IMesaRepository mesaRepository, IReservaRepository reservaRepository)
        {
            clientes = MockCliente.GetClientesMock();
            _mesaRepository = mesaRepository;
            _reservaRepository = reservaRepository;
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
            var reservas = await _reservaRepository.ListarReservas();
            var ultimaReserva = reservas?.LastOrDefault();
            var nuevoId = 0;
            var mesas = _mesaRepository.ObtenerTodas();
            var mesaDisponible = mesas.Where(m => m.Disponible).FirstOrDefault();

            if(mesaDisponible == null)
            {
                throw new Exception("No hay mesas disponibles");
            }
            if (ultimaReserva != null)
            {
                nuevoId = ultimaReserva!.Id + 1;
            }
            if (ultimoClienteEnEspera != null)
            {
                var reserva = new Reserva(nuevoId, fechaHora, ultimoClienteEnEspera, mesaDisponible.Numero);
                await this._reservaRepository.CrearReserva(reserva);
            }
        }

        public Task<Cliente?> GetClienteByNumero(int numero)
        {
            return Task.FromResult(this.clientes.FirstOrDefault(c => c.Numero == numero));
        }
    }
}
