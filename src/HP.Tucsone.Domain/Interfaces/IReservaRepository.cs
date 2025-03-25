using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva> CrearReserva(Reserva reserva);
        Task<IReadOnlyList<Reserva>?> ListarReservas();
        Task EliminarReserva(Reserva reserva);
        Task<IReadOnlyList<Reserva>> BuscarReservasDelCliente(int numeroCliente);
        Task<int> GenerarId();
    }
}
