using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IReadOnlyList<Reserva> reservas;
        private readonly IMesaRepository _mesaRepository;

        public ReservaRepository()
        {
            reservas = new List<Reserva>();
        }

        public Task<IReadOnlyList<Reserva>> BuscarReservasDelCliente(int numeroCliente)
        {
            IReadOnlyList<Reserva> reservasDelCliente = this.reservas.Where(x=> x.IdCliente == numeroCliente).ToList();
            return Task.FromResult(reservasDelCliente);
        }

        public Task<Reserva> CrearReserva(Reserva reserva)
        {
            reservas.Append(reserva);
            return Task.FromResult(reserva);
        }

        public Task EliminarReserva(Reserva reserva)
        {
            var reservaEnLista = this.reservas.FirstOrDefault(r=> r.Id == reserva.Id);
            if(reservaEnLista != null)
            {
                this.reservas.ToList().Remove(reservaEnLista);
            }
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<Reserva>> ListarReservas()
        {
            return Task.FromResult(this.reservas);
        }
    }
}
