using HP.Tucsone.Domain.Entities;

namespace HP.Tucsone.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente?> GetClienteByNumero(int numero);
        Task<Categoria> GetCategoriaCliente(string nombre); 
    }
}
