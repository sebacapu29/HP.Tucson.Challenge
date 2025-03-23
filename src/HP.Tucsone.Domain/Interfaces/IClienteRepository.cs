namespace HP.Tucsone.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClienteEspera();
    }
}
