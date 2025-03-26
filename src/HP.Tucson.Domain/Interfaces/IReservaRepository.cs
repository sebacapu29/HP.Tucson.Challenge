using HP.Tucson.Domain.Entities;

namespace HP.Tucson.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva> CrearReserva(Reserva reserva);
        Task<IReadOnlyList<Reserva>?> ListarReservas();
        Task EliminarReserva(Reserva reserva);
        Task<IReadOnlyList<Reserva>> BuscarReservasDelCliente(int numeroCliente);
        Task<int> GenerarId();
        Task<Reserva> GetReservaByClienteYFecha(int numeroCliente, DateTime fechaHora);
    }
}
