namespace HP.Tucsone.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva> CrearReserva(Reserva reserva);
        Task<IEnumerable<Reserva>> ListarReservas();
        Task EliminarReserva(Reserva reserva);
    }
}
