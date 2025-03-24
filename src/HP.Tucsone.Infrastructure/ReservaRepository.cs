using HP.Tucsone.Domain;
using HP.Tucsone.Domain.Interfaces;

namespace HP.Tucsone.Infrastructure
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IEnumerable<Reserva> reservas;

        public ReservaRepository()
        {
            reservas = new List<Reserva>();
        }

        public Task<IEnumerable<Reserva>> BuscarReservasDelCliente(int numeroCliente)
        {
            var reservasDelCliente = this.reservas.Where(x=> x.IdCliente == numeroCliente);
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

        public Task<IEnumerable<Reserva>> ListarReservas()
        {
            return Task.FromResult(this.reservas);
        }
    }
}
