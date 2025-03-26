using HP.Tucson.Domain.Entities;

namespace HP.Tucson.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente?> GetClienteByNumero(int numero);
        Task<Categoria> GetCategoriaCliente(string nombre); 
    }
}
