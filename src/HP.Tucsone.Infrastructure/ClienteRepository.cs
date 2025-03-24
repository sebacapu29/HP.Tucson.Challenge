using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Constants;
using HP.Tucsone.Domain.Entities;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes;
        private readonly IReservaRepository _reservaRepository;
        private readonly IMesaRepository _mesaRepository;
        private readonly List<Categoria> _categorias;
        public ClienteRepository(IMesaRepository mesaRepository, IReservaRepository reservaRepository)
        {
            _clientes = MockCliente.GetClientesMock();
            _mesaRepository = mesaRepository;
            _reservaRepository = reservaRepository;
            _categorias = MockCategorias.categorias;
        }
        public Task<List<Cliente>> GetClientes()
        {
            return Task.FromResult(_clientes);
        }
        public async Task AsignarReservaAClienteEspera()
        {
            var clientesEnEspera = await GetClientes();
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
                await _reservaRepository.CrearReserva(reserva);
            }
        }

        public Task<Cliente?> GetClienteByNumero(int numero)
        {
            return Task.FromResult(_clientes.FirstOrDefault(c => c.Numero == numero));
        }

        public Task<Categoria> GetCategoriaCliente(string nombre)
        {
            return Task.FromResult(_categorias.Where(c => c.Nombre.ToLower() == nombre.ToLower()).First());
        }
    }
}
