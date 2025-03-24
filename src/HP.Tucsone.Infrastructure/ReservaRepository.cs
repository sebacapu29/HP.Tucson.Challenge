using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly List<Reserva>? _reservas = new List<Reserva>();
        private readonly IMesaRepository? _mesaRepository;

        public ReservaRepository()
        {
        }
        public ReservaRepository(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }
        public Task<IReadOnlyList<Reserva>> BuscarReservasDelCliente(int numeroCliente)
        {
            IReadOnlyList<Reserva> reservasDelCliente = _reservas!.Where(x=> x?.Cliente?.Numero == numeroCliente).ToList();
            return Task.FromResult(reservasDelCliente);
        }

        public Task<Reserva> CrearReserva(Reserva reserva)
        {
            _reservas?.Add(reserva);
            return Task.FromResult(reserva);
        }

        public Task EliminarReserva(Reserva reserva)
        {
            var reservaEnLista = _reservas!.FirstOrDefault(r=> r.Id == reserva.Id);
            if(reservaEnLista != null)
            {
                _reservas!.Remove(reservaEnLista);
            }
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<Reserva>?> ListarReservas()
        {
            IReadOnlyList<Reserva> listaReservas = _reservas!.ToList();
            return Task.FromResult(listaReservas ?? null);
        }
    }
}
