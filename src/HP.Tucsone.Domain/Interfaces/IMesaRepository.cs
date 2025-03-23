namespace HP.Tucsone.Domain.Interfaces
{
    public interface IMesaRepository
    {
        Task<IEnumerable<Mesa>> ObtenerTodas();
    }
}
